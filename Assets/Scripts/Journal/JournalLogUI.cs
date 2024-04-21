using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalLogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text JournalTitle;
    [SerializeField] private Image Image;
    [SerializeField] private Sprite DefaultJournalImage;
    private JournalLog _journalLog;
    [SerializeField] private Color SelectedColor;

    public void ToggleShow(bool isShown)
    {
        gameObject.SetActive(isShown);
    }

    public void ToggleSelected(bool isSelected)
    {
        Image.color = isSelected ? Color.white : SelectedColor;
    }

    public void SetJournalLog(JournalLog journalLog)
    {
        _journalLog = journalLog;
    }

    public void SetJournalUI()
    {
        JournalTitle.text = _journalLog.LogName;
    }

    public void ActivateJournal(Image image, TMP_Text tmpText)
    {
        if (_journalLog.LogImage != null)
            image.sprite = _journalLog.LogImage;
        else
            image.sprite = DefaultJournalImage;
        if (_journalLog.LogContent != "")
            tmpText.text = _journalLog.LogContent;
    }
}