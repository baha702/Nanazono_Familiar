using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveJudge : MonoBehaviour
{
        public GameObject enemyName1,enemyName3,enemyName4,enemyName5;
        public string enemystr1,enemystr3,enemystr4,enemystr5;
        public GameObject enemyName2;
        public string enemystr2;
        public int strLength;
        private int strFlag;

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

        private void OnCollisionEnter(Collision collision)
        {
            JudgeName(enemystr1, enemyName1);
            JudgeName(enemystr2, enemyName2);
            JudgeName(enemystr3, enemyName3);
            JudgeName(enemystr4, enemyName4);
            JudgeName(enemystr5, enemyName5);


        }
    }
