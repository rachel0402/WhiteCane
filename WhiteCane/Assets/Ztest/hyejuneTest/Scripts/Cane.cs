using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public partial class Cane : MonoBehaviour
{
    QuizObject quizObject;


    [SerializeField]
    private UnityEvent triggerEnterEvent;
    [SerializeField]
    private UnityEvent triggerExitEvent;


}
public partial class Cane : MonoBehaviour
{

    //quiz Set
    private void OnTriggerEnter(Collider other)
    {
        //만약 오브젝트에 닿았다면  or 손
        quizObject = other.GetComponent<QuizObject>();

        if (quizObject != null)
        {

            Debug.Log("지팡이 닿음 문제 세팅");
            quizObject.QuizLoad();

            Debug.Log("enter");
            triggerEnterEvent?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent?.Invoke();
    }


}
