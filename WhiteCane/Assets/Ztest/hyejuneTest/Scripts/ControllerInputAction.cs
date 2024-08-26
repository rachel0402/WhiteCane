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
    private InputActionReference a_Button;
    [SerializeField]
    private InputActionReference b_Button;

    bool isMove = false;
    bool isStop = false;

    bool isButtonActive = false;

    float isSelect = 0;
    float isTestSelect = 0;


    private Vector2 inputStickValue;

    [SerializeField]
    UnityEvent ButtonBEvent;


    [SerializeField]
    UnityEvent moveEvent;

    [SerializeField]
    UnityEvent stopMoveEvent;

    public void Update()
    {
        StickMove();
         QuizButton();
        QuizTestButton();
    }


    public void QuizTestButton()
    {

        //이거야 스킵 b
        isTestSelect = b_Button.action.ReadValue<float>();

        if (isTestSelect == 0)
        {

        }
        else
        {
            if (MainSystem.Instance.ObjectManager.quizObject.currentSpeechRecognition != null)
            {
                MainSystem.Instance.ObjectManager.quizObject.QuizCorrect();
                isButtonActive = false;

                Debug.Log("퀴즈버튼 켜기 ++ 임시임 quizbutton이 원래 맞음 ㅇㅋ?");
            }
        }
    }

    bool aButtonPress = false;

    public void QuizButton()
    {

        isSelect = a_Button.action.ReadValue<float>();

        if (isSelect == 0)
        {
            if (MainSystem.Instance.ObjectManager.quizAcitve == false && isButtonActive)
            {
                if (MainSystem.Instance.ObjectManager.quizObject.currentSpeechRecognition != null)
                {
                    aButtonPress = false;
                    MainSystem.Instance.ObjectManager.quizObject.currentSpeechRecognition.StopRecording();
                    isButtonActive = false;
                    Debug.Log("퀴즈버튼 끄기");
                }

            }
        }
        else
        {
            if (MainSystem.Instance.ObjectManager.quizAcitve && aButtonPress==false)
            {
                MainSystem.Instance.ObjectManager.quizObject.currentSpeechRecognition.StartRecording();

                MainSystem.Instance.ObjectManager.quizAcitve = false;

                aButtonPress = true;
                Debug.Log("퀴즈버튼 켜기");
                Debug.Log(isSelect);

                isButtonActive = true;

            }

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

                Debug.Log("멈춤");
            }

        }
        else
        {
            isStop = true;

            if (isMove)
            {
                moveEvent?.Invoke();
                isMove = false;
                Debug.Log("움직임");

            }
            //move
        }
    }
}

