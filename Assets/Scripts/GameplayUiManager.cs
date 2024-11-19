using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUiManager : MonoBehaviour
{
    public panels[] UIPanels;

    //public void submitCheckCode()
    //{

    //}

    //public void submitCheckMultiple()
    //{

    //}

    //public void submitCheckBlankFill()
    //{

    //}

    public void enablePanel(string panelName)
    {
        foreach (panels panelX in UIPanels)
            if (panelX.name == panelName)
                panelX.panel.SetActive(true);
    }

    public void disablePanel(string panelName)
    {
        foreach (panels panelX in UIPanels)
            if (panelX.name == panelName)
                panelX.panel.SetActive(false);
    }

    [System.Serializable]
    public class panels
    {
        public string name;
        public GameObject panel;
    }
}
