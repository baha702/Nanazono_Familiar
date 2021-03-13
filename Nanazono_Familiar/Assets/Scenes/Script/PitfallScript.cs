using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallScript : MonoBehaviour
{
    //落とし穴のオブジェクトを指定
    public GameObject Pitfall;
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        //Target = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Target"))
        {
            Target = GameObject.FindGameObjectWithTag("Target");
            Vector3 Targetpos = Target.transform.position;
            Targetpos.y -= 0.05f;
            Target.transform.position = Targetpos;
            Debug.Log("落とし穴の判定確認");
        }
    }
}
