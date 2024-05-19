using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    private bool buttonPressed = false;
   public void GoToGame()
    {
        if (_particleSystem != null)
            _particleSystem.gameObject.SetActive(true);

        buttonPressed = true;

       
        
    }

    private void Update()
    {
        if (_particleSystem != null && buttonPressed)
        {
            if(_particleSystem.isStopped)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
       
    }
}
