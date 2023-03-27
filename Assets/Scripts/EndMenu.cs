using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    private void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnClickRestart() 
    {
        GameManager.Instance.LoadFirstLevel();
    }

    public void OnClickMainMenu() 
    {
        GameManager.Instance.LoadMainMenu();
    }
}
