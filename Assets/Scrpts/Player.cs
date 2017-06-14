﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Vector3 NormalColiderSize = new Vector3(1.2f, 1.8f, 1.0f);
    Vector3 SlidingColiderSize =new Vector3(1.2f, 1.2f, 1.0f);

    Animator anim;
    public GameObject UpperPlayer;
    Camera mainCamera;
    GameObject mainCameraObj;
    Rigidbody rig;
    public Vector3 position;
    public Vector2 offset;
    public float speed;
    int jumpCnt = 0;

    Vector2 StartPos, EndPos;//x座標
    Vector2 pos;

    Key key;
    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        key = GameObject.Find("Key").GetComponent<Key>();

        rig = GetComponent<Rigidbody>();
        mainCameraObj = GameObject.Find("Main Camera");

        mainCamera = mainCameraObj.GetComponent<Camera>();

        offset = mainCamera.transform.position - transform.position;
        speed = 1.0f;
        rig.velocity = new Vector2(1.0f, 0);
    }

    void LateUpdate() {
        speed += 0.01f;
        speed = Mathf.Clamp(speed, 0.0f, 2.0f);
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
            Sliding();
        }

        if (Input.GetKey(KeyCode.RightArrow) || key.IsKey("Right")) {
            GetComponent<BoxCollider>().size = NormalColiderSize;
            rig.velocity = new Vector2(2.0f * speed, 0);
            speed += 0.05f;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || key.IsKey("Left")) {
            rig.velocity = new Vector2(-2.0f * speed, 0);
            speed -= 0.05f;
        } else {
            //rig.velocity = new Vector2(2.0f * speed, 0);
        }
        Swipe();
        transform.position = position;
    }

    void Sliding(){
        GetComponent<BoxCollider>().size = SlidingColiderSize;//スライドしているときのColiderのサイズを代入している
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("sliding")) {//Animator.GetCurrentAnimatorStateInfo() 再生中のアニメーションの判定
            anim.Play("sliding");
        }
        rig.velocity = new Vector2(20.0f, 0);
    }

    void Swipe() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("start position : " + StartPos);
            StartPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("end position : " + EndPos);
            EndPos = Input.mousePosition;
        }
        //if (StartPos.x > EndPos.x) {
        //    rig.AddForce(new Vector2(-10.0f, 0));
        //} else if (StartPos.x < EndPos.x) {
        //    rig.AddForce(new Vector2(10.0f, 0));
        //}
        if (StartPos.y > EndPos.y) {
            Sliding();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "block" || collision.gameObject.tag == "Enemy") {
            jumpCnt = 0;
        }
    }
}
