using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public partial class Cane : MonoBehaviour
{
    QuizObject quizObject;

    //SpeechRecognition ;
    [SerializeField]
    private UnityEvent triggerEnterEvent;
    [SerializeField]
    private UnityEvent triggerExitEvent;

    private bool isSelecting = false;
}
public partial class Cane : MonoBehaviour
{

    //quiz Set
    private void OnTriggerEnter(Collider other)
    {
        ////���� ���� ������Ʈ�� ���� ������Ʈ�� ���ؼ�;
        //QuizObject currentQuizObject =  other.GetComponent<QuizObject>();



        quizObject = other.GetComponent<QuizObject>();

        if (quizObject != null && isSelecting == false)
        {

            isSelecting = true;


            Debug.Log("������ ���� ���� ����");
            quizObject.QuizLoad();

            Debug.Log("enter");
            triggerEnterEvent?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (quizObject != null)
        {
            triggerExitEvent?.Invoke();
            isSelecting = false;
        }
    }

}
