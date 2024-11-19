using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotAvailableButton : MonoBehaviour
{
    [SerializeField] private Image notAvailableImage;
    [SerializeField] private TMP_Text notAvailableText;

    private void OnEnable() {
        FadeStart(notAvailableImage.rectTransform, notAvailableText.rectTransform);
        FadeFinished(notAvailableText.rectTransform, notAvailableText.rectTransform);
        StartCoroutine(DisableObject());
    }

    private void FadeStart(RectTransform imageRectTransform, RectTransform textRectTransform){
        LeanTween.alpha(imageRectTransform, 1f, 0.5f).setEase(LeanTweenType.linear);
        LeanTween.textAlpha(textRectTransform, 1f, 0.5f).setEase(LeanTweenType.linear);
    }

    private void FadeFinished(RectTransform imageRectTransform, RectTransform textRectTransform){
        LeanTween.alpha(imageRectTransform, 0f, 0.5f).setEase(LeanTweenType.linear).setDelay(2f);
        LeanTween.textAlpha(textRectTransform, 0f, 0.5f).setEase(LeanTweenType.linear).setDelay(2f);
    }

    private IEnumerator DisableObject(){
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
