using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class KeypadUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] PasscodeTexts;
    [SerializeField] private Color WrongColor, RightColor;

    public enum KeycodeState
    {
        IDLE,
        WRONG,
        RIGHT
    }

    public void OnKeypadButtonPressed(int i)
    {
        Events.Keypad.KeyPressed?.Invoke(i);
    }

    public void ResetKeypad()
    {
        foreach (var passcodeText in PasscodeTexts)
        {
            passcodeText.text = "";
        }
    }

    public void UpdateKeypad(int[] writtenPasscode)
    {
        for (var i = 0; i < writtenPasscode.Length; i++)
        {
            var currentKey = writtenPasscode[i];
            if (currentKey < 0)
                break;
            PasscodeTexts[i].text = $"{currentKey}";
        }
    }

    public void ChangeKeypadsToX()
    {
        foreach (var passcodeText in PasscodeTexts)
        {
            passcodeText.text = "X";
        }

    }
    
    public void ChangeColorPasscode(KeycodeState keycodeState)
    {
        foreach (var passcodeText in PasscodeTexts)
        {
            passcodeText.color = keycodeState switch
            {
                KeycodeState.IDLE =>  Color.white,
                KeycodeState.WRONG => WrongColor,
                KeycodeState.RIGHT => RightColor,
                _ => throw new ArgumentOutOfRangeException(nameof(keycodeState), keycodeState, null)
            };
        }
    }
}