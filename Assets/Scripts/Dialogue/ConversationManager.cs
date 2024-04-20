using System;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private DialogueUI DialogueUI;
    [SerializeField] private double TextSpeed;

    private Conversation _currentConversation;
    private Dialogue _currentDialogue;

    [Header("Debug")] [SerializeField] private Conversation DebugConversation;


    public static ConversationManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public void StartConversation(Conversation conversation)
    {
        _currentConversation = conversation;
        OpenDialogueUI();
        ConversationLoop();
    }

    private async void ConversationLoop()
    {
        for (var i = 0; i < _currentConversation.Dialogues.Length; i++)
        {
            _currentDialogue = _currentConversation.Dialogues[i];
            AssignDialogue(_currentDialogue);
            await UniTask.WhenAny(
                UniTask.WaitUntil(() => Input.GetKeyDown(Constants.InteractKey)),
                UniTask.Delay(TimeSpan.FromSeconds(_currentDialogue.Seconds))
            );
        }

        CloseDialogueUI();
    }

    private void AssignDialogue(Dialogue dialogue)
    {
        DialogueUI.SetDialogueText(dialogue.DialogueText);
        DialogueUI.SetTalkerImage(dialogue.Talker.CharacterSprite);
        DialogueUI.SetTalkerName(dialogue.Talker.CharacterName);
    }

    private void OpenDialogueUI()
    {
        DialogueUI.Open();
    }

    private void CloseDialogueUI()
    {
        DialogueUI.Close();
    }

    [Button]
    private void DebugStartConversation()
    {
        StartConversation(DebugConversation);
    }
}