using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class EnterRoomCheck : MonoBehaviour
{
    private bool isEnter = false;
    [SerializeField]
    private UnityEvent triggerEnterEvent;
}
public partial class EnterRoomCheck : MonoBehaviour
{
    //����������� �ڿ� �� �ݾƹ��� �׸��� �����̼� ����
    private void OnTriggerEnter(Collider other)
    {

        Cane player = other.GetComponent<Cane>();

        if (player != null && isEnter == false)
        {
            isEnter = true;
            Debug.Log("�÷��̾� �� ����enter");
            triggerEnterEvent?.Invoke();
        }
    }
}