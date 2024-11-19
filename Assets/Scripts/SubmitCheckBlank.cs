using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitCheckBlank : MonoBehaviour
{
    public CodeInputManager cim;
    public RectTransform errorNotif;
    public GameplayUiManager gum;
    private float notifDist = 150;
    [SerializeField] private bool isRight;
    private float orNotifPos;

    [TextArea(5, 100)]
    public string answer;

    // Start is called before the first frame update
    void Start()
    {
        cim = GetComponentInChildren<CodeInputManager>();
        gum = GetComponent<GameplayUiManager>();
        errorNotif = GameObject.FindGameObjectWithTag("WA Notif").GetComponent<RectTransform>();

        orNotifPos = errorNotif.localPosition.y;
    }

    public bool checkAns()
    {
        if (cim.input == answer)
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
}
