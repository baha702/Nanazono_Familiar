using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用


public class KotodamariScript: MonoBehaviour
{

    DictationRecognizer dictationRecognizer;
    public GameObject textObject;
    public Material textMaterial;
    public string inputText;
    public string testText;

    void Start()
    {
        dictationRecognizer = new DictationRecognizer();

        //ディクテーションを開始
        dictationRecognizer.Start();
        Debug.Log("音声認識開始");

        testText = "test";
        textObject = FlyingText.GetObject("スタート", new Vector3(-3, 5, 4), Quaternion.identity);

    }

    void Update()
    {

        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;//DictationRecognizer_DictationResult処理を行う

        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;//DictationRecognizer_DictationHypothesis処理を行う

        dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;//DictationRecognizer_DictationComplete処理を行う

        dictationRecognizer.DictationError += DictationRecognizer_DictationError;//DictationRecognizer_DictationError処理を行う

        if (inputText != testText)
        {
            Vector3 random = new Vector3(Random.Range(-12.0f, 6.0f), 4, Random.Range(1.6f, 6.0f));
            textObject = FlyingText.GetObject(inputText, random, Quaternion.identity);
        }
        inputText = testText;

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
        Debug.Log("音声認識中：" + text);
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