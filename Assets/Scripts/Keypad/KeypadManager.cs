using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    [SerializeField] private string CorrectPasskey;
    [SerializeField] private KeypadUI KeypadUI;
    private int[] _writtenPasscode;
    private int _currentIndex;
    private bool _passwordAnimating;

    private void Awake()
    {
        ResetPassCode();
    }

    private void ResetPassCode()
    {
        _writtenPasscode = new[] {-1, -1, -1, -1};
        _currentIndex = 0;
        KeypadUI.ResetKeypad();
        _passwordAnimating = false;
    }

    public void KeyPressed(int i)
    {
        if (_passwordAnimating)
            return;
        _writtenPasscode[_currentIndex] = i;
        _currentIndex++;
        KeypadUI.UpdateKeypad(_writtenPasscode);
        if (_currentIndex >= 4)
        {
            CheckPassword();
        }
    }

    private void CheckPassword()
    {
        var enteredPassword = string.Concat(_writtenPasscode);
        if (enteredPassword == CorrectPasskey)
            PasscodeCorrect();
        else
            PasscodeIncorrect();
    }

    private void PasscodeIncorrect()
    {
        AnimateWrongKeyPass();
    }

    private async void AnimateWrongKeyPass()
    {
        _passwordAnimating = true;
        const float initialWait = 0.4f;
        const int blinkTime = 3;
        const float blinkWait = 0.25f;
        
        await UniTask.WaitForSeconds(initialWait);
        KeypadUI.ChangeKeypadsToX();
        for (var i = 0; i < blinkTime; i++)
        {
            KeypadUI.ChangeColorPasscode(KeypadUI.KeycodeState.WRONG);
            await UniTask.WaitForSeconds(blinkWait);
            KeypadUI.ChangeColorPasscode(KeypadUI.KeycodeState.IDLE);
            await UniTask.WaitForSeconds(blinkWait);
        }
        
        ResetPassCode();
    }

    private void PasscodeCorrect()
    {
        AnimateCorrectKeyPass();
    }

    private async void AnimateCorrectKeyPass()
    {
        _passwordAnimating = true;
        const float initialWait = 0.4f;
        const int blinkTime = 3;
        const float blinkWait = 0.25f;
        await UniTask.WaitForSeconds(initialWait);
        for (var i = 0; i < blinkTime; i++)
        {
            KeypadUI.ChangeColorPasscode(KeypadUI.KeycodeState.RIGHT);
            await UniTask.WaitForSeconds(blinkWait);
            KeypadUI.ChangeColorPasscode(KeypadUI.KeycodeState.IDLE);
            await UniTask.WaitForSeconds(blinkWait);
        }
        await UniTask.WaitForSeconds(initialWait);
        Events.Keypad.CorrectKeyPressed?.Invoke();
    }

    public void ShowKeyPass()
    {
        KeypadUI.gameObject.SetActive(true);
        ResetPassCode();
    }

    public void DisableKeyPass()
    {
        KeypadUI.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Events.Keypad.KeyPressed += KeyPressed;
    }

    private void OnDisable()
    {
        Events.Keypad.KeyPressed -= KeyPressed;
    }
}