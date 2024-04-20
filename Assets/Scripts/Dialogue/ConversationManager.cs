using System;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private DialogueUI DialogueUI;
    private Conversation _currentConversation;

    [Header("Debug")] 
    [SerializeField] private Conversation DebugConversation;

    
    public static ConversationManager Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }

    public void StartConversation(Conversation conversation)
    {
        _currentConversation = conversation;
        OpenDialogueUI();
    }

    private void OpenDialogueUI()
    {
        DialogueUI.Open();
    }
    
    private void CloseDialogueUI()
    {
        DialogueUI.Close();
    }

}
