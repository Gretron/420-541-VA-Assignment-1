using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart() 
    {
        GameManager.Instance.LoadNextScene();
    }

    public void OnClickExit() 
    {
        Application.Quit();
    }
}
