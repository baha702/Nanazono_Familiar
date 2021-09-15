using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    
    public string ThisSceneName;

    void Update()
    {
        if (SceneManager.GetActiveScene().name != ThisSceneName)
        { 
            Destroy(this.gameObject);
        }
        
    }
}
