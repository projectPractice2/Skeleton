﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {
    int[,] tmpStageData = {
        {0,0,0},
        {0,0,0},
        {1,1,1},
    };

    public GameObject stage;
    int marginX = 1, marginY = 1;
    // Use this for initialization
    void Start() {
        /*
        List<List<int>> stageData = new List<List<int>>();
        stageData.Add(new List<int>(new int[] {0,0,0,0 }));
        stageData.Add(new List<int>(new int[] { 0, 0, 0, 0 }));
        stageData.Add(new List<int>(new int[] { 0, 0, 0, 0 }));
        stageData.Add(new List<int>(new int[] { 0, 0, 0, 0 }));
        stageData.Add(new List<int>(new int[] { 0, 0, 0, 0 }));
        stageData.Add(new List<int>(new int[] { 0, 0, 0, 0 }));
        stageData.Add(new List<int>(new int[] { 0, 0, 0, 0 }));
*/

        int[,] stageData = new int[100, 10];
        for (int x = 0; x < stageData.GetLength(0); x++) {
            for (int y = 0; y < stageData.GetLength(1) - 1; y++) {
                stageData[x, y] = Random.Range(0, 1 + 1);
                Debug.Log(stageData[x, y]);
            }
            stageData[x, 3] = 0;
            stageData[x, 2] = 0;
            stageData[x, 1] = 0;
            stageData[x, 0] = 1;
        }
        for (int x = 0; x < stageData.GetLength(0); x++) {
            for (int y = 0; y < stageData.GetLength(1); y++) {
                if (stageData[x, y] == 1) {
                    var obj = Instantiate(stage, new Vector2(marginX + x, marginY + y), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
