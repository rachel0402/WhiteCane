using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class Cane : MonoBehaviour
{
    [SerializeField]
    private UnityEvent triggerEnterEvent;
    [SerializeField]
    private UnityEvent triggerExitEvent;

    string activeProbelmName;

    Material outlineMaterial;


    CollierCheckObject currentCollierObject;

    private void OnTriggerEnter(Collider other)
    {
        //만약 오브젝트에 닿았다면  or 손
        currentCollierObject = other.GetComponent<CollierCheckObject>();

        if (currentCollierObject != null)
        {
            activeProbelmName = currentCollierObject.GetObjectName();

            Debug.Log(activeProbelmName);
            outlineMaterial = currentCollierObject.GetMaterialShader();

            SetEffectEnabled(true);
            //exception code


        Debug.Log("문제 세팅");
            currentCollierObject.Active();

            //여기에 problem set하기
            Debug.Log("enter");
            triggerEnterEvent?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SetEffectEnabled(false);


        Debug.Log("여기에 DEACTIVE 추가해주가");
        triggerExitEvent?.Invoke();
    }

    void SetEffectEnabled(bool enabled)
    {
        outlineMaterial.SetFloat("_EffectEnabled", enabled ? 1.0f : 0.0f);
    }


}
