using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {
    GameObject mainCameraObj;
    Camera mainCamera;

    Player player;

    Key key;

    float x,y;
    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();
        key = GameObject.Find("Key").GetComponent<Key>();
        mainCameraObj = GameObject.Find("Main Camera");
        mainCamera = mainCameraObj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        //Debug.Log(pos);

        if (Input.GetKey(KeyCode.RightArrow) || key.IsKey("Right")) {
            x = 6;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || key.IsKey("Left")) {
            x = -6;
        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && (!key.IsKey("Right") && !key.IsKey("Left"))) {
            x = 0;
        }

        pos.x = player.transform.position.x+x;
        pos.y = player.transform.position.y+y;
        transform.position = pos;
    }
}
