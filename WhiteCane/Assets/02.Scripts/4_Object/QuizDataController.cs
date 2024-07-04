using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

//QuizOption 관리해주기
//data set하기
//ui 생성하기
//내가 지금 어떤 문제에 대한 것인지 정보도 가져야함

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
        //그래야지 음성인식 가능함
    }

    //public void NextProblem()
    //{

    //    Debug.Log("active한 문제 비활성화하기 다시 선택되어도-> 콜라이더 끄면됨");
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
    //    //문제를 다 맞추었을 경우

    //    if (currentProblemIndex >= quizDataInformationList.Count)
    //    {
    //        frame.SetActive(false);
    //        Debug.Log("문제 다풀었어요");
    //        problemFinishEvent?.Invoke();
    //    }
    //    else
    //    {
    //        //밖에서 event 연결해주기
    //        Debug.Log("문제 다xxx");

    //       // SetProblem();
    //        problemSetEvent.Invoke();
    //    }
    //}
}