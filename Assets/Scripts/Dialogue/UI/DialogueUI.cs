using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup CanvasGroup;
    [SerializeField] private TMP_Text DialogueText;
    [SerializeField] private TMP_Text TalkerName;
    [SerializeField] private Image TalkerImage;


    public void Open()
    {
        DOTween.To((() => CanvasGroup.alpha), val => CanvasGroup.alpha = val, 1f, 0.2f);
    }

    public void Close()
    {
        DOTween.To((() => CanvasGroup.alpha), val => CanvasGroup.alpha = val, 0f, 0.2f);
    }

    public void SetDialogueText(string text)
    {
        DialogueText.text = text;
    }

    public void SetTalkerName(string text)
    {
        TalkerName.text = text;
    }

    public void SetTalkerImage(Sprite sprite)
    {
        TalkerImage.sprite = sprite;
    }
}