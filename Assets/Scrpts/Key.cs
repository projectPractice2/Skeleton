﻿using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public Dictionary<string, bool> keys = new Dictionary<string, bool>();
    // Use this for initialization
    void Start() {
        keys.Add("Up", false);
        keys.Add("Down", false);
        keys.Add("Left", false);
        keys.Add("Right", false);
        keys.Add("Jump", false);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {
    
    }

    public bool IsKey(string key){
        bool flag = false;
        if (keys.ContainsKey(key)) {
            flag = keys[key];
        }
        else{
            Debug.Log("dont contain "+ key);
        }
        return flag;
    }

    public void SetKey(string key, bool flag) {
        keys[key] = flag;
    }
}
