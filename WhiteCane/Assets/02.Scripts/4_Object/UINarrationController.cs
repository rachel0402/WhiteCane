using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public partial class UINarrationController : MonoBehaviour//data
{
    [SerializeField]
    private AudioSource audioSource;

    //현재 index
    public int narrationIndex = 0;

    [SerializeField]
    TMP_Text narrationText;

    [SerializeField]
    GameObject frame;


    [SerializeField]
    UnityEvent activeEvent;
    [SerializeField]
    UnityEvent deactiveEvent;
}
public partial class UINarrationController : MonoBehaviour//initialze
{
    private void Awake()
    {
        //무조건 AWAKE에서 실행해라 아니면 ADDCOMPONENT로 바꿔버려
        //UINarrationStep 보단 빨리 실행되어야함
        MainSystem.Instance.DataManager.NarrationData.DynamicAllocate_UINarrationController(this);
    }
    public void Initialize()
    {

    }

}
public partial class UINarrationController : MonoBehaviour//fuction
{
    public void SetFrameActiveState(bool state)
    {
        frame.SetActive(state);
    }

    public void Active()
    {
        SetFrameActiveState(true);
        activeEvent?.Invoke();
    }
    public void Deactive()
    {
        SetFrameActiveState(false);
        deactiveEvent?.Invoke();
    }
    public void SetNarrationText(string narrationTextValue)
    {
        narrationText.text = narrationTextValue;

        //text만 나올껀지에 관한 controller도 만들면 좋을듯
        //이건 text +sound
    }
    public void SetNarrationSound(string narrationName)
    {
        Debug.Log("사운드 넣을꺼면 여기로 고고");

        audioSource.clip= MainSystem.Instance.DataManager.SoundData.GetAudioClip(narrationName);
        audioSource.Play();
        //audioSource.PlayOneShot(MainSystem.Instance.DataManager.SoundData.GetAudioClip(narrationName));

    }

}
