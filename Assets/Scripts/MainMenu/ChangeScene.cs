using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneTo(string sceneName){
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
