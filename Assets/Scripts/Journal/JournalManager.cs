using System;
using System.Linq;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    [SerializeField] private JournalUI JournalUI;
    [SerializeField] private JournalLog[] JournalLogs;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            JournalUI.SetJournals(GetUnlockedLogs());
            JournalUI.OpenJournal();
        }
    }

    private JournalLog[] GetUnlockedLogs()
    {
        return JournalLogs.Where(jl => jl.IsUnlocked).ToArray();
    }

    public void UnlockLog(JournalLog journalLog)
    {
        foreach (var log in JournalLogs)
        {
            if (log == journalLog)
            {
                log.IsUnlocked = true;
                break;
            }
        }
    }
}
