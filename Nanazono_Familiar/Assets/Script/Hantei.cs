using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hantei : MonoBehaviour
{
    public GameObject Jem;
    //public Transform enemypos;//敵の位置を取得するためのTransform型の変数
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider col)
    {
        //"Player"のTagのついたオブジェクトを判定
        if (col.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Jem, this.transform.position, Quaternion.identity);
            }


            //当たり判定の確認
            Debug.Log("死角確認");
        }
    }
}
