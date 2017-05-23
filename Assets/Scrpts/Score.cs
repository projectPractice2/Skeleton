using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Score : MonoBehaviour {
    public class scoreData_t{
        public scoreData_t(string name,int score){
            this.name = name;
            this.score = score;
        }
        public int score;
        public string name;
    }


    List<scoreData_t> scoreData = new List<scoreData_t>();
    List<scoreData_t> scoreDataMax = new List<scoreData_t>();
	// Use this for initialization
	void Start () {
        scoreData.Add(new scoreData_t("ABC",123));
        scoreData.Add(new scoreData_t("ABC", 203));
        scoreData.Add(new scoreData_t("abc", 190));
        scoreDataMax = scoreData;
        scoreData.OrderBy(i => i.score);
        foreach (var i in scoreData) {
            Debug.Log("name:"+i.name+" , score:"+i.score);
        }
	}

    public void AddScore(string name,int score){
        scoreData.Add(new scoreData_t(name,score));
        scoreDataMax = scoreData;
    }

    void HighScore(){
        int max = scoreData[0].score;
        foreach (var i in scoreData) {
            if (max < i.score) {
                max = i.score;
            }
        }
        Debug.Log(max);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
