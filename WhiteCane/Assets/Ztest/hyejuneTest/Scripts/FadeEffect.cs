using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public partial class FadeEffect : MonoBehaviour
{
    private bool isActive = false;
    private bool isFadeIn = false;
    private float deltaTime = 0;
    private Color lerpSourceColor = Color.black;
    private Color lerpDestColor = Color.black;


    [SerializeField] private Image fadeImage;
    [SerializeField] private Color sourColor = Color.black;
    [SerializeField] private Color destColor = Color.black;
    [SerializeField] private AnimationCurve fadeAnimationCurve;
    [SerializeField] private float fadeTime = 1.0f;


    [SerializeField] private UnityEvent activeFadeInEvent;
    [SerializeField] private UnityEvent deactiveFadeInEvent;
    [SerializeField] private UnityEvent activeFadeOutEvent;
    [SerializeField] private UnityEvent deactiveFadeOutEvent;
}
public partial class FadeEffect : MonoBehaviour
{
    private void Allocate()
    {

    }
    public void Initialize()
    {
        Allocate();
    }
}
public partial class FadeEffect : MonoBehaviour
{
    private void Start()
    {
    }
    private void Update()
    {
        if (isActive)
        {
            FadeEffectProgress();
        }
    }
    private void FadeEffectProgress()
    {
        deltaTime += Time.deltaTime / fadeTime;

        fadeImage.color = Color.Lerp(lerpSourceColor, lerpDestColor, fadeAnimationCurve.Evaluate(deltaTime));

        if (deltaTime >= 1.0f)
        {
            Deactive();
        }
    }
    public void ActiveFadeIn()
    {
        isActive = true;
        isFadeIn = true;
        deltaTime = 0;
        lerpSourceColor = sourColor;
        lerpDestColor = destColor;
        activeFadeInEvent?.Invoke();
    }
    public void ActiveFadeOut()
    {
        isActive = true;
        isFadeIn = false;
        deltaTime = 0;
        lerpSourceColor = destColor;
        lerpDestColor = sourColor;
        activeFadeOutEvent?.Invoke();
    }
    public void Deactive()
    {
        isActive = false;
        if (isFadeIn)
        {
            Debug.Log("deactiveFadeInEvent");
            deactiveFadeInEvent?.Invoke();
        }
        else
        {
            Debug.Log("deactiveFadeOutEvent");
            deactiveFadeOutEvent?.Invoke();
        }
    }
}