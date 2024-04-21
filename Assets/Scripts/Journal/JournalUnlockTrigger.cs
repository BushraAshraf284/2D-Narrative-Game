using UnityEngine;

public class JournalUnlockTrigger : MonoBehaviour
{
    [SerializeField] private JournalLog journalLog;
    private bool _isTriggered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isTriggered || other.GetComponent<Player>() == null)
            return;
        _isTriggered = true;
        FindObjectOfType<JournalManager>().UnlockLog(journalLog);
    }
}
