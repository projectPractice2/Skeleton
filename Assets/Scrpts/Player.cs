using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Rigidbody rig;
    public Vector2 position;
    // Use this for initialization
    void Start() {
        //rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        position = transform.position;
        if (Input.GetKeyDown(KeyCode.Space)) {
            rig.AddForce(new Vector2(0.0f, 200.0f));
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            position.x += 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            //rig.AddForce(new Vector2(-10.0f, 0.0f));
            position.x -= 0.1f;
        }
        transform.position = position;

    }
}
