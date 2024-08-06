using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnviromentSoundSwap : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private bool isActive = false;
    private float deltaTime = 0;

    private float lerpSourceSound = 0;
    private float lerpDestSound = 0;

    private float minVolume=0.3f;
    private float maxVolume =1f;

  //private float sourSound = 0;
  // private float destSound =0;
    [SerializeField] private AnimationCurve fadeAnimationCurve;
    [SerializeField] private float fadeTime = 1.0f;
}
public partial class EnviromentSoundSwap : MonoBehaviour
{
    private void Update()
    {
        if (isActive)
        {
            FadeEffectProgress();
        }
    }
    //일단 사운드 교체만 넣고 자연스럽게 변경하는건 추후에 업데이트 하기
    public void SwapSound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    private void ActiveFadeIn()
    {
        isActive = true;
        deltaTime = 0;
    }
    private void FadeEffectProgress()
    {
        deltaTime += Time.deltaTime / fadeTime;

        audioSource.volume = Mathf.Lerp(lerpSourceSound, lerpDestSound, fadeAnimationCurve.Evaluate(deltaTime));

        if (deltaTime >= 1.0f)
        {
            Deactive();
        }
    }
    public void Deactive()
    {
        isActive = false;
    }
    public void VolumDown()
    {
        lerpSourceSound = audioSource.volume;
        lerpDestSound = minVolume;
        ActiveFadeIn();
    }
    public void VolumUp()
    {
        lerpSourceSound = audioSource.volume;
        lerpDestSound = maxVolume;
        ActiveFadeIn();
    }
}