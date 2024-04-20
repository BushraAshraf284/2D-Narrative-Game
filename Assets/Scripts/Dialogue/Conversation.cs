
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Conversation")]
public class Conversation : ScriptableObject
{
    public Dialogue[] Dialogues;
    public bool DoesStopPlayerMovement;
}
