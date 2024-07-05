using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool IsInRange;
    public bool requireInteractKey;
    public UnityEvent interactAction;
    public UnityEvent resetInteractAction;
    public GameObject InteractSign;
    public AudioSource InteractAudio;
    private Vector2 relativePoint;
    private Transform player;
    bool Interacted = false;

    private void Awake()
    {
        InteractAudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Interacted && requireInteractKey) 
            return;
        InteractSign.SetActive(IsInRange && requireInteractKey);
        if (IsInRange)
        {
           
            if (requireInteractKey)
            {
                Debug.Log("I'm here and supposed to work");
                if (Input.GetKeyDown(Constants.InteractKey))
                {
                    Interact();
                }
            }
            else
            {
                Interact();
            }
              
        }
        else resetInteractAction.Invoke();


    }

    private void Interact()
    {
        InteractSign.SetActive(false);
        Interacted = true;
        InteractAudio?.Play();
        interactAction.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject.transform;
            IsInRange = true;
            
        }
        if(collision.CompareTag("Obstacle"))
        {
            Events.ObstacleDetected.OnObstacleDetect(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                IsInRange = false;
            resetInteractAction.Invoke();
        }
        if (collision.CompareTag("Obstacle"))
        {
            Events.ObstacleDetected.OnObstacleDetect(false);
        }
    }

   
}

public enum ObjectTypes
{
    PUSHABLE,
    INTERACTABLE
}
