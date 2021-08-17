using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtack : MonoBehaviour
{
    public GameObject PlayerObject;
    private GameObject enemytext;
    public GameObject Bossenemy;
    public Vector3 EnemyPos;
    public string inputText;
    [SerializeField]
    public float bulletSpeed;
    [SerializeField]
    public float KotodamaPosX, KotodamaPosY, KotodamaPosZ;
    KotodamariScript kotodamaScript;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 20.0f;
        KotodamaPosX = 15.0f;
        KotodamaPosY = 15.0f;
        KotodamaPosZ = 7.0f;
        kotodamaScript = PlayerObject.GetComponent<KotodamariScript>();
        FlyingText flyingtext = PlayerObject.GetComponent<FlyingText>();
        EnemyPos = Bossenemy.transform.position;//プレイヤーの位置を取得
        EnemyPos.x += KotodamaPosX;
        EnemyPos.y += KotodamaPosY;
        EnemyPos.z += KotodamaPosZ;
        for (int i = 1; i < inputText.Length; i++)
        {
            EnemyPos.z -= KotodamaPosZ;
        }
        this.gameObject.AddComponent<EnemyflyingText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            kotodamaScript.BossKotodama(inputText, EnemyPos);
        }
    }

    /*public void BossKotodama(string str1,Vector3 pos1)
    {
       
        enemytext = FlyingText.GetObjects(str1, pos1, Quaternion.identity);//FlyingTextを生成
        enemytext.name = "EnemyText";
        Rigidbody rigidbody = enemytext.AddComponent<Rigidbody>();
        Rigidbody[] rigidbodies = enemytext.GetComponentsInChildren<Rigidbody>();
        //textObject.transform.Rotate(CameraAngleX, CameraAngleY - 90, 0);//PlayerControllerのY.rotateを参照
        foreach (var TextChild in rigidbodies)
        {
            TextChild.useGravity = false;
            TextChild.AddForce(enemytext.transform.forward * bulletSpeed, ForceMode.Impulse);
            TextChild.tag = "flyingText";
        }
        enemytext.tag = "EnemyText";
        Destroy(enemytext, 10.0f);
    }
    private void KotodamaPos(string str1)
    {
        EnemyPos = Bossenemy.transform.position;//プレイヤーの位置を取得
        EnemyPos.y += KotodamaPosY;
        //CameraAngleX = CameraObject.transform.localEulerAngles.x;
        //CameraAngleY = CameraObject.transform.localEulerAngles.y;
        for (int i = 1; i < str1.Length; i++)
        {
            EnemyPos.z -= KotodamaPosZ;
        }
    }*/
}
