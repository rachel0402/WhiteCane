using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �ҷ����� playone shot�ϱ�
public partial class SoundDataController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

}
public partial class SoundDataController : MonoBehaviour
{
    private void Start()
    {
        ActiveSound();
    }
    public void ActiveSound()
    {
        audioSource.PlayOneShot(MainSystem.Instance.DataManager.SoundData.GetAudioClip("Test_Narration_01"));
    }
}