using UnityEngine;

public class Enemy : MonoBehaviour {
    int attack, hp;
    float speed = 0.5f;
    Vector2 position;
    StageController stageController;

    Rigidbody rig;

    // Use this for initialization
    void Start() {
        stageController = GameObject.Find("StageController").GetComponent<StageController>();
        position = transform.position;
        rig = GetComponent<Rigidbody>();
        //rig.velocity = new Vector3(-20f, 0);
    }

    // Update is called once per frame
    void Update() {
        rig.AddForce(new Vector2(-20.0f * speed, 0));
        AA();
    }

    void Move() {

    }

    void AA() {
        int x = Mathf.FloorToInt(transform.position.x);
        int y = Mathf.FloorToInt(transform.position.y);
        if (x <= 0 || x > 94 || y < 0 || y >= 30) {
            Destroy(gameObject);
        }
        //        Debug.Log("x : " + x + " , y : " + y);
        //Debug.Log("stageData:"+stageController.stageData[y + 1][x - 1]);
        if (stageController.stageData[y][x - 1] == 9 && x != 0) {
            rig.AddForce(new Vector2(0, 300f));
        }
    }

    public void Create(int attack, int hp) {
        this.attack = attack;
        this.hp = hp;
    }
}