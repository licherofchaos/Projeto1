using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {

    }

    public void NextScene()
    {
        SceneManager.LoadScene("SampleSceneUI");
    }
}
