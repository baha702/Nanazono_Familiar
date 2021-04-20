using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用


public class KotodamariScript: MonoBehaviour
{

    DictationRecognizer dictationRecognizer;
    private GameObject textObject;
    public GameObject PlayerObject;
    public GameObject CameraObject;
    GameObject DestroyFlyObject;

    public Vector3 PlayerPos;
    private float PlayerAngleX,PlayerAngleY;

    [SerializeField]
    public float bulletSpeed;
    public Material textMaterial;
    public string inputText;
    public string testText;

    public bool flag;
    private bool iscalledOnce;
    public bool Levenflag;
    [SerializeField]
    public float KotodamaPosX,KotodamaPosY;
    EffectController effect;

    void Start()
    {
        bulletSpeed = 40.0f;
        flag = false;
        KotodamaPosX = 0.5f;
        KotodamaPosY = 1.5f;

        dictationRecognizer = new DictationRecognizer();

        //ディクテーションを開始
        dictationRecognizer.Start();
        Debug.Log("音声認識開始");

        testText = "test";
    }

   

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            iscalledOnce = true;
            
        }
            if (iscalledOnce == true)
            {
                

                dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;//DictationRecognizer_DictationResult処理を行う

                dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;//DictationRecognizer_DictationHypothesis処理を行う

                dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;//DictationRecognizer_DictationComplete処理を行う

                dictationRecognizer.DictationError += DictationRecognizer_DictationError;//DictationRecognizer_DictationError処理を行う

                if (inputText != testText)
                {
                    
                    KotodamaPos();
                    textObject = FlyingText.GetObjects(inputText, PlayerPos, Quaternion.identity);//FlyingTextを生成
                    textObject.name = "FlyingText";
                    Rigidbody rigidbody = textObject.AddComponent<Rigidbody>();
                    Rigidbody[] rigidbodies = textObject.GetComponentsInChildren<Rigidbody>();
                    textObject.transform.Rotate(0, PlayerAngleY, 0);//PlayerControllerのY.rotateを参照
                    foreach (var TextChild in rigidbodies)
                    {
                        TextChild.useGravity = false;
                        TextChild.AddForce(textObject.transform.forward * bulletSpeed, ForceMode.Impulse);
                        TextChild.tag = "flyingText";
                    }
                    textObject.tag = "flyingText";

                    
                    Levenflag = true;

                }
                inputText = testText;
            }

        if (Input.GetMouseButton(1))
        {
            iscalledOnce = false;  
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPos = PlayerObject.transform.position;//プレイヤーの位置を取得
            PlayerPos.z -= KotodamaPosX;
            PlayerPos.y += KotodamaPosY;
            PlayerAngleX = PlayerObject.transform.localEulerAngles.x;
            PlayerAngleY = PlayerObject.transform.localEulerAngles.y;
            textObject = FlyingText.GetObjects("トマ", PlayerPos, Quaternion.identity);//FlyingTextを生成
            textObject.name = "FlyingText";
            Rigidbody rigidbody = textObject.AddComponent<Rigidbody>();
            Rigidbody[] rigidbodies = textObject.GetComponentsInChildren<Rigidbody>();
            textObject.transform.Rotate(0, PlayerAngleY, 0);//PlayerControllerのY.rotateを参照
            foreach (var TextChild in rigidbodies)
            {
                TextChild.useGravity = false;
                TextChild.AddForce(textObject.transform.forward * bulletSpeed, ForceMode.Impulse);
                TextChild.tag = "flyingText";
            }
            textObject.tag = "flyingText";
            DestroyFlyObject = textObject;
            StartCoroutine("Coroutine");

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPos = PlayerObject.transform.position;//プレイヤーの位置を取得
            PlayerPos.z -= KotodamaPosX;
            PlayerPos.y += KotodamaPosY;
            PlayerAngleX = PlayerObject.transform.localEulerAngles.x;
            PlayerAngleY = PlayerObject.transform.localEulerAngles.y;
            textObject = FlyingText.GetObjects("ムニエル", PlayerPos, Quaternion.identity);//FlyingTextを生成
            textObject.name = "FlyingText";
            Rigidbody rigidbody = textObject.AddComponent<Rigidbody>();
            Rigidbody[] rigidbodies = textObject.GetComponentsInChildren<Rigidbody>();
            textObject.transform.Rotate(0, PlayerAngleY, 0);//PlayerControllerのY.rotateを参照
            foreach (var TextChild in rigidbodies)
            {
                TextChild.useGravity = false;
                TextChild.AddForce(textObject.transform.forward * bulletSpeed, ForceMode.Impulse);
                TextChild.tag = "flyingText";
                
            }
            textObject.tag = "flyingText";

            StartCoroutine("Coroutine");
        }
        
    }

    private void KotodamaPos()
    {
        PlayerPos = PlayerObject.transform.position;//プレイヤーの位置を取得
        PlayerPos.y += KotodamaPosY;
        PlayerAngleX = PlayerObject.transform.localEulerAngles.x;
        PlayerAngleY = PlayerObject.transform.localEulerAngles.y;
        for(int i=1; i < inputText.Length; i++)
        {
            Debug.Log(inputText.Length);
            PlayerPos.z -= KotodamaPosX;
        }
    }
    private IEnumerator Coroutine()
    {
        //１秒待機
        yield return new WaitForSeconds(10.0f);

        Destroy(GameObject.FindGameObjectWithTag("flyingText").gameObject);
        Destroy(DestroyFlyObject.gameObject);

        //コルーチンを終了
        yield break;
    }

    //DictationResult：音声が特定の認識精度で認識されたときに発生するイベント
    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        Debug.Log("認識した音声：" + text);
        inputText = text;
        

    }

    //DictationHypothesis：音声入力中に発生するイベント
    private void DictationRecognizer_DictationHypothesis(string text)
    {
        //Debug.Log("音声認識中：" + text);
    }

    //DictationComplete：音声認識セッションを終了したときにトリガされるイベント
    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        Debug.Log("音声認識完了");
    }

    //DictationError：音声認識セッションにエラーが発生したときにトリガされるイベント
    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.Log("音声認識エラー");
    }


}