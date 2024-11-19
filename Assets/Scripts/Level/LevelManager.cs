using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> pages;
    private int pageIndex = 0;
    [SerializeField] private TMP_Text pageNumberText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button understandButton;

    private void Start() {
        UpdatePageNumber();
    }

    public void NextPage(){
        if(pageIndex >= pages.Count - 1){
            return;
        }

        pages[pageIndex].gameObject.SetActive(false);
        pageIndex++;
        pages[pageIndex].gameObject.SetActive(true);
        UpdatePageNumber();

        if(pageIndex == pages.Count - 1){
            nextButton.gameObject.SetActive(false);
            understandButton.gameObject.SetActive(true);
        }
    }

    public void PreviousPage(){
        if(pageIndex <= 0){
            return;
        }

        if(pageIndex == pages.Count - 1){
            nextButton.gameObject.SetActive(true);
            understandButton.gameObject.SetActive(false);
        }

        pages[pageIndex].gameObject.SetActive(false);
        pageIndex--;
        pages[pageIndex].gameObject.SetActive(true);
        UpdatePageNumber();
    }

    private void UpdatePageNumber(){
        pageNumberText.text = (pageIndex + 1).ToString() + " / " + pages.Count;
    }
}
