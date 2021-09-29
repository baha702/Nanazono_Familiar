using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StartVoice : MonoBehaviour
{
    string fileName = "tutorial.clear";
    public GameObject FadePanel;
    FadeController fade;
    Rigidbody rb;

    private void Start()
    {
        fade = FadePanel.GetComponent<FadeController>();
        rb = GetComponent<Rigidbody>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (GameObject.Find("スタート") != null || GameObject.Find("すたーと") != null)
        {
            rb.isKinematic = false;
            rb.AddForce(this.gameObject.transform.forward * 10.0f, ForceMode.Impulse);
            fade.isFadeOut = true;
            Invoke(nameof(FadeWait), 5.0f);
            Debug.Log("ゲームスタート");
        }
    }
    public void FadeWait()
    {
        fade.isFadeOut = true;
        if (File.Exists(fileName) == false)
        {
            SceneManager.LoadScene("Tutorial");
            Debug.Log("チュートリアルをクリアしてないよ");
        }
        else
        {
            SceneManager.LoadScene("StageChoice");
            Debug.Log("クリア済み！");
        }
    }
}
