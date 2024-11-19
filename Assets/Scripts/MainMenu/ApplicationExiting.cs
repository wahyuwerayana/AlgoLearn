using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationExiting : MonoBehaviour
{
    [SerializeField] private GameObject quitPanel;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            quitPanel.SetActive(true);
        }
    }

    public void ExitApp(){
        Application.Quit();
    }
}
