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
    private QuizOption quizOptionPrefab;
    [SerializeField]
    private Transform optionParent;
    [SerializeField]
    private TMP_Text problem;

    //���� ������Ʈ ����
    [SerializeField]
    private List<QuizOption> quizOptionList = new List<QuizOption>();


    private List<QuizData.QuizDataInformation> quizDataInformationList = new List<QuizData.QuizDataInformation>();

    private List<string> currentOptionTextList = new List<string>();

    //���� ������ȣ
    private int currentProblemIndex;

    //������ ���⿡ ����
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

        //quiz object�� ���� ������ŭ ����
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


    //���� 

    private void Reset()
    {
        currentOptionTextList.Clear();

        //quizDataInformationList�� CLEAR �ϸ� �ȵ�, �� �ȿ� �����ʹ� CLEAR �ص� ����

        for (int i = 0; i < quizOptionList.Count; i++)
        {
            quizOptionList[i].SetOptionState(true);
        }

    }

    //setproblem
    public void SetProblem(string problemName)
    {
        Reset();
     
        //���� ���ô� ���õ� ������Ʈ�� ���帣 ����!! ���� �����ϱ� 



        currenQuizObjectInformation = MainSystem.Instance.DataManager.QuizData.GetQuizObjectInformation(problemName);

        problem.text = currenQuizObjectInformation.problem;

        //���� ���������� OPTION�� ����Ʈ�� ���� �����صα� 
        currentOptionTextList.Add(currenQuizObjectInformation.option_01);
        currentOptionTextList.Add(currenQuizObjectInformation.option_02);
        currentOptionTextList.Add(currenQuizObjectInformation.option_03);

        //Ʋ������ set bool state
        quizOptionList[currenQuizObjectInformation.wrongOption].SetOptionState(false);

        //set text
        for (int i = 0; i < quizOptionList.Count; i++)
        {
            quizOptionList[i].SetOptionInformationText(currentOptionTextList[i]);
        }



        //Reset();


        //problem.text = quizDataInformationList[currentProblemIndex].problem;

        ////���� ���������� OPTION�� ����Ʈ�� ���� �����صα� 
        //currentOptionTextList.Add(quizDataInformationList[currentProblemIndex].option_01);
        //currentOptionTextList.Add(quizDataInformationList[currentProblemIndex].option_02);
        //currentOptionTextList.Add(quizDataInformationList[currentProblemIndex].option_03);

        ////Ʋ������ set bool state
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
        //������ �� ���߾��� ���

        if (currentProblemIndex >= quizDataInformationList.Count)
        {
            frame.SetActive(false);
            Debug.Log("���� ��Ǯ�����");
            problemFinishEvent?.Invoke();
        }
        else
        {
            //�ۿ��� event �������ֱ�
            Debug.Log("���� ��xxx");

           // SetProblem();
            problemSetEvent.Invoke();
        }
    }
}