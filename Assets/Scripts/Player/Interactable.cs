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
    private Vector2 relativePoint;
    private Transform player;

    // Update is called once per frame
    void Update()
    {
        if (IsInRange)
        {
            if (requireInteractKey)
            {
                if (Input.GetKeyDown(Constants.InteractKey))
                {
                    interactAction.Invoke();
                }
            }
            else
            {
                interactAction.Invoke();
            }
              
        }
        else { resetInteractAction.Invoke(); }

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
