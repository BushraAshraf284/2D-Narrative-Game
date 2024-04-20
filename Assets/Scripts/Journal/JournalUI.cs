using UnityEngine;
using UnityEngine.UI;

public class JournalUI : MonoBehaviour
{
    private bool _journalActive;
    [SerializeField] private JournalLogUI[] JournalLogUis;
    [SerializeField] private Image image;

    private int _selectedIndex = 0;
    private JournalLog[] _journalLogs;

    private void Update()
    {
        if (!_journalActive)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseJournal();

        var numOfChoices = _journalLogs.Length;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _selectedIndex = (_selectedIndex + 1 + numOfChoices) % numOfChoices;
            SelectJournal();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _selectedIndex = (_selectedIndex - 1 + numOfChoices) % numOfChoices;
            SelectJournal();
        }
    }

    private void SelectJournal()
    {
        foreach (var journalLogUi in JournalLogUis)
            journalLogUi.ToggleSelected(false);
        var selectedJournalLogUI = JournalLogUis[_selectedIndex];
        selectedJournalLogUI.ToggleSelected(true);
        selectedJournalLogUI.ActivateJournal(image);
    }

    public void OpenJournal()
    {
        _journalActive = true;
        gameObject.SetActive(true);
        _selectedIndex = 0;
        SelectJournal();
    }

    public void CloseJournal()
    {
        _journalActive = false;
        gameObject.SetActive(false);
    }

    public void SetJournals(JournalLog[] journalLogs)
    {
        _journalLogs = journalLogs;
        foreach (var journalLogUi in JournalLogUis)
            journalLogUi.ToggleShow(false);
        for (var i = 0; i < journalLogs.Length; i++)
        {
            var journalLogUi = JournalLogUis[i]; 
            journalLogUi.SetJournalLog(journalLogs[i]);
            journalLogUi.SetJournalUI();
            journalLogUi.ToggleShow(true);
        }
    }
}
