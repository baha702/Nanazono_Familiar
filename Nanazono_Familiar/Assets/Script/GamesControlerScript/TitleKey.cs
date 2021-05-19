using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class TitleKey : MonoBehaviour
{
    //　タイトルキー
    [SerializeField]
    private GameObject Title;
    KotodamariScript kotodamariDictation;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            SceneManager.LoadScene("Start");
            

        }
    }
}