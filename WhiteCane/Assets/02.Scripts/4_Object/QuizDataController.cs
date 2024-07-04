using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

//QuizOption �������ֱ�
//data set�ϱ�
//ui �����ϱ�
//���� ���� � ������ ���� ������ ������ ��������

public partial class QuizDataController : MonoBehaviour
{
    [SerializeField]
    private GameObject frame;

    [SerializeField]
    private TMP_Text problem;

    public QuizObject currentquizObject { get; private set; }

    [SerializeField]
    UnityEvent problemSetEvent;

    [SerializeField]
    UnityEvent problemFinishEvent;

    [SerializeField]
    UnityEvent problemCorrectEvent;

}
public partial class QuizDataController : MonoBehaviour
{
    public void Awake()
    {
        MainSystem.Instance.DataManager.QuizData.DynamicAllocate_QuizDataController(this);
    }

    public void Allocate()
    {
    }
    public void Initialize()
    {
        Allocate();
    }

    public void SetActiveFrameState(bool state)
    {
        frame.SetActive(state);
    }

   public void ActiveQuizObject(QuizObject quizObject)
    {
        currentquizObject = quizObject;
        //�׷����� �����ν� ������
    }

    //public void NextProblem()
    //{

    //    Debug.Log("active�� ���� ��Ȱ��ȭ�ϱ� �ٽ� ���õǾ-> �ݶ��̴� �����");
    //    problemCorrectEvent?.Invoke();

    //    //exception Code
    //    if (currentProblemIndex < quizDataInformationList.Count)
    //    {
    //        currentProblemIndex++;
    //    }
    //        Debug.Log(currentProblemIndex);

    //    EndCheck();
    //}

    //public void EndCheck()
    //{
    //    //������ �� ���߾��� ���

    //    if (currentProblemIndex >= quizDataInformationList.Count)
    //    {
    //        frame.SetActive(false);
    //        Debug.Log("���� ��Ǯ�����");
    //        problemFinishEvent?.Invoke();
    //    }
    //    else
    //    {
    //        //�ۿ��� event �������ֱ�
    //        Debug.Log("���� ��xxx");

    //       // SetProblem();
    //        problemSetEvent.Invoke();
    //    }
    //}
}