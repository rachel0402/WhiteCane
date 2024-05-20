using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class UINarrationStep : MonoBehaviour
{
    private int narrationStepIndex = 0;

    //����� �ش� narrationindex�� ����ִ� value���� ��� �����ϴ� list�� ������ �ְ�
    [SerializeField]
    private List<string> narrationIndexList = new List<string>();

    //����� �ش� index�� text�� �� �־��ֱ� 
    [SerializeField]
    private List<string> narrationTextList = new List<string>();


    [SerializeField]
    UnityEvent activeEvent;
    [SerializeField]
    UnityEvent deactiveEvent;

}
public partial class UINarrationStep : MonoBehaviour
{
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        narrationStepIndex = MainSystem.Instance.DataManager.NarrationData.UINarrationController.narrationIndex;

        narrationStepIndex = 0;

        for (int i = 0; i < narrationIndexList.Count; i++)
        {
            narrationTextList.Add(MainSystem.Instance.DataManager.NarrationData.GetNarration(narrationIndexList[i]));
        }

    }

    public void Active()
    {
        activeEvent?.Invoke();
    }
    public void Deactive()
    {
        deactiveEvent?.Invoke();
    }

    public void SetNarration()
    {
        MainSystem.Instance.DataManager.NarrationData.UINarrationController.SetNarration(narrationTextList[narrationStepIndex]);
    }
    public void NextStep()
    {
        //NARRATION INDEX�� �� �������� �ҷ����ҵ�

        //exception
        if (narrationStepIndex < narrationIndexList.Count - 1)
        {
            narrationStepIndex++;
        }
        MainSystem.Instance.DataManager.NarrationData.UINarrationController.SetNarration(narrationTextList[narrationStepIndex]);

    }
    //public string GetIndex()
    //{
    //    return "a";
    //}
}
