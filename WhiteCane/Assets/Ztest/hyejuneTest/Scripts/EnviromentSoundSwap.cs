using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnviromentSoundSwap : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
}
public partial class EnviromentSoundSwap : MonoBehaviour
{
    //일단 사운드 교체만 넣고 자연스럽게 변경하는건 추후에 업데이트 하기
    public void SwapSound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}