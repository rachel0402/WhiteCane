using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public partial class RespawnController : MonoBehaviour
{


    [SerializeField]
    private GameObject frame;

    private bool isActive = true;
    private float selectState;

    [SerializeField]
    private InputActionReference skipButton;


    [SerializeField]
    private RespawnPosition respawnPosition;

    [SerializeField]
    private UnityEvent activeEvent;
    [SerializeField]
    private UnityEvent deactiveEvent;


}
public partial class RespawnController : MonoBehaviour
{
    private void Awake()
    {
    }
    private void Update()
    {
        if (isRespawnActive)
        {
            Respawn();
        }

        //�ϴ� ���� �׽�Ʈ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RespawnPosition();
        }
    }
    public void Initialize()
    {
    }
}
public partial class RespawnController : MonoBehaviour
{
    public void SetFrameActiveState(bool state)
    {
        frame.SetActive(state);
    }

    public void Active()
    {
        SetFrameActiveState(true);
        activeEvent?.Invoke();
    }
    public void Deactive()
    {
        SetFrameActiveState(false);
        deactiveEvent?.Invoke();
    }

    private void RespawnPosition()
    {
        //������ ��Ű��
        respawnPosition.SetRespawnPosition();
        Deactive();


        isRespawnActive = false;
        Debug.Log("������");
    }

    //��� ������ ��ư�� Ȱ��ȭ �ɶ���!
    public void Respawn()
    {
        selectState = skipButton.action.ReadValue<float>();

        if (selectState == 0)
        {
            isActive = true;
        }
        else
        {
            if (isActive)
            {
                RespawnPosition();
                isActive = false;
            }
        }
    }

    private bool isRespawnActive = false;

    public void SetRespawnButtonState(bool state)
    {
        isRespawnActive = state;
    }
}