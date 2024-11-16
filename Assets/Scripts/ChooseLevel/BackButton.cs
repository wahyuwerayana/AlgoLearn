using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(sceneName);
        }
    }
}
