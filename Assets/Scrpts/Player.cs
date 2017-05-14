using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Camera mainCamera,rightCamera,leftCamera;
    GameObject mainCameraObj,rightCameraObj,leftCameraObj;
    Rigidbody rig;
    public Vector2 position;
    public Vector2 offset;
    // Use this for initialization
    void Start() {
        rig = GetComponent<Rigidbody>();
        mainCameraObj = GameObject.Find("Main Camera");
        rightCameraObj = GameObject.Find("Right Camera");
        leftCameraObj = GameObject.Find("Left Camera");

        mainCamera =mainCameraObj.GetComponent<Camera>();
        rightCamera = rightCameraObj.GetComponent<Camera>();
        leftCamera = leftCameraObj.GetComponent<Camera>();
        //rig = GetComponent<Rigidbody>();

        offset = mainCamera.transform.position - transform.position;
    }

    void LateUpdate() {
        GameObject curentCamera = mainCameraObj;
        if (mainCamera.enabled == true) {
            curentCamera = mainCameraObj;
        }
        else if (leftCamera.enabled == true) {
            curentCamera = leftCameraObj;
        }
        else if (rightCamera.enabled == true) {
            curentCamera = rightCameraObj;
        }


        Vector3 newPosition = curentCamera.transform.position;
        newPosition.x = transform.position.x + offset.x+3;
        newPosition.y = 0;
        curentCamera.transform.position = newPosition;
    }

    // Update is called once per frame
    void Update() {
        CameraMove();

        position = transform.position;
        if (Input.GetKeyDown(KeyCode.Space)) {
            rig.AddForce(new Vector2(0.0f, 400.0f));
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            position.x += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            //offset = rightCameraObj.transform.position - transform.position;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            //offset = leftCameraObj.transform.position - transform.position;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            //rig.AddForce(new Vector2(-10.0f, 0.0f));
            position.x -= 0.1f;
        }
        transform.position = position;
    }

    void CameraMove() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            Debug.Log("right");
            mainCamera.enabled = false;
            leftCamera.enabled = false;
            rightCamera.enabled = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            Debug.Log("left");
            mainCamera.enabled = false;
            rightCamera.enabled = false;
            leftCamera.enabled = true;
        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
            rightCamera.enabled = false;
            leftCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}
