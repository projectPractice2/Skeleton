using UnityEngine;

/// <summary>
/// ジェネリックを隠すために継承してしまう
/// [System.Serializable]を書くのを忘れない
/// </summary>
[System.Serializable]
public class EnemyTable : Serialize.TableBase<string, GameObject, EnemyPair> {
}

/// <summary>
/// ジェネリックを隠すために継承してしまう
/// [System.Serializable]を書くのを忘れない
/// </summary>
/// 
[System.Serializable]
public class EnemyPair : Serialize.KeyAndValue<string, GameObject> {
    public EnemyPair(string key, GameObject value) : base(key, value) {
    }
}

public class EnemyController : MonoBehaviour {
    int cnt = 0;

    [SerializeField]
    EnemyTable enemyDict;



    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //if (cnt % 2 == 0) {
            EncountEnemy();
        EncountEnemy();
        EncountEnemy();
        //}
        cnt++;
    }
    void EncountEnemy() {
        var obj = Instantiate(enemyDict.GetTable()["Enemy"], new Vector2(90.0f, 6.5f), Quaternion.identity);
        obj.GetComponent<Rigidbody>().velocity = new Vector2(-20.0f, 0);
    }
}
