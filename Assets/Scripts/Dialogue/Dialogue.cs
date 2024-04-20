using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    public Talker Talker;
    [TextArea(3, 7)] public string DialogueText;
    public float Seconds;
}