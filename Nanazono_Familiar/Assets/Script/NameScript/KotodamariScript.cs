using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用
using UnityEngine.SceneManagement;


public class KotodamariScript: MonoBehaviour
{

    public DictationRecognizer dictationRecognizer;

    private GameObject textObject,enemytext;
    public GameObject PlayerObject;
    public GameObject CameraObject;
    public GameObject ChargeEffect;
    public GameObject ExprodeEffect;
    public GameObject MenuUI;
    public float angle;

    public Material redMaterial;

    public Vector3 PlayerPos;
    private float CameraAngleX,CameraAngleY;
    private float SlowTime = 1.0f;


    [SerializeField]
    public float bulletSpeed;
    public string inputText;
    public string testText;
    public string DebugText1, DebugText2, DebugText3;
    public bool debugKotodama = false;
    public bool efectbool = false;

    [SerializeField]
    public float KotodamaPosY,KotodamaPosZ;

    AudioSource audio;
    public AudioClip ATKClip;

    Animator animVoiceInput;
    Animator animReticle;

    void Start()
    {
        bulletSpeed = 20.0f;
        KotodamaPosY = 1.5f;
        KotodamaPosZ = 0.7f;

        dictationRecognizer = new DictationRecognizer();
        testText = "test";
        audio = GetComponent<AudioSource>();

        animVoiceInput = GameObject.Find("VoiceInput").gameObject.GetComponent<Animator>();
        animReticle = GameObject.Find("Reticle").gameObject.GetComponent<Animator>();
    }

   

    void Update()
    {
        //if (!MenuUI.activeSelf)
        //{

            if (Input.GetMouseButton(0))
            {
                if (dictationRecognizer.Status != SpeechSystemStatus.Running)
                {
                    //ディクテーションを開始
                    dictationRecognizer.Start();
                    Debug.Log("音声認識開始");
                    //ホールドアニメーション再生
                    //animVoiceInput = GameObject.Find("VoiceInput").gameObject.GetComponent<Animator>();
                    animVoiceInput.SetBool("MouseHold", true);

                    /*if (Time.timeScale==1.0f)
                    {
                       Time.timeScale = SlowTime;
                    }*/
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
                    /*if (Time.timeScale == SlowTime)
                    {
                       Time.timeScale = 1.0f;
                    }*/
                    StartCoroutine("Coroutine");
                    KotodamaPos(inputText);
                    audio.PlayOneShot(ATKClip, 1.0f);
                    textObject = FlyingText.GetObjects(inputText, PlayerPos, Quaternion.identity);//FlyingTextを生成
                    textObject.name = "FlyingText";
                    Rigidbody rigidbody = textObject.AddComponent<Rigidbody>();
                    Rigidbody[] rigidbodies = textObject.GetComponentsInChildren<Rigidbody>();

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
                    animVoiceInput.SetBool("MouseHold", false);
                    /*if (Time.timeScale == SlowTime)
                    {
                        Time.timeScale = 1.0f;
                    }*/
                }

            }
        //}

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
            if (Input.GetKeyDown(KeyCode.R))
            {
                DebugText(DebugText3);
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
        textObject.transform.Rotate(CameraAngleX, CameraAngleY+angle, 0);//PlayerControllerのY.rotateを参照
        foreach (var TextChild in rigidbodies)
        {
            TextChild.useGravity = false;
            TextChild.AddForce(textObject.transform.forward * bulletSpeed, ForceMode.Impulse);
            TextChild.tag = "flyingText";
        }
        textObject.tag = "flyingText";
        Destroy(textObject, 10.0f);
    }

    public void BossKotodama(string str1, Vector3 pos1,float bulletnum)
    {
        //enemytext = FlyingText.GetObjects(str1, pos1, Quaternion.identity);//FlyingTextを生成
        enemytext = FlyingText.GetObjects(str1, redMaterial, null, 10.0f, 2.0f, 5, pos1, Quaternion.identity);//FlyingTextを生成
        enemytext.name = "EnemyText";
        Rigidbody rigidbody = enemytext.AddComponent<Rigidbody>();
        Rigidbody[] rigidbodies = enemytext.GetComponentsInChildren<Rigidbody>();
        enemytext.transform.Rotate(12, +angle, 0);//PlayerControllerのY.rotateを参照
        foreach (var TextChild in rigidbodies)
        {
            TextChild.useGravity = false;
            TextChild.AddForce(enemytext.transform.forward * bulletnum, ForceMode.Impulse);
            TextChild.tag = "EnemyText";
            //TextChild.gameObject.AddComponent<EnemyflyingText>();
        }
        enemytext.tag = "EnemyText";
        //enemytext.AddComponent<EnemyflyingText>();
        Destroy(enemytext, 10.0f);
    }

    //DictationResult：音声が特定の認識精度で認識されたときに発生するイベント
    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        //音声認識アニメーション終了
        animReticle.SetBool("VoiceInput", false);
        if (efectbool)
        {
            //チャージエフェクト終了
            //ChargeEffect.gameObject.SetActive(false);
            //爆発エフェクト再生
            //ExprodeEffect.gameObject.SetActive(true);
        }
        Debug.Log("認識した音声：" + text);
        inputText = text;
    }

    //DictationHypothesis：音声入力中に発生するイベント
    private void DictationRecognizer_DictationHypothesis(string text)
    {
        //音声認識アニメーション再生
        //animReticle = GameObject.Find("Reticle").gameObject.GetComponent<Animator>();
        animReticle.SetBool("VoiceInput", true);
        if (efectbool)
        {
            //チャージエフェクト再生
            //ChargeEffect.gameObject.SetActive(true);
        }
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

        if (efectbool)
        {
            //爆発エフェクト終了
            /*if (ExprodeEffect.gameObject.activeSelf)
            {
                ExprodeEffect.gameObject.SetActive(false);
            }*/
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