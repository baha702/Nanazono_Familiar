using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用


public class KotodamariScript: MonoBehaviour
{

    DictationRecognizer dictationRecognizer;
    public GameObject textObject;
    public GameObject PlayerObject;
    public GameObject CameraObject;

    public Vector3 PlayerPos;
    public float CameraPos;

    [SerializeField]
    public float bulletSpeed;
    public Material textMaterial;
    public string inputText;
    public string testText;

    public bool flag;
    public bool Levenflag;
    [SerializeField]
    public float KotodamaPos;

    void Start()
    {
        bulletSpeed = 30.0f;
        flag = false;
        KotodamaPos = 1.0f;
        
        dictationRecognizer = new DictationRecognizer();

        //ディクテーションを開始
        dictationRecognizer.Start();
        Debug.Log("音声認識開始");

        testText = "test";
        //textObject = FlyingText.GetObject("スタート", new Vector3(-3, 5, 4), Quaternion.identity);


    }

   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flag = true;
            Debug.Log("音声認識スタート");
        }
        if (Input.GetMouseButtonDown(1))
        {
            flag = false;
            Debug.Log("音声認識フィニッシュ");
        }


        if (flag == true)
        {
            dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;//DictationRecognizer_DictationResult処理を行う

            dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;//DictationRecognizer_DictationHypothesis処理を行う

            dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;//DictationRecognizer_DictationComplete処理を行う

            dictationRecognizer.DictationError += DictationRecognizer_DictationError;//DictationRecognizer_DictationError処理を行う

            if (inputText != testText)
            {
                PlayerPos = PlayerObject.transform.position;//プレイヤーの位置を取得
                PlayerPos.x -= KotodamaPos;
                PlayerPos.y += KotodamaPos;
                CameraPos = CameraObject.transform.localEulerAngles.y;
                textObject = FlyingText.GetObject(inputText, PlayerPos, Quaternion.identity) ;//FlyingTextを生成
                //textObject.transform.Rotate(0, 180, 0) ;//PlayerControllerのX.rotateを参照
                textObject.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
                textObject.tag = "flyingText";
                Levenflag = true;

            }
            inputText = testText;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            PlayerPos = PlayerObject.transform.position;//プレイヤーの位置を取得
            PlayerPos.x += KotodamaPos;
            PlayerPos.y += KotodamaPos;
            CameraPos=CameraObject.transform.localEulerAngles.y;
            textObject = FlyingText.GetObject("QQQQQQ", PlayerPos, Quaternion.identity);//FlyingTextを生成
            textObject.transform.Rotate(0, CameraPos, 0);//PlayerControllerのX.rotateを参照
            textObject.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            textObject.tag = "flyingText";
        }
        
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