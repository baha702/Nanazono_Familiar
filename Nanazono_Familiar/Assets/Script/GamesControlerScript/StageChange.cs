using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageChange : MonoBehaviour
{
    public GameObject CameraObject;
    public GameObject DayText;
    public GameObject LeftButtonObject;
    public GameObject RightButtonObject;
    Text text;
    float CameraAngle;
    bool Tutorialbool;
    public DictationRecognizer dictationRecognizer;
    public string inputText;
    public string testText;
    Animator animVoiceInput;
    Animator animReticle;

    void Start()
    {
        CameraAngle = CameraObject.transform.localEulerAngles.y;
        Debug.Log(CameraAngle);

        dictationRecognizer = new DictationRecognizer();
        testText = "test";

        text = DayText.GetComponent<Text>();

        animVoiceInput = GameObject.Find("VoiceInput").gameObject.GetComponent<Animator>();
        animReticle = GameObject.Find("Reticle").gameObject.GetComponent<Animator>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }



    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            animVoiceInput = GameObject.Find("VoiceInput").gameObject.GetComponent<Animator>();
            animReticle = GameObject.Find("Reticle").gameObject.GetComponent<Animator>();
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
                animReticle.SetBool("VoiceInput", false);
            }
            //チュートリアルシーン切り替え
            if (CameraAngle == 270 || LeftButtonObject.activeSelf)
            {
                if (inputText == "スタート" || inputText == "Start")
                {
                    SceneManager.LoadScene("Tutorial");
                    Debug.Log("チュートリアルスタート");
                }
            }
                //ステージ１へシーン切り替え
                if (CameraAngle == 270 )
                {
                    
                    if (inputText == "スタート" || inputText == "Start")
                    {
                        SceneManager.LoadScene("Stage01");
                        Debug.Log("ステージ１スタート");
                    }
                }
                //ステージ２へシーン切り替え
                if (360 == CameraAngle || CameraAngle == 0)
                {
                    
                    if (inputText == "スタート" || inputText == "Start")
                    {
                         SceneManager.LoadScene("Stage02");
                         Debug.Log("ステージ２スタート");
                    }
                }
                //ステージ３へシーン切り替え
                if (CameraAngle == 90)
                {
                    
                    if (inputText == "スタート" || inputText == "Start")
                    {
                        //SceneManager.LoadScene("Stage02");
                        Debug.Log("ステージ２スタート");
                    }
                }
                //ステージ４へシーン切り替え
                if (CameraAngle == 180)
                {
                   
                    if (inputText == "スタート" || inputText == "Start")
                    {
                        //SceneManager.LoadScene("Stage02");
                        Debug.Log("ステージ２スタート");
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

   
    public void LeftButton()
    {
        if (CameraAngle == 270 )
        {
            text.fontSize = 54;
            text.text = "チュートリアル";
            Tutorialbool = true;
            LeftButtonObject.SetActive(false);
        }
        else
        {
            CameraObject.transform.Rotate(0, -90, 0);
            Debug.Log("カメラ角度＝" + CameraAngle);
        }
        CameraAngle = CameraObject.transform.localEulerAngles.y;
        //ステージ１へシーン切り替え
        if (CameraAngle == 270 && LeftButtonObject.activeSelf)
        {
            text.fontSize = 65;
            text.text = "１日目";
        }
        //ステージ２へシーン切り替え
        if (360 == CameraAngle || CameraAngle == 0)
        {
            text.fontSize = 65;
            text.text = "２日目";
        }
        //ステージ３へシーン切り替え
        if (CameraAngle == 90)
        {
            text.fontSize = 65;
            text.text = "３日目";
        }
        //ステージ４へシーン切り替え
        if (CameraAngle == 180)
        {
            text.fontSize = 65;
            text.text = "４日目";
            
        }
        if (!RightButtonObject.activeSelf)
        {
            RightButtonObject.SetActive(true);
        }
        CameraAngle = CameraObject.transform.localEulerAngles.y;
    }

    

    public void RightButton()
    {
        if (LeftButtonObject.activeSelf)
        {
            CameraObject.transform.Rotate(0, 90, 0);
        }
        CameraAngle = CameraObject.transform.localEulerAngles.y;
        //ステージ１へシーン切り替え
        if (CameraAngle == 270 || LeftButtonObject.activeSelf)
        {
            text.fontSize = 65;
            text.text = "１日目";
        }
        //ステージ２へシーン切り替え
        if (360 == CameraAngle || CameraAngle == 0)
        {
            text.fontSize = 65;
            text.text = "２日目";
        }
        //ステージ３へシーン切り替え
        if (CameraAngle == 90)
        {
            text.fontSize = 65;
            text.text = "３日目";
        }
        //ステージ４へシーン切り替え
        if (CameraAngle == 180)
        {
            text.fontSize = 65;
            text.text = "４日目";
            RightButtonObject.SetActive(false);
        }
        Debug.Log("カメラ角度＝" + CameraAngle);
        if (!LeftButtonObject.activeSelf)
        {
            LeftButtonObject.SetActive(true);
            Tutorialbool = false;
        }
    }


    //DictationResult：音声が特定の認識精度で認識されたときに発生するイベント
    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        animReticle.SetBool("VoiceInput", true);
        //音声認識アニメーション終了
        ///animReticle.SetBool("VoiceInput", false);
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
