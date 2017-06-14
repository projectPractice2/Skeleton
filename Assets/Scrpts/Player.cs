﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject UpperPlayer;
    Camera mainCamera, rightCamera, leftCamera;
    GameObject mainCameraObj, rightCameraObj, leftCameraObj;
    Rigidbody rig;
    public Vector3 position;
    public Vector2 offset;
    public float speed;
    int jumpCnt = 0;

    float StartPos, EndPos;//x座標
    Vector2 pos;

    Key key;
    // Use this for initialization
    void Start() {
        key = GameObject.Find("Key").GetComponent<Key>();

        rig = GetComponent<Rigidbody>();
        mainCameraObj = GameObject.Find("Main Camera");
        rightCameraObj = GameObject.Find("Right Camera");
        leftCameraObj = GameObject.Find("Left Camera");

        mainCamera = mainCameraObj.GetComponent<Camera>();

        offset = mainCamera.transform.position - transform.position;
        speed = 5.0f;
        rig.velocity = new Vector2(20.0f, 0);
    }

    void LateUpdate() {
        speed += 0.01f;
        speed = Mathf.Clamp(speed, 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update() {
        position = transform.position;
        if ((Input.GetKeyDown(KeyCode.Space) || key.IsKey("Jump")) && jumpCnt <= 2) {
            Debug.Log("Jump");
            rig.AddForce(new Vector2(0.0f, 600.0f));
            jumpCnt++;
        } else if (transform.position.y <= 2.5) {
        }

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y <= 2.5f) {
            transform.localScale = new Vector3(-1, 0.4f, 1);
            //position.y = transform.position.y - (0.25f);
            rig.velocity = new Vector2(2.0f, 0);
        }else{
            transform.localScale = new Vector3(-1, 1.0f, 1);
            //UpperPlayer.SetActive(true);
        }

        if (Input.GetKey(KeyCode.RightArrow) || key.IsKey("Right")) {
            rig.velocity = new Vector2(2.0f * speed, 0);
            speed += 0.05f;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || key.IsKey("Left")) {
            rig.velocity = new Vector2(-2.0f * speed, 0);
            speed -= 0.05f;
        } else {
            //rig.velocity = new Vector2(2.0f * speed, 0);
        }
        Flick();
        transform.position = position;
    }

    void Flick() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("start position : " + StartPos);
            StartPos = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("end position : " + EndPos);
            EndPos = Input.mousePosition.x;
        }
        if (StartPos > EndPos) {
            rig.AddForce(new Vector2(-2.0f,0));
        } else if (StartPos < EndPos) {
            rig.AddForce(new Vector2(2.0f, 0));
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "block" || collision.gameObject.tag == "Enemy") {
            jumpCnt = 0;
        }
    }
}
