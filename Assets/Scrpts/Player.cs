using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Camera mainCamera, rightCamera, leftCamera;
    GameObject mainCameraObj, rightCameraObj, leftCameraObj;
    Rigidbody rig;
    public Vector2 position;
    public Vector2 offset;
    public float speed;

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
        //rightCamera = rightCameraObj.GetComponent<Camera>();
        //leftCamera = leftCameraObj.GetComponent<Camera>();
        //rig = GetComponent<Rigidbody>();

        offset = mainCamera.transform.position - transform.position;
        speed = 1.0f;
    }

    void LateUpdate() {
        speed += 0.005f;
        //Debug.Log(speed);
        speed = Mathf.Clamp(speed, 0.0f, 10.0f);
        //GameObject curentCamera = mainCameraObj;
        //Vector3 newPosition = curentCamera.transform.position;

        //newPosition.x = transform.position.x + offset.x;
        //newPosition.y = transform.position.y + 2.0f;

        /*
        if (mainCamera.enabled == true) {
            curentCamera = mainCameraObj;
            newPosition.x = transform.position.x;
        }
        else if (leftCamera.enabled == true) {
            curentCamera = leftCameraObj;
            newPosition.x = transform.position.x-6;

        }
        else if (rightCamera.enabled == true) {
            curentCamera = rightCameraObj;
            newPosition.x = transform.position.x+6;
        }

        curentCamera.transform.position = newPosition;
        */
    }

    // Update is called once per frame
    void Update() {
        position = transform.position;
        if ((Input.GetKeyDown(KeyCode.Space) || key.IsKey("Jump")) && transform.position.y <= 0.5) {
            rig.AddForce(new Vector2(0.0f, 5000.0f));
        }
        if (Input.GetKey(KeyCode.RightArrow) || key.IsKey("Right")) {
            position.x += 0.1f * speed;
            speed += 0.05f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || key.IsKey("Left")) {
            position.x -= 0.1f * speed;
            speed -= 0.05f;
        } else {
            //position.x += 0.1f * speed;
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
}
