using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用
using UnityEngine.SceneManagement;

public class VoiceTestScript : MonoBehaviour
{

    public DictationRecognizer dictationRecognizer;
    public string inputText;
    public string testText;
    Animator animVoiceInput;
    Animator animReticle;
    
    public GameObject textObject;
    public GameObject CameraObject;
   
    private float CameraAngleX, CameraAngleY;
    public Vector3 CameraPos;
    public float angle;
    public float bulletSpeed;
    [SerializeField]
    public float KotodamaPosY, KotodamaPosZ, KotodamaPosX;


    void Start()
    {

        dictationRecognizer = new DictationRecognizer();
        testText = "test";
        

        animVoiceInput = GameObject.Find("VoiceInput").gameObject.GetComponent<Animator>();
        animReticle = GameObject.Find("Reticle").gameObject.GetComponent<Animator>();
    }



    void Update()
    {
       

        if (Input.GetMouseButton(0))
        {
            if (dictationRecognizer.Status != SpeechSystemStatus.Running)
            {
                //ディクテーションを開始
                dictationRecognizer.Start();
                Debug.Log("音声認識開始");

                animVoiceInput.SetBool("MouseHold", true);
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
                    KotodamaPos(inputText);

                    textObject = FlyingText.GetObjects(inputText, CameraPos, Quaternion.identity);//FlyingTextを生成
                    textObject.name = inputText;
                    textObject.transform.Rotate(CameraAngleX, CameraAngleY + angle, 0);//PlayerControllerのY.rotateを参照
                    Rigidbody rigidbody = textObject.AddComponent<Rigidbody>();
                    Rigidbody[] rigidbodies = textObject.GetComponentsInChildren<Rigidbody>();

                    foreach (var TextChild in rigidbodies)
                    {
                        TextChild.useGravity = false;
                        TextChild.AddForce(textObject.transform.forward * bulletSpeed, ForceMode.Impulse);
                        TextChild.tag = "flyingText";
                    }


                    inputText = testText;
                    CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
                    if (atomSrc != null)
                    {
                        atomSrc.Play(9);

                    }

                   

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
                
            }

        }

        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;

    }
    private void KotodamaPos(string str1)
    {
        CameraPos = CameraObject.transform.position;//プレイヤーの位置を取得
        CameraPos.y += KotodamaPosY;
        CameraPos.x += KotodamaPosX;
        CameraAngleX = CameraObject.transform.localEulerAngles.x;
        CameraAngleY = CameraObject.transform.localEulerAngles.y;
        for (int i = 1; i < str1.Length; i++)
        {
            CameraPos.z -= KotodamaPosZ;
        }
    }
    

    //DictationResult：音声が特定の認識精度で認識されたときに発生するイベント
    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        animReticle.SetBool("VoiceInput", true);
        //音声認識アニメーション終了
        animReticle.SetBool("VoiceInput", false);
        Debug.Log("認識した音声：" + text);
        inputText = text;
    }

    //DictationHypothesis：音声入力中に発生するイベント
    private void DictationRecognizer_DictationHypothesis(string text)
    {
        //音声認識アニメーション再生
        //animReticle = GameObject.Find("Reticle").gameObject.GetComponent<Animator>();
        ///animReticle.SetBool("VoiceInput", true);
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

   

    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if (dictationRecognizer.Status != SpeechSystemStatus.Failed)
        {
            dictationRecognizer.Dispose();
        }
    }
}