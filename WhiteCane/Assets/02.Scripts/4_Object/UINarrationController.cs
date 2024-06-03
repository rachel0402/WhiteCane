using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public partial class UINarrationController : MonoBehaviour//data
{
    [SerializeField]
    private AudioSource audioSource;

    //���� index
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
        //������ AWAKE���� �����ض� �ƴϸ� ADDCOMPONENT�� �ٲ����
        //UINarrationStep ���� ���� ����Ǿ����
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

        //text�� ���ò����� ���� controller�� ����� ������
        //�̰� text +sound
    }
    public void SetNarrationSound(string narrationName)
    {
        Debug.Log("���� �������� ����� ���");

        audioSource.clip= MainSystem.Instance.DataManager.SoundData.GetAudioClip(narrationName);
        audioSource.Play();
        //audioSource.PlayOneShot(MainSystem.Instance.DataManager.SoundData.GetAudioClip(narrationName));

    }

}
