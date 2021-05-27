using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitAndReset : MonoBehaviour
{
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            Quit();
        }

        if(Input.GetKeyDown(KeyCode.R)){
            Reset();
        }
    }

    public void Reset() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void Quit(){
        Application.Quit();
    }
}
