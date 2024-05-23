using System;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private DialogueUI DialogueUI;
    [SerializeField] private double TextSpeed;
    [SerializeField] private Talker CharacterTalker;

    private Conversation _currentConversation;
    private Dialogue _currentDialogue;

    [Header("Debug")] [SerializeField] private Conversation DebugConversation;
    private bool _isChoiceSelected;


    public static ConversationManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public void StartConversation(Conversation conversation)
    {
        Events.Conversation.ConversationStateChange?.Invoke(true);
        _currentConversation = conversation;
        if (_currentConversation.DoesStopPlayerMovement)
            Events.Player.TogglePlayerMovement?.Invoke(false);
        OpenDialogueUI();
        ConversationLoop();
    }

    private async void ConversationLoop()
    {
        for (var i = 0; i < _currentConversation.Dialogues.Length; i++)
        {
            _currentDialogue = _currentConversation.Dialogues[i];
            AssignDialogue(_currentDialogue);
            if (_currentDialogue is DialogueWithChoices)
            {
                HandleDialogueWithChoices(_currentDialogue);
                break;
            }

            await UniTask.WhenAny(
                UniTask.WaitUntil(() => Input.GetKeyDown(Constants.SkipConversation)),
                UniTask.WaitForSeconds(_currentDialogue.Seconds)
            );
        }

        if (_currentDialogue is DialogueWithChoices)
            return;

        
        if (_currentConversation.DoesStopPlayerMovement)
            Events.Player.TogglePlayerMovement?.Invoke(true);
        Events.Conversation.ConversationStateChange?.Invoke(false);

        CloseDialogueUI();
    }

    private async void HandleDialogueWithChoices(Dialogue currentDialogue)
    {
        var dialogueWithChoices = currentDialogue as DialogueWithChoices;
        if (dialogueWithChoices == null)
        {
            Debug.LogError("dialogueWithChoices is null");
            return;
        }

        foreach (var choice in dialogueWithChoices.Choices)
        {
            Debug.Log($"Choice: {choice.ChoiceText}");
        }

        Events.Player.TogglePlayerMovement?.Invoke(false);

        
        var currentSelectedChoice = 0;
        var numOfChoices = dialogueWithChoices.Choices.Length;
        DialogueUI.AssignChoices(dialogueWithChoices);
        DialogueUI.SelectChoice(currentSelectedChoice);
        while (!_isChoiceSelected)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentSelectedChoice = (currentSelectedChoice + 1 + numOfChoices) % numOfChoices;
                DialogueUI.SelectChoice(currentSelectedChoice);
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentSelectedChoice = (currentSelectedChoice - 1 + numOfChoices) % numOfChoices;
                DialogueUI.SelectChoice(currentSelectedChoice);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                _isChoiceSelected = true;
            }
            await UniTask.Yield();
        }
        DialogueUI.CloseChoices();
        _isChoiceSelected = false;
        _currentConversation = dialogueWithChoices.Choices[currentSelectedChoice].ConversationAfterChoice;
        ConversationLoop();
    }

    private void AssignDialogue(Dialogue dialogue)
    {
        DialogueUI.SetDialogueText(dialogue.DialogueText);
        DialogueUI.SetTalkerImage(dialogue.Talker.CharacterSprite);
        DialogueUI.SetTalkerName(dialogue.Talker.CharacterName);
        DialogueUI.SetIfTalkingIsUs(dialogue.Talker==CharacterTalker);
    }

    private void OpenDialogueUI()
    {
        DialogueUI.Open();
    }

    private void CloseDialogueUI()
    {
        DialogueUI.Close();
        Events.Player.TogglePlayerMovement?.Invoke(true);
    }


    [Button]
    private void DebugStartConversation()
    {
        StartConversation(DebugConversation);
    }
}