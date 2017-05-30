﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Camera mainCamera, rightCamera, leftCamera;
    GameObject mainCameraObj, rightCameraObj, leftCameraObj;
    Rigidbody rig;
    public Vector2 position;
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
        rig.velocity = new Vector2(0.1f, 0);
        mainCameraObj = GameObject.Find("Main Camera");
        rightCameraObj = GameObject.Find("Right Camera");
        leftCameraObj = GameObject.Find("Left Camera");

        mainCamera = mainCameraObj.GetComponent<Camera>();

        offset = mainCamera.transform.position - transform.position;
        speed = 2.0f;
    }

    void LateUpdate() {
        speed += 0.002f;
        speed = Mathf.Clamp(speed, 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update() {
        position = transform.position;
        if ((Input.GetKeyDown(KeyCode.Space) || key.IsKey("Jump")) && jumpCnt <= 2) {
            rig.AddForce(new Vector2(0.0f, 5000.0f));
            jumpCnt++;
        } else if (transform.position.y <= 2.5) {
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            position.y = transform.position.y;
        } else {
            transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow) || key.IsKey("Right")) {
            rig.AddForce(new Vector2(50f * speed, 0));
            speed += 0.05f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || key.IsKey("Left")) {
            rig.AddForce(new Vector2(-50f * speed, 0));
            speed -= 0.05f;
        } else{
            rig.AddForce(new Vector2(500f * speed, 0));
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
            position.x -= 0.1f;
        } else if (StartPos < EndPos) {
            position.x += 0.1f;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "block") {
            jumpCnt = 0;
        }
    }
}
