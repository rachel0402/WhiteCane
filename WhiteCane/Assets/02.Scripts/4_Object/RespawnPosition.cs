using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPosition : MonoBehaviour
{
    [SerializeField]
    private Transform currentRespawnTransform;

   
    [SerializeField]
    private Transform myTransform;

    private RespawnPoint respawnPoint;

    public void SaveCurrentRespawnTransform(Transform transform)
    {
        currentRespawnTransform = transform;
    }

    public void SetRespawnPosition()
    {
        myTransform.position = currentRespawnTransform.position;
    }





    public void OnCollisionEnter(Collision collision)
    {
        //respawnPoint �����ϱ�
        respawnPoint = collision.gameObject.GetComponent<RespawnPoint>();


        //respawnPoint �� �־������
        if (respawnPoint != null)
        {
            //���� ��üȮ���ϱ�
            SaveCurrentRespawnTransform(collision.gameObject.transform);
        }
    }
}
