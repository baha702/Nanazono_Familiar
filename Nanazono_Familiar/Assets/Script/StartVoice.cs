using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartVoice : MonoBehaviour
{
    public GameObject FadePanel;
    FadeController fade;

    private void Start()
    {
        fade = FadePanel.GetComponent<FadeController>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameObject.Find("スタート")||collision.gameObject == GameObject.Find("すたーと"))
        {

            fade.isFadeOut = true;
            Invoke(nameof(FadeWait), 5.0f);
            Debug.Log("ゲームスタート");
        }
    }
    public void FadeWait()
    {
        fade.isFadeOut = true;
        SceneManager.LoadScene("Tutorial");
    }
}
