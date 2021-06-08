using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用
using UnityEngine.SceneManagement;


public class KotodamariScript: MonoBehaviour
{

    public DictationRecognizer dictationRecognizer;

    private GameObject textObject;
    public GameObject PlayerObject;
    public GameObject CameraObject;
    public GameObject ChargeEffect;
    public GameObject ExprodeEffect;

    public Vector3 PlayerPos;
    private float CameraAngleX,CameraAngleY;

    [SerializeField]
    public float bulletSpeed;
    public Material textMaterial;
    public string inputText;
    public string testText;
    public string DebugText1, DebugText2;

    public bool flag;
    public bool iscalledOnce;
    public bool dictationflag;
    public bool debugKotodama = false;

    [SerializeField]
    public float KotodamaPosY,KotodamaPosZ;

    AudioSource audio;
    public AudioClip ATKClip;

    void Start()
    {
        bulletSpeed = 40.0f;
        bulletSpeed = 20.0f;
        flag = false;
        KotodamaPosY = 1.5f;
        KotodamaPosZ = 0.7f;

        iscalledOnce = false;

        dictationRecognizer = new DictationRecognizer();
        testText = "test";
        audio = GetComponent<AudioSource>();
    }

   

    void Update()
    {

        /*if (Input.GetMouseButton(0))
        {
            iscalledOnce = true;
            Debug.Log("左クリック");
        }*/
        if (Input.GetMouseButton(0))
        {
            if (dictationRecognizer.Status != SpeechSystemStatus.Running)
            {
               //ディクテーションを開始
               dictationRecognizer.Start();
                Debug.Log("音声認識開始");
            }
            
        }
            if (dictationRecognizer.Status == SpeechSystemStatus.Running)
            {


                dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;//DictationRecognizer_DictationResult処理を行う

                dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;//DictationRecognizer_DictationHypothesis処理を行う

                dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;//DictationRecognizer_DictationComplete処理を行う

                dictationRecognizer.DictationError += DictationRecognizer_DictationError;//DictationRecognizer_DictationError処理を行う

                if (inputText != testText)
                {
                    StartCoroutine("Coroutine");
                    KotodamaPos(inputText);
                    audio.PlayOneShot(ATKClip, 1.0f);
                    textObject = FlyingText.GetObjects(inputText, PlayerPos, Quaternion.identity);//FlyingTextを生成
                    textObject.name = "FlyingText";
                    Rigidbody rigidbody = textObject.AddComponent<Rigidbody>();
                    Rigidbody[] rigidbodies = textObject.GetComponentsInChildren<Rigidbody>();
                    textObject.transform.Rotate(CameraAngleX, CameraAngleY - 90, 0);//PlayerControllerのY.rotateを参照
                    foreach (var TextChild in rigidbodies)
                    {
                        TextChild.useGravity = false;
                        TextChild.AddForce(textObject.transform.forward * bulletSpeed, ForceMode.Impulse);
                        TextChild.tag = "flyingText";
                    }
                    textObject.tag = "flyingText";
                    Destroy(textObject, 10.0f);
                }
                inputText = testText;
            }
        
        if (Input.GetMouseButtonUp(0))
        {
            if (dictationRecognizer.Status != SpeechSystemStatus.Stopped)
            {
                Debug.Log("音声認識終了");
                dictationRecognizer.Stop();
            }
           
        }

        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;

        if (debugKotodama==true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DebugText(DebugText1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                DebugText(DebugText2);
            }
        }
    }

    private void KotodamaPos(string str1)
    {
        PlayerPos = PlayerObject.transform.position;//プレイヤーの位置を取得
        PlayerPos.y += KotodamaPosY;
        CameraAngleX = CameraObject.transform.localEulerAngles.x;
        CameraAngleY = CameraObject.transform.localEulerAngles.y;
        for(int i=1; i < str1.Length; i++)
        {
            PlayerPos.z -= KotodamaPosZ;
        }
    }
    private void DebugText(string str1)
    {
        KotodamaPos(str1);
        textObject = FlyingText.GetObjects(str1, PlayerPos, Quaternion.identity);//FlyingTextを生成
        textObject.name = "FlyingText";
        Rigidbody rigidbody = textObject.AddComponent<Rigidbody>();
        Rigidbody[] rigidbodies = textObject.GetComponentsInChildren<Rigidbody>();
        textObject.transform.Rotate(CameraAngleX, CameraAngleY-90, 0);//PlayerControllerのY.rotateを参照
        foreach (var TextChild in rigidbodies)
        {
            TextChild.useGravity = false;
            TextChild.AddForce(textObject.transform.forward * bulletSpeed, ForceMode.Impulse);
            TextChild.tag = "flyingText";
        }
        textObject.tag = "flyingText";
        Destroy(textObject, 10.0f);
    }

    //DictationResult：音声が特定の認識精度で認識されたときに発生するイベント
    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        ChargeEffect.gameObject.SetActive(false);
        ExprodeEffect.gameObject.SetActive(true);
        Debug.Log("認識した音声：" + text);
        inputText = text;
    }

    //DictationHypothesis：音声入力中に発生するイベント
    private void DictationRecognizer_DictationHypothesis(string text)
    {
        ChargeEffect.gameObject.SetActive(true);
        //Debug.Log("音声認識中：" + text);
    }

    //DictationComplete：音声認識セッションを終了したときにトリガされるイベント
    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        
        //Debug.Log("音声認識完了");
    }

    //DictationError：音声認識セッションにエラーが発生したときにトリガされるイベント
    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.Log("音声認識エラー");
    }

    private IEnumerator Coroutine()
    {
        //１秒待機
        yield return new WaitForSeconds(2.0f);

        if (ExprodeEffect.gameObject.activeSelf)
        {
            ExprodeEffect.gameObject.SetActive(false);
        }

        //コルーチンを終了
        yield break;
    }

    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if (dictationRecognizer.Status != SpeechSystemStatus.Failed)
        {
            dictationRecognizer.Dispose();
        }
    }
}