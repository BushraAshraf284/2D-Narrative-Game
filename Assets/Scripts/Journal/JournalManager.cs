using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    [SerializeField] private JournalUI JournalUI;
    [SerializeField] private JournalLog[] JournalLogs;
    [SerializeField] private HUDController HUDController;
    private List<JournalLog> _unlockedLogs = new();

    private void Awake()
    {
        foreach (var log in JournalLogs)
        {
            if (log.IsUnlocked)
                _unlockedLogs.Add(log);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(_unlockedLogs.Count > 0)
            {
                JournalUI.SetJournals(GetUnlockedLogs());
                JournalUI.OpenJournal();
            }
           
        }
    }

    private JournalLog[] GetUnlockedLogs()
    {
        return _unlockedLogs.ToArray();
    }

    public void UnlockLog(JournalLog journalLog)
    {
        HUDController.SetHelpMessage("Press J to see Journal");
        if (!_unlockedLogs.Contains(journalLog))
            _unlockedLogs.Add(journalLog);
    }
}