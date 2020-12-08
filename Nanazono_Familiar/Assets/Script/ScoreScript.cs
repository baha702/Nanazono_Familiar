using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public int score_num = 0; // スコア変数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "Jem:" + score_num;
    }

    private void OnTriggerEnter(Collider col)
    {
        //"Jem"のTagのついたオブジェクトを判定
        if (col.tag == "Jem")
        {
            score_num += 100; // とりあえず100加算する

            // アイテムを消す
            Destroy(col.gameObject);
            //当たり判定の確認
            Debug.Log("ジェム確認");
        }
    }

}
