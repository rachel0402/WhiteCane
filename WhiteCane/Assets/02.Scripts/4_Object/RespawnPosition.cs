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
        //respawnPoint 저장하기
        respawnPoint = collision.gameObject.GetComponent<RespawnPoint>();


        //respawnPoint 가 있어야지만
        if (respawnPoint != null)
        {
            //닿은 물체확인하기
            SaveCurrentRespawnTransform(collision.gameObject.transform);
        }
    }
}
