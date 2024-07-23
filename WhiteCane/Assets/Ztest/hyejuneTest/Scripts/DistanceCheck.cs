using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{

    CollierCheckObject currentCollierObject;

    private void OnTriggerEnter(Collider other)
    {
        //만약 오브젝트에 닿았다면  or 손
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
