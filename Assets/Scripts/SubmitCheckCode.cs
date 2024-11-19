using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SubmitCheckCode : MonoBehaviour
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

    public bool checkCode()
    {
        Debug.Log(cim);

        if (cim.output == answer)
            return true;
        else
            return false;
    }

    public void submitCheckCode()
    {
        isRight = checkCode();

        if (cim.loopValidation == true && isRight)
        {
            Debug.Log(cim.inputField.text.Contains("for"));

            if (!cim.inputField.text.Contains("for") && !cim.inputField.text.Contains("while"))
            {
                //Debug.Log("jalan atas");
                errorNotif = GameObject.FindGameObjectWithTag("WA Notif Loop").GetComponent<RectTransform>();
                errorNotif.DOLocalMoveY(orNotifPos - notifDist, 0.3f);
                Invoke(nameof(moveNotifBack), 1f);
            
            } else
            {
                // buka pop up well done
                gum.enablePanel("Well Done Panel");
                Time.timeScale = 0;
            }
        
        } else if (cim.loopValidation == false && isRight)
        {
            // buka pop up well done
            gum.enablePanel("Well Done Panel");
            Time.timeScale = 0;

        } else if (!isRight)
        {
            //Debug.Log("jalan bawah");
            errorNotif = GameObject.FindGameObjectWithTag("WA Notif").GetComponent<RectTransform>();
            errorNotif.DOLocalMoveY(orNotifPos - notifDist, 0.3f);
            Invoke(nameof(moveNotifBack), 1f);
        }
    }

    public void moveNotifBack()
    {
        errorNotif.DOLocalMoveY(orNotifPos, 0.3f);
    }
}
