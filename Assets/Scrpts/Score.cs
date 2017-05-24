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
	// Use this for initialization
	void Start () {
        
    }

    public void AddScore(string name,int score){
        scoreData.Add(new scoreData_t(name,score));
    }

    public scoreData_t HighScore(List<scoreData_t> score){
        var maxData = score.OrderBy(i=>i.score);
        return maxData.Last();
    }
    public int HighScore(){
        return HighScore(scoreData).score;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
