using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public partial class QuizObject : MonoBehaviour
{
    [SerializeField]
    private GameObject ObjectVFX;
    [SerializeField]
    private GameObject recordFrame;

    [HideInInspector]
    public SpeechRecognition currentSpeechRecognition;

    private string answer = default;

    [SerializeField] private string quizName;

    // [SerializeField] private TMP_Text problem;

    private QuizData.QuizDataInformation currenQuizObjectInformation;

    [SerializeField]
    Collider Objectcollider;

    [SerializeField]
    private UnityEvent activeEvent;
    [SerializeField]
    private UnityEvent deactiveEvent;

    private bool isClear = false;

}
public partial class QuizObject : MonoBehaviour
{
    public void Active()
    {
        MainSystem.Instance.DataManager.QuizData.QuizDataController.ActiveQuizObject(this);
        currentSpeechRecognition = recordFrame.GetComponent<SpeechRecognition>();


        //여기 사운드 출력은 ㄱㅊ지 않음?

        recordFrame.SetActive(true);
        activeEvent?.Invoke();
    }
    public void Deactive()
    {
        Objectcollider.enabled=false;
        deactiveEvent?.Invoke();
    }

    public void QuizLoad()
    {
        if (isClear == false)
        {
            Debug.Log("문제 로딩");
            Debug.Log("질문 세팅 or 나레이션 사운드 출력해야함");
            //문제 로드
            //질문 세팅해줌
            currenQuizObjectInformation = MainSystem.Instance.DataManager.QuizData.GetQuizObjectInformation(quizName);


            //setQuiz
            MainSystem.Instance.ObjectManager.SetQuizObject(this);

            Active();
        }

    }
    public void GetRecohnize()
    {

    }

    public void QuizCorrect()
    {
        Debug.Log("정답!");
        MainSystem.Instance.ObjectManager.quizObject.currentSpeechRecognition = null;

        recordFrame.SetActive(false);
        ObjectVFX.SetActive(true);

        Deactive();
    }
    public void QuizINCorrect()
    {
        Debug.Log("틀렸어요");

    }

    public void CheckAnswer(string answer)
    {
        // answer= currentSpeechRecognition.SendRocorginzeText();

        if (currenQuizObjectInformation.correctAnswer == answer)
        {
            Debug.Log("정답!");
            isClear = true;

            MainSystem.Instance.ObjectManager.quizObject.currentSpeechRecognition = null;

            recordFrame.SetActive(false);
            ObjectVFX.SetActive(true);
        }
        else
        {

            Debug.Log("틀렸어요");
            //틀린소리
        }
    }

}
