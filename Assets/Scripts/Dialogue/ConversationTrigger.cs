using System;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    [SerializeField] private Conversation Conversation;
    private bool _isConversationTriggered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isConversationTriggered || other.GetComponent<Player>() == null)
            return;
        ConversationManager.Instance.StartConversation(Conversation);
        _isConversationTriggered = true;
    }
}
