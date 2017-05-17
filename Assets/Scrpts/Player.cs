using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Camera mainCamera,rightCamera,leftCamera;
    GameObject mainCameraObj,rightCameraObj,leftCameraObj;
    Rigidbody rig;
    public Vector2 position;
    public Vector2 offset;
    public float speed;
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
        speed = 1.0f;
    }

    void LateUpdate() {
        speed += 0.005f;
        Debug.Log(speed);
        speed = Mathf.Clamp(speed, 0.0f, 10.0f);
        GameObject curentCamera = mainCameraObj;
        Vector3 newPosition = curentCamera.transform.position;

        newPosition.x = transform.position.x + offset.x + 3;
        newPosition.y = transform.position.y;

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
    }

    // Update is called once per frame
    void Update() {
        CameraMove();

        position = transform.position;
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y<=0.5) {
            rig.AddForce(new Vector2(0.0f, 5000.0f));
        }
        //if (Input.GetKey(KeyCode.RightArrow)) {
        //position.x += 0.1f*speed;
        //}
        if (Input.GetKey(KeyCode.LeftArrow)) {
            position.x -= 0.1f*speed;

            speed -=0.05f;
        }else{
            position.x += 0.1f * speed;
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
