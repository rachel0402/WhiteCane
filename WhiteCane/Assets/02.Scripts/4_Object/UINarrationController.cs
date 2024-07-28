using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.InputSystem;

public partial class UINarrationController : MonoBehaviour//data
{
    [SerializeField]
    private GameObject frame;

    [SerializeField]
    private AudioSource audioSource;

    UINarrationStep currentUINarrationStep;

    //���� index
    public int narrationIndex = 0;

    [SerializeField]
    private TMP_Text narrationText;

    [SerializeField]
    private InputActionReference skipButton;

    [SerializeField]
    private UnityEvent activeEvent;
    [SerializeField]
    private UnityEvent deactiveEvent;
}
public partial class UINarrationController : MonoBehaviour//initialze
{
    private void Awake()
    {
        //������ AWAKE���� �����ض� �ƴϸ� ADDCOMPONENT�� �ٲ����
        //UINarrationStep ���� ���� ����Ǿ����
        MainSystem.Instance.DataManager.NarrationData.DynamicAllocate_UINarrationController(this);
    }
    private void Update()
    {
        NarrationSkip();
    }
    public void Initialize()
    {
    }

}
public partial class UINarrationController : MonoBehaviour//fuction
{
    private void SkipButton()
    {
        currentUINarrationStep.SkipButtonActive();
        Debug.Log("�����̼� ��ŵ");

    }
    bool isActive = true;
    float selectState;

    public void NarrationSkip()
    {
        selectState = skipButton.action.ReadValue<float>();

        if (selectState == 0)
        {
            isActive = true;
        }
        else
        {
            if (isActive)
            {
                SkipButton();
                isActive = false;
            }
        }
    }
    public void DynamicAllocateUINarrationStep(UINarrationStep uINarrationStepValue)
    {
        currentUINarrationStep = uINarrationStepValue;
    }
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
        audioSource.Stop();
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

        audioSource.clip = MainSystem.Instance.DataManager.SoundData.GetAudioClip(narrationName);
        audioSource.Play();
        //audioSource.PlayOneShot(MainSystem.Instance.DataManager.SoundData.GetAudioClip(narrationName));
        StartCoroutine(waitAudio());


    }



    private IEnumerator waitAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SkipButton();
        print("���� ��");
    }
}
