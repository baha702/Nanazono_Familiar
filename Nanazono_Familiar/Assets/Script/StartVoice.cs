using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartVoice : MonoBehaviour
{
    public GameObject FadePanel;
    FadeController fade;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fade = FadePanel.GetComponent<FadeController>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("当たってる");
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
        SceneManager.LoadScene("Tutorial");
    }
}
