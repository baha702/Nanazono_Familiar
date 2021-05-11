using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FiveJudge : MonoBehaviour
{
         //public GameObject enemyName1, enemyName2,enemyName3, enemyName4,enemyName5;
        public string enemystr1, enemystr2,enemystr3, enemystr4,enemystr5;
        public int strLength;
        private int strFlag;
        public TextMeshProUGUI TMPstr1, TMPstr2,TMPstr3,TMPstr4,TMPstr5;
        public Material blueMaterial;
        bool OnceCall1, OnceCall2,OnceCall3,OnceCall4,OnceCall5;

    // Start is called before the first frame update
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            /*if (Destroyflag1==true && Destroyflag2==true)
            {
                StartCoroutine("Coroutine");
            }*/
            if (strFlag >= strLength)
            {
                StartCoroutine("Coroutine"); 
            
        }
        }


        private IEnumerator Coroutine()
        {
            //１秒待機
            yield return new WaitForSeconds(2.0f);
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            TMPstr1.text = string.Format(enemystr1);
            TMPstr2.text = string.Format(enemystr2);
            TMPstr3.text = string.Format(enemystr3);
            TMPstr4.text = string.Format(enemystr4);
            TMPstr5.text = string.Format(enemystr5);
            

        //コルーチンを終了
        yield break;
        }

        private void JudgeName(string str1, GameObject enemyObject)
        {
            if (GameObject.Find("FlyingText") != null)
            {
                GameObject JudgeText = GameObject.Find("FlyingText");
                if (GameObject.Find(str1) != null)
                {
                    GameObject childA = JudgeText.transform.Find(str1).gameObject;//FlyingTextの子の「ト」という名前のオブジェクトを探して変数childAに入れる
                    childA.GetComponent<BoxCollider>().isTrigger = true;
                    Debug.Log(str1);
                    Destroy(enemyObject);
                    //enemyObject.gameObject.SetActive(true);
                    strFlag++;
                }
            }
        }
    private void TextMeshJudge(string str1,string str2,string str3,string str4,string str5)
    {
        if (GameObject.Find("FlyingText") != null)
        {
            GameObject JudgeText = GameObject.Find("FlyingText");
            if (GameObject.Find(str1) != null)
            {
                TMPstr1.text = string.Format(str1);
                TMPstr1.fontSharedMaterial = blueMaterial;
                if (OnceCall1 == false)
                {
                    strFlag++;
                    OnceCall1 = true;
                }

            }
            if (GameObject.Find(str2) != null)
            {
                TMPstr2.text = string.Format(str2);
                TMPstr2.fontSharedMaterial = blueMaterial;
                if (OnceCall2 == false)
                {
                    strFlag++;
                    OnceCall2 = true;
                }
            }
            if (GameObject.Find(str3) != null)
            {
                TMPstr3.text = string.Format(str3);
                TMPstr3.fontSharedMaterial = blueMaterial;
                if (OnceCall3 == false)
                {
                    strFlag++;
                    OnceCall3 = true;
                }

            }
            if (GameObject.Find(str4) != null)
            {
                TMPstr4.text = string.Format(str4);
                TMPstr4.fontSharedMaterial = blueMaterial;
                if (OnceCall4 == false)
                {
                    strFlag++;
                    OnceCall4 = true;
                }
            }
            if (GameObject.Find(str5) != null)
            {
                TMPstr5.text = string.Format(str5);
                TMPstr5.fontSharedMaterial = blueMaterial;
                if (OnceCall5 == false)
                {
                    strFlag++;
                    OnceCall5 = true;
                }

            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
        {
        TextMeshJudge(enemystr1, enemystr2, enemystr3, enemystr4, enemystr5);
            /*JudgeName(enemystr1, enemyName1);
            JudgeName(enemystr2, enemyName2);
            JudgeName(enemystr3, enemyName3);
            JudgeName(enemystr4, enemyName4);
            JudgeName(enemystr5, enemyName5);*/


        }
    }
