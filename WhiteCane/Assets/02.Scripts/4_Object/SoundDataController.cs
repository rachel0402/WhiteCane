using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사운드 불러오고 playone shot하기
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