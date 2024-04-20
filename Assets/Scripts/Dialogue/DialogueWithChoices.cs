using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueWithChoices")]
public class DialogueWithChoices : Dialogue
{
    public Choice[] Choices;
}


[Serializable]
public class Choice
{
    [TextArea(1, 3)] public string ChoiceText;
    public Conversation ConversationAfterChoice;
}