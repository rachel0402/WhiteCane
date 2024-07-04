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
        //���� ������Ʈ�� ��Ҵٸ�  or ��
        quizObject = other.GetComponent<QuizObject>();

        if (quizObject != null)
        {

            Debug.Log("������ ���� ���� ����");
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
