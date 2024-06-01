using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private FadeCamera fadeCamera;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
          
            fadeCamera.FadeIn(0.1f,() => {
                player.ResetPlayer();
                fadeCamera.FadeOut(2);
                });
        }
    }
}
