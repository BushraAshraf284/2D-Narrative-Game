using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TMP_Text HelpMessage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
