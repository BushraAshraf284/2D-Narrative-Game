using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cain : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite OpenTab;
    public JournalLog journalLog;
    void Start()
    {
        Events.Conversation.ConversationStateChange += OnConvoStateChange;
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
            FindObjectOfType<JournalManager>().UnlockLog(journalLog);
            Events.Conversation.ConversationStateChange -= OnConvoStateChange;
        }
            
    }
}
