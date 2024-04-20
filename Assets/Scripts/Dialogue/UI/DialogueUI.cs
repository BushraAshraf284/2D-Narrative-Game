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
    [SerializeField] private ChoiceUI[] ChoiceUis;
    [SerializeField] private RectTransform TalkerBox;


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

    public void SetIfTalkingIsUs(bool isTalkingUs)
    {
        var pos = TalkerBox.localPosition;
        pos.x = isTalkingUs ? -Mathf.Abs(pos.x) : Mathf.Abs(pos.x);
        TalkerBox.localPosition = pos;
    }

    public void AssignChoices(DialogueWithChoices dialogueWithChoices)
    {
        CloseChoices();
        for (var i = 0; i < dialogueWithChoices.Choices.Length; i++)
        {
            var choice = dialogueWithChoices.Choices[i];
            var choiceUI = ChoiceUis[i];
            choiceUI.ToggleShown(true);
            choiceUI.SetChoiceText(choice.ChoiceText);
        }
    }

    public void CloseChoices()
    {
        foreach (var choiceUi in ChoiceUis)
            choiceUi.ToggleShown(false);
    }

    public void SelectChoice(int index)
    {
        foreach (var choiceUi in ChoiceUis)
            choiceUi.ToggleSelected(false);
        ChoiceUis[index].ToggleSelected(true);
    }
}