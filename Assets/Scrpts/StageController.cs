using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class StageController : MonoBehaviour {
    [SerializeField]
    public int[][] stageData;
    public Material block;

    public GameObject stage;
    int marginX = 0, marginY = 0;
    // Use this for initialization
    void Start() {
        stageData = new int[30][];
        for (int y = 0; y < stageData.Length; y++) {
            stageData[y] = new int[100];
        }
        MapDataLoad();
        for (int y = 0; y < stageData.Length; y++) {
            for (int x = 0; x < stageData[y].Length; x++) {
                switch (stageData[y][x]) {
                    case 9:
                        var obj = Instantiate(stage, new Vector3(marginX + x, marginY + y,-1), Quaternion.identity);
                        //obj.GetComponent<MeshRenderer>().material = block;
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("1:"+stageData.GetLength(1)+" 0:"+stageData.GetLength(0));
    }
    void MapDataLoad() {
        string text = Resources.Load<TextAsset>("MapData").text;
        string[] texts = text.Split('\n');
        List<string> textList = texts.ToList();
        textList.RemoveAt(0);
        //        for (int y = 0; y < textList.Count; y++) {
        for (int y = textList.Count-1; y >= 0; y--) {
            string[] line = textList[y].Split(',');
            for (int x = 0; x < line.Length; x++) {
                stageData[textList.Count-y][x] = int.Parse(line[x]);
            }
        }
        string debug = "";
        for (int i = stageData.Length - 1; i >= 0; i--) {
            for (int j = 0; j < stageData[i].Length; j++) {
                debug += stageData[i][j];
            }
            debug += "\n";
        }
        Debug.Log(debug);
    }

    void log(string filePath) {
        FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        Encoding utf8 = Encoding.GetEncoding("UTF-8");
        //utf8 = Encoding.UTF8;
        StreamWriter sw = new StreamWriter(fs, utf8);
        for (int y = 0; y < stageData.Length; y++) {
            for (int x = 0; x < stageData[y].Length; x++) {
                sw.Write(stageData[y][x] + ",");
            }
            sw.Write("\r\n");
        }
        sw.Flush();
        sw.Close();
    }
}