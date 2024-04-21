using System;
using NaughtyAttributes;
using UnityEngine;

public class TriggerableArea : MonoBehaviour
{
    [SerializeField] private Triggerable Triggerable;
    [SerializeField] private bool IsKeyCodeRequired;
    [SerializeField, ShowIf(nameof(IsKeyCodeRequired))] private KeyCode _keyCode;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsKeyCodeRequired)
            return;
        if (other.GetComponent<Player>() == null)
            return;
        if (Triggerable.IsTriggerOnGoing)
            return;
        Triggerable.OnTriggered();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!IsKeyCodeRequired)
            return;
        if (!Input.GetKeyDown(_keyCode))
            return;
        if (Triggerable.IsTriggerOnGoing)
            return;
        Triggerable.OnTriggered();
    }
}
