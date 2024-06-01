using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cain : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite OpenTab;
    public JournalLog journalLog;

    [SerializeField] private bool testing;
    void Start()
    {
        if (!testing)
        Events.Conversation.ConversationStateChange += OnConvoStateChange;
        else
        {
            FindObjectOfType<JournalManager>().UnlockLog(journalLog);
        }
    }

    // Update is called once per frame
    private void OnConvoStateChange(bool ConversationStart)
    {
        if(ConversationStart)
        {
            sprite.sprite = OpenTab;
            
        }
        else
        {
            Events.Conversation.ConversationStateChange -= OnConvoStateChange;
            FindObjectOfType<JournalManager>().UnlockLog(journalLog);
            
        }
            
    }
}
