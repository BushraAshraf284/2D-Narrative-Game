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
        CanvasGroup.alpha = 1f;
    }

    public void Close()
    {
        CanvasGroup.alpha = 0f;
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
