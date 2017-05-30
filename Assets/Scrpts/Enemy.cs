using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    int attack, hp;
    float speed = 0.5f;

    Rigidbody rig;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
        rig.velocity = new Vector3(-0.1f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Move(){
        
    }

    public void Create(int attack,int hp){
        this.attack = attack;
        this.hp = hp;
    }
}
