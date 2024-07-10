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
    }

    bool isMove = false;
    bool isStop = false;


    bool isSelect = false;
    public void Button()
    {
        //  button.action.

        isSelect = button.action.ReadValue<bool>();
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

                Debug.Log("∏ÿ√„");
            }

        }
        else
        {
            isStop = true;

            if (isMove)
            {
                moveEvent?.Invoke();
                isMove = false;
                Debug.Log("øÚ¡˜¿”");

            }
            //move
        }
    }

    //public void moveState(bool isState)
    //{
    //    isMove = isState;
    //}

}

