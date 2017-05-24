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
        for (int x = 0; x < stageData.Length; x++) {
            stageData[x] = new int[120];
        }
        MapDataLoad();

        for (int x = 0; x < stageData.Length; x++) {
            for (int y = 0; y < stageData[x].Length; y++) {
                if (stageData[x][y] == 1) {
                    var obj = Instantiate(stage, new Vector2(marginX + x, marginY + y), Quaternion.identity);
                    //obj.GetComponent<MeshRenderer>().material = block;
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
        for (int y = 0; y < textList.Count; y++) {
            string[] line = textList[y].Split(',');
            for (int x = 0; x < line.Length; x++) {
                stageData[x][y] = int.Parse(line[y]);
            }
        }
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