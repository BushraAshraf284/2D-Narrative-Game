using UnityEngine;

public abstract class Triggerable : MonoBehaviour
{
    public abstract bool IsTriggerOnGoing { get; set; }
    public abstract void OnTriggered();
}