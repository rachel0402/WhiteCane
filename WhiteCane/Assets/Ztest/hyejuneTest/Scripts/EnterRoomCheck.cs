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
    //입장했을경우 뒤에 문 닫아버려 그리고 나레이션 실행
    private void OnTriggerEnter(Collider other)
    {

        Cane player = other.GetComponent<Cane>();

        if (player != null && isEnter == false)
        {
            isEnter = true;
            Debug.Log("플레이어 방 입장enter");
            triggerEnterEvent?.Invoke();
        }
    }
}