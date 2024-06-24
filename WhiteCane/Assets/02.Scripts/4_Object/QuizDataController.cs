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
    private QuizOption quizOptionPrefab;
    [SerializeField]
    private Transform optionParent;
    [SerializeField]
    private TMP_Text problem;

    //보기 오브젝트 생성
    [SerializeField]
    private List<QuizOption> quizOptionList = new List<QuizOption>();


    private List<QuizData.QuizDataInformation> quizDataInformationList = new List<QuizData.QuizDataInformation>();

    private List<string> currentOptionTextList = new List<string>();

    //현재 문제번호
    private int currentProblemIndex;

    //생성할 보기에 갯수
    private const int maxOptionCount = 3;


    [SerializeField]
    UnityEvent problemSetEvent;

    [SerializeField]
    UnityEvent problemFinishEvent;

    [SerializeField]
    UnityEvent problemCorrectEvent;

    private QuizData.QuizDataInformation currenQuizObjectInformation;
}
public partial class QuizDataController : MonoBehaviour
{
    public void Awake()
    {
        MainSystem.Instance.DataManager.QuizData.DynamicAllocate_QuizDataController(this);
    }

    public void Allocate()
    {
        Load();
    }
    public void Initialize()
    {
        Allocate();
    }

    public void SetActiveFrameState(bool state)
    {
        frame.SetActive(state);
    }

    public void Load()
    {
        quizDataInformationList = MainSystem.Instance.DataManager.QuizData.GetQuizDataInformationList();

        //quiz object를 보기 갯수만큼 생성
        for (int i = 0; i < maxOptionCount; i++)
        {
            QuizOption optionPrefab = QuizOption.Instantiate(quizOptionPrefab, optionParent);

            quizOptionList.Add(optionPrefab);
        }
    }
    public void Start()
    {
       // SetProblem("bird);
    }


    //현재 

    private void Reset()
    {
        currentOptionTextList.Clear();

        //quizDataInformationList는 CLEAR 하면 안됨, 그 안에 데이터는 CLEAR 해도 ㄱㅊ

        for (int i = 0; i < quizOptionList.Count; i++)
        {
            quizOptionList[i].SetOptionState(true);
        }

    }

    //setproblem
    public void SetProblem(string problemName)
    {
        Reset();
     
        //사운드 세팅는 선택된 오브젝트에 사운드르 세팅!! 여기 수정하기 



        currenQuizObjectInformation = MainSystem.Instance.DataManager.QuizData.GetQuizObjectInformation(problemName);

        problem.text = currenQuizObjectInformation.problem;

        //현재 문제마다의 OPTION을 리스트로 따로 저장해두기 
        currentOptionTextList.Add(currenQuizObjectInformation.option_01);
        currentOptionTextList.Add(currenQuizObjectInformation.option_02);
        currentOptionTextList.Add(currenQuizObjectInformation.option_03);

        //틀린문제 set bool state
        quizOptionList[currenQuizObjectInformation.wrongOption].SetOptionState(false);

        //set text
        for (int i = 0; i < quizOptionList.Count; i++)
        {
            quizOptionList[i].SetOptionInformationText(currentOptionTextList[i]);
        }



        //Reset();


        //problem.text = quizDataInformationList[currentProblemIndex].problem;

        ////현재 문제마다의 OPTION을 리스트로 따로 저장해두기 
        //currentOptionTextList.Add(quizDataInformationList[currentProblemIndex].option_01);
        //currentOptionTextList.Add(quizDataInformationList[currentProblemIndex].option_02);
        //currentOptionTextList.Add(quizDataInformationList[currentProblemIndex].option_03);

        ////틀린문제 set bool state
        //quizOptionList[quizDataInformationList[currentProblemIndex].wrongOption].SetOptionState(false);

        ////set text
        //for (int i = 0; i < quizOptionList.Count; i++)
        //{
        //    quizOptionList[i].SetOptionInformationText(currentOptionTextList[i]);
        //}
    }

    public void NextProblem()
    {
        problemCorrectEvent?.Invoke();

        //exception Code
        if (currentProblemIndex < quizDataInformationList.Count)
        {
            currentProblemIndex++;
        }
            Debug.Log(currentProblemIndex);

        EndCheck();
    }

    public void EndCheck()
    {
        //문제를 다 맞추었을 경우

        if (currentProblemIndex >= quizDataInformationList.Count)
        {
            frame.SetActive(false);
            Debug.Log("문제 다풀었어요");
            problemFinishEvent?.Invoke();
        }
        else
        {
            //밖에서 event 연결해주기
            Debug.Log("문제 다xxx");

           // SetProblem();
            problemSetEvent.Invoke();
        }
    }
}