using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControllerInputAction : MonoBehaviour
{
    [SerializeField]
    private InputActionReference stick;
    [SerializeField]
    private InputActionReference button;


    private Vector2 inputStickValue;

    [SerializeField]
    UnityEvent moveEvent;

    [SerializeField]
    UnityEvent stopMoveEvent;

    public void Update()
    {
        StickMove();
        Button();
    }

    bool isMove = false;
    bool isStop = false;


    float isSelect =0;
    public void Button()
    {
        //  button.action.

        isSelect = button.action.ReadValue<float>();

        if(isSelect==0)
        {

            Debug.Log("��ưxxx");
            Debug.Log(isSelect);
        }
        else
        {
                Debug.Log("��ư����");
            Debug.Log(isSelect);

        }
    }
    public void StickMove()
    {
        inputStickValue = stick.action.ReadValue<Vector2>();

        if (inputStickValue == Vector2.zero)
        {
            //not move
            isMove = true;


            if (isStop)
            {
                stopMoveEvent?.Invoke();
                isStop = false;

                Debug.Log("����");
            }

        }
        else
        {
            isStop = true;

            if (isMove)
            {
                moveEvent?.Invoke();
                isMove = false;
                Debug.Log("������");

            }
            //move
        }
    }

    //public void moveState(bool isState)
    //{
    //    isMove = isState;
    //}

}

