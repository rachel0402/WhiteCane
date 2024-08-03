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
        ////지금 닿은 오브젝트랑 과거 오브젝트랑 비교해서;
        //QuizObject currentQuizObject =  other.GetComponent<QuizObject>();



        quizObject = other.GetComponent<QuizObject>();

        if (quizObject != null && isSelecting == false)
        {

            isSelecting = true;


            Debug.Log("지팡이 닿음 문제 세팅");
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
