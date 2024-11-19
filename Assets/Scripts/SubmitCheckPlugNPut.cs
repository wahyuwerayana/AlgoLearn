using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitCheckPlugNPut : MonoBehaviour
{
    public RectTransform errorNotif;
    public GameplayUiManager gum;
    private float notifDist = 150;
    [SerializeField] private bool isRight;
    private float orNotifPos;
    [Range(1, 3)] public int answer;
    [Range(0, 3)] public int userAnswer;

    // Start is called before the first frame update
    void Start()
    {
        gum = GetComponent<GameplayUiManager>();
        errorNotif = GameObject.FindGameObjectWithTag("WA Notif").GetComponent<RectTransform>();

        orNotifPos = errorNotif.localPosition.y;
    }

    public bool checkAns()
    {
        if (userAnswer == answer)
            return true;
        else
            return false;
    }

    public void submitCheckBlank()
    {
        isRight = checkAns();

        if (isRight)
        {
            gum.enablePanel("Well Done Panel");
            Time.timeScale = 0;

        } else
        {
            errorNotif.DOLocalMoveY(orNotifPos - notifDist, 0.3f);
            Invoke(nameof(moveNotifBack), 1f);
        }
    }

    public void moveNotifBack()
    {
        errorNotif.DOLocalMoveY(orNotifPos, 0.3f);
    }

    public void changeAnsTo(int x)
    {
        userAnswer = x;
    }
}
