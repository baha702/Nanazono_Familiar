using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
    //　次に敵が出現するまでの時間
    [SerializeField] float appearNextTime;
    //　待ち時間計測フィールド
    private float elapsedTime;
    //通常湧き停止用bool
    private bool stopAppear;
    public int num;
    public bool debugbool;
    Entity_NameList es = null;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 20.0f;
        KotodamaPosX = 15.0f;
        KotodamaPosY = 15.0f;
        KotodamaPosZ = -7.0f;
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
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (debugbool ==true)
        {


            if (elapsedTime > appearNextTime && !stopAppear)
            {
                elapsedTime = 0f;
                num = Random.Range(0, 8);
                EnemyNameList(num);
                kotodamaScript.BossKotodama(inputText, EnemyPos);

            }
            //　経過時間を足す
            elapsedTime += Time.deltaTime;
        }
    }


    public void EnemyNameList(int number)
    {
        es = Resources.Load("NameList") as Entity_NameList;

        int num = Random.Range(0, 37);
        inputText = es.sheets[0].list[num].boss13;
        Debug.Log(inputText);

        /*switch (number)
        {
            case 1:
                inputText = "コワイ";
                break;
            case 2:
                inputText = "ワイコ";
                break;
            case 3:
                inputText = "イヤダ";
                break;
            case 4:
                inputText = "イダヤ";
                break;
            case 5:
                inputText = "ナンデ";
                break;
            case 6:
                inputText = "ンデナ";
                break;
            case 7:
                inputText = "キエタクナイ";
                break;
            case 8:
                inputText = "エナクイタキ";
                break;
           
        }*/
    }
}
