using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaterialOffset : MonoBehaviour
{
    public Material mat;                        //動かしたいTextMeshProのMaterial。
    public float speed = -0.001f;               //動かすスピード。
    Vector2 offset = new Vector2(0.0f, 0.0f);

    void Start()
    {
        mat.SetTextureOffset("_FaceTex", offset);
    }
    
    void Update()
    {
        offset.y += speed;
        mat.SetTextureOffset("_FaceTex", offset);
        if(offset.y < -1.0f)
        {
            offset.y = 0.0f;
        }
    }
}
