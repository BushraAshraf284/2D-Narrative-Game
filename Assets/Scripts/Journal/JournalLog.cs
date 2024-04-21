using UnityEngine;

[CreateAssetMenu]
public class JournalLog : ScriptableObject
{
    public string LogName;
    public Sprite LogImage;
    public bool IsUnlocked;
    [TextArea(3, 6)] public string LogContent;
}