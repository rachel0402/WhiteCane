using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{

    CollierCheckObject currentCollierObject;

    private void OnTriggerEnter(Collider other)
    {
        //���� ������Ʈ�� ��Ҵٸ�  or ��
        currentCollierObject = other.GetComponent<CollierCheckObject>();

        if (currentCollierObject != null)
        {
            currentCollierObject.DistanceEnter();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (currentCollierObject != null)
        {
            currentCollierObject.DistanceExit();
            currentCollierObject = null;
        }

    }
}
