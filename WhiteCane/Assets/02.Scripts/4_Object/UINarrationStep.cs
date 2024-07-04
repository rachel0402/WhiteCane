using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class UINarrationStep : MonoBehaviour
{
    private int narrationStepIndex = 0;
    private int narrationMaxIndex = 0;

    //여기는 해당 narrationindex가 들어있는 value값을 모두 관리하는 list를 가지고 있고
    [SerializeField]
    private List<string> narrationIndexList = new List<string>();

    //여기는 해당 index의 text를 다 넣어주기 
    [SerializeField]
    private List<string> narrationTextList = new List<string>();


    [SerializeField]
    private UnityEvent activeEvent;
    [SerializeField]
    private UnityEvent deactiveEvent;

    private bool isSelect = false;
}
public partial class UINarrationStep : MonoBehaviour
{
    private void Start()
    {
        Initialize();
    }
    public void Update()
    {
        if (isSelect)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                NextStep();
            }
        }

    }
    public void Initialize()
    {
        narrationMaxIndex = narrationIndexList.Count - 1;

        narrationStepIndex = MainSystem.Instance.DataManager.NarrationData.UINarrationController.narrationIndex;

        narrationStepIndex = 0;

        for (int i = 0; i < narrationIndexList.Count; i++)
        {
            narrationTextList.Add(MainSystem.Instance.DataManager.NarrationData.GetNarration(narrationIndexList[i]));
        }
    }

    public void Active()
    {
        narrationStepIndex = 0;

        isSelect = true;
        SetNarration();
        MainSystem.Instance.DataManager.NarrationData.UINarrationController.Active();
        activeEvent?.Invoke();
    }
    public void Deactive()
    {
        isSelect = false;
        deactiveEvent?.Invoke();
    }

    private void SetNarration()
    {
        MainSystem.Instance.DataManager.NarrationData.UINarrationController.SetNarrationText(narrationTextList[narrationStepIndex]);
        MainSystem.Instance.DataManager.NarrationData.UINarrationController.SetNarrationSound(narrationIndexList[narrationStepIndex]);

    }

    //private void Reset()
    //{
    //    narrationStepIndex = 0;
    //}
    public void NextStep()
    {
        //NARRATION INDEX를 맨 상위에서 불러야할듯

        if (narrationStepIndex == narrationMaxIndex)
        {
            MainSystem.Instance.DataManager.NarrationData.UINarrationController.Deactive();
            Deactive();
        }

        //exception
        if (narrationStepIndex < narrationIndexList.Count - 1)
        {
            narrationStepIndex++;
            SetNarration();
        }



    }

    //public string GetIndex()
    //{
    //    return "a";
    //}
}
