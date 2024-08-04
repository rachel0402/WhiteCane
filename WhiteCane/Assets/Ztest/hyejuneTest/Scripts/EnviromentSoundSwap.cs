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
    //�ϴ� ���� ��ü�� �ְ� �ڿ������� �����ϴ°� ���Ŀ� ������Ʈ �ϱ�
    public void SwapSound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}