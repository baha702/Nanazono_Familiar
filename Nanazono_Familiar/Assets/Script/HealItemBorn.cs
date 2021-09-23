using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemBorn : MonoBehaviour
{
    public GameObject Apple;
    public GameObject ItemBorn;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = ItemBorn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("HealItem")==null)
        {
            Instantiate(Apple, pos,Quaternion.identity);
        }
    }
}
