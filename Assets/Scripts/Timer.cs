using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        //timerText.text = time.ToString();

        int mins = (int)time / 60;
        int secs = (int)time % 60;

        timerText.text = string.Format("{0:00}:{1:00}", mins, secs);
    }
}
