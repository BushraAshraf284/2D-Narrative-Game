using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TMP_Text HelpMessage;

    [Header("Codex UI")]
    [SerializeField] private GameObject Page;
    [SerializeField] private Conversation conversation;
    [SerializeField] private ConversationManager conversationManager;

    [Header("Outro UI")]
    [SerializeField] private Image BlackScreen;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private Image End;
    bool _pageActive;
    bool _dialogueShown;
    float currentTime;
    void Start()
    {
        currentTime = 0;
        Events.Keypad.CorrectKeyPressed += Outro;
    }

    // Update is called once per frame
    void Update()
    {
        if (_dialogueShown)
        {
            if (currentTime < dialogue.Seconds)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                EndGame();
            }
        }

        if (!_pageActive)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPage(false);
            conversationManager.StartConversation(conversation);
        }

      
           


        
    }
        

    public void SetHelpMessage(string message)
    {
        HelpMessage.text = message;
        HelpMessage.gameObject.SetActive(true);
        HelpMessage.DOFade(0, 1).onComplete = ()=>
        {
            HelpMessage.DOFade(1, 1).onComplete = () => { HelpMessage.gameObject.SetActive(false); };
        };
    }

    public void ShowPage(bool show)
    {
        _pageActive = show;
        Page.SetActive (show);
    }

    public void Outro()
    {
        Debug.Log("I'm working");
        _dialogueShown = true;
        BlackScreen.gameObject.SetActive(true);
        BlackScreen.DOFade(1, 0.3f);
        conversationManager.OpenDialogueUI();
        conversationManager.AssignDialogue(dialogue);
        


        //Events.Keypad.CorrectKeyPressed
    }

    public void EndGame()
    {
        
        _dialogueShown = false;
        conversationManager.CloseDialogueUI();
        End.gameObject.SetActive
            (true);
        End.DOFade(1, 2);
    }
}
