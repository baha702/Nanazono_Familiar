using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//触れたものすべて吹き飛ばすやばいスクリプト
public class Attack : MonoBehaviour
{
    public GameObject _player;
    public string _earthTag;         //除外するタグの名前
    public float _forceHeight;       //吹き飛ばす高さ調整値
    public float _forcePower;        //吹き飛ばす強さ調整値

    //何かに触れたときに呼ばれる
    void OnTriggerEnter(Collider _collider)
    {
        //除外対象のタグがついたゲームオブジェクトだったら何もしない
        if (_earthTag == _collider.tag)
        {
            return;
        }
        //自分の体は除外
        if (_player && _player == _collider.gameObject)
        {
            return;
        }

        //攻撃状態じゃなかったら何もしない
       
        

            {

            //ぶつかった相手からRigitBodyを取り出す
            Rigidbody otherRigitbody = _collider.GetComponent<Rigidbody>();
            if (!otherRigitbody)
            {
                return;
            }

            //吹き飛ばす方向を求める(プレイヤーから触れたものの方向)
            Vector3 toVec = GetAngleVec(_player, _collider.gameObject);

            //Y方向を足す
            toVec = toVec + new Vector3(0, _forceHeight, 0);

            //ふきとべええ
            otherRigitbody.AddForce(toVec * _forcePower, ForceMode.Impulse);
        }


        Vector3 GetAngleVec(GameObject _from, GameObject _to)
        {
            //高さの概念を入れないベクトルを作る
            Vector3 fromVec = new Vector3(_from.transform.position.x, 0, _from.transform.position.z);
            Vector3 toVec = new Vector3(_to.transform.position.x, 0, _to.transform.position.z);

            return Vector3.Normalize(toVec - fromVec);
        }
    }
}
