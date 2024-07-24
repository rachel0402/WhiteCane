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


        //���� ���� ����� ������ ����?

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
            Debug.Log("���� �ε�");
            Debug.Log("���� ���� or �����̼� ���� ����ؾ���");
            //���� �ε�
            //���� ��������
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
        Debug.Log("����!");
        MainSystem.Instance.ObjectManager.quizObject.currentSpeechRecognition = null;

        recordFrame.SetActive(false);
        ObjectVFX.SetActive(true);

        Deactive();
    }
    public void QuizINCorrect()
    {
        Debug.Log("Ʋ�Ⱦ��");

    }

    public void CheckAnswer(string answer)
    {
        // answer= currentSpeechRecognition.SendRocorginzeText();

        if (currenQuizObjectInformation.correctAnswer == answer)
        {
            Debug.Log("����!");
            isClear = true;

            MainSystem.Instance.ObjectManager.quizObject.currentSpeechRecognition = null;

            recordFrame.SetActive(false);
            ObjectVFX.SetActive(true);
        }
        else
        {

            Debug.Log("Ʋ�Ⱦ��");
            //Ʋ���Ҹ�
        }
    }

}
