﻿﻿﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class StageController : MonoBehaviour {
    [SerializeField]
    public int[,] stageData = new int[5, 5];
    public Material block;

    public GameObject stage;
    int marginX = -1, marginY = -1;
    // Use this for initialization
    void Start() {
        for (int x = 0; x < stageData.GetLength(0); x++) {
            for (int y = 0; y < stageData.GetLength(1); y++) {
                if (stageData[x, y] == 1) {
                    var obj = Instantiate(stage, new Vector2(marginX + x, marginY + y), Quaternion.identity);
                    //obj.GetComponent<MeshRenderer>().material = block;
                }
            }
        }

        MapDataLoad();
        log(Application.dataPath + "/stageDataLog.txt");
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("1:"+stageData.GetLength(1)+" 0:"+stageData.GetLength(0));

    }
    void MapDataLoad() {
        string text = Resources.Load<TextAsset>("MapData").text;
        string[] texts = text.Split('\n');
        List<string> textList = new List<string>();
        textList = texts.ToList();
        textList.RemoveAt(0);

        for (int i = 0; i < textList.Count - 1; i++) {
            string[] line = textList[i].Split(',');
            Debug.Log(textList[i]);
            for (int j = 0; j < line.Length; j++) {
                Debug.Log("j = " + j);
                Debug.Log("line[j] = " + line[j]);
                stageData[i, j] = int.Parse(line[j]);
            }
        }
    }

    void log(string filePath) {
        FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
        for (int i = 0; i < stageData.GetLength(0); i++) {
            for (int j = 0; j < stageData.GetLength(1); j++) {
                sw.Write(stageData[i, j]);
            }
            sw.Write("\r\n");
        }
    }
}