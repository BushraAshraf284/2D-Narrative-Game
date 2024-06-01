using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeCamera : MonoBehaviour
{
    [SerializeField] private Image FadeEffect;

    private void Start()
    {
        FadeOut(3);
    }
    public void FadeIn(float duration, UnityAction afterFade)
    {
        FadeEffect.DOFade(1, duration).OnComplete(() => afterFade?.Invoke()); 
            
    }

    public void FadeOut(int duration)
    {
        FadeEffect.DOFade(0, duration);
    }
}