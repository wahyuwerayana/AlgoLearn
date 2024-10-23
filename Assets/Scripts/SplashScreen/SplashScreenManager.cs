using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    bool canSwitchScene = false;
    public TMP_Text touchText;

    public void ChangeScene(int index){
        SceneManager.LoadScene(index);
    }

    private void Update() {
        if(!canSwitchScene)
            return;

        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                ChangeScene(1);
            }
        }
            
    }

    public void ChangeBoolState(){
        canSwitchScene = true;
        touchText.gameObject.SetActive(true);
    }
}
