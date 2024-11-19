using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalTime : MonoBehaviour
{
    public TMP_InputField finalTime;
    public TMP_Text time;

    private void Start()
    {
        finalTime = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        finalTime.text = "Time: " + time.text;
    }
}
