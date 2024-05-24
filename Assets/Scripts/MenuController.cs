using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [Header("Buttons")]
    public List<VFXButton> Buttons;

    [SerializeField] ParticleSystem _particleSystem;
    private bool buttonPressed = false;

    private VFXButton currentButton;

    private void Start()
    {
        for(int i = 0; i < Buttons.Count; i++)
        {
            int val = i;
            Debug.Log(Buttons[i].Type.ToString() + Buttons[i].btn);
            Buttons[val].btn.onClick.AddListener(() =>
            {
                PlayEffect(val);
            });
        }
    }
    private void Update()
    {
        if (currentButton != null)
        {
            if (currentButton.Effect.isStopped)
            {
                ActionToPerform();
            }
        }

        

    }

    public void PlayEffect(int i)
    {
        currentButton = Buttons[i];
        if (currentButton.Effect != null)
        {
            currentButton.Effect.gameObject.SetActive(true);
        }
        else
        {
            ActionToPerform();
        }


    }

    public void OnButtonPressed()
    {
        if (_particleSystem != null)
            _particleSystem.gameObject.SetActive(true);

        buttonPressed = true;
    }

    public void ActionToPerform()
    {
        if(currentButton.Type == ButtonType.PLAY)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            currentButton.Panel.gameObject.SetActive(true);
        }
        currentButton = null;
    }


}

[Serializable]
public class VFXButton
{
    public ButtonType Type;
    public UnityEngine.UI.Button btn;
    public ParticleSystem Effect;
    public bool IsButtonPressed;
    public GameObject Panel;
   

   

    
}

public enum ButtonType
{
    PLAY,
    SETTINGS,
    CONTROLS,
    CREDITS
}

