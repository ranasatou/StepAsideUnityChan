using System.Collections;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    // carPrefabを入れる
    public GameObject carPrefab;
    // coinPrefabを入れる
    public GameObject coinPrefab;
    // conePrefabを入れる
    public GameObject conePrefab;
    // スタート地点
    //private int starPos = -160;
    // ゴール地点
    //private int goalPos = 120;
    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // Unityちゃんを呼ぶ
    private GameObject unitychan;
    // 最後にアイテムを生成したUnityちゃんのZ座標
    private float LastItemPosition = -160;

    // Use this for initialization
    void Start() {

        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update() {

        // z座標にアクセスする
        float offset = unitychan.transform.position.z + 40.0f;

            // 最後にアイテムを生成したZ座標と現在の座標が15.0を超えるとアイテムを生成
            if (offset - LastItemPosition > 15.0f) {
                LastItemPosition = offset;
                // どのアイテムを出すのかランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2) {
                    // コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f) {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, offset);
                    }
                }
                else {
                    // レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++) {
                        // アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        // アイテムを置くz座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        // 60%コイン配置：30%車配置：10%何もなし
                        if (1 <= item && item <= 6) {
                            // コインを育成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, offsetZ + offset);
                        }
                        else if (7 <= item && item <= 9) {
                            // 車を育成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, offsetZ + offset);
                        }
                    }
                }
            }
    }
}


