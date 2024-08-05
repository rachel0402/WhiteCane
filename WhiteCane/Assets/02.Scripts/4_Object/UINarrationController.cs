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
    private bool isActive = true;
    private float selectState;

    private UINarrationStep currentUINarrationStep;

    //현재 index
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
        //무조건 AWAKE에서 실행해라 아니면 ADDCOMPONENT로 바꿔버려
        //UINarrationStep 보단 빨리 실행되어야함
        MainSystem.Instance.DataManager.NarrationData.DynamicAllocate_UINarrationController(this);
    }
    private void Update()
    {
        //  NarrationSkip();
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
        Debug.Log("나레이션 스킵");

    }

    //public void NarrationSkip()
    //{
    //    selectState = skipButton.action.ReadValue<float>();

    //    if (selectState == 0)
    //    {
    //        isActive = true;
    //    }
    //    else
    //    {
    //        if (isActive)
    //        {
    //            SkipButton();
    //            isActive = false;
    //        }
    //    }
    //}
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
        //  SetFrameActiveState(true); 하면 ㄴㄴ
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

    }
    public void SetNarrationSound(string narrationName)
    {
        isReturn = false;

        audioSource.clip = MainSystem.Instance.DataManager.SoundData.GetAudioClip(narrationName);
        audioSource.Play();
        StartCoroutine(waitAudio());

    }

    bool isReturn = false;

    private IEnumerator waitAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);

        if (isReturn == false)
        {
            SkipButton();
            isReturn = true;
        }
    }
}
