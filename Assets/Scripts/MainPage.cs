using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Authentication;
using UnityEngine;

public class MainPage : MonoBehaviour
{
    public TMP_Text introText;
    void Start()
    {
        introText.text = "Hello, " + AuthenticationService.Instance.PlayerName;
    }

}
