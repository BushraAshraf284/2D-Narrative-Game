using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour
{
    [SerializeField] private Image ChoiceImage;
    [SerializeField] private TMP_Text ChoiceText;
    [SerializeField] private Color SelectedColor;

    public void ToggleShown(bool isShown)
    {
        ChoiceText.enabled = isShown;
        ChoiceImage.enabled = isShown;
    }

    public void SetChoiceText(string choiceText)
    {
        ChoiceText.text = choiceText;
    }

    public void ToggleSelected(bool isSelected)
    {
        ChoiceImage.color = isSelected ? SelectedColor : Color.white;
    }
}