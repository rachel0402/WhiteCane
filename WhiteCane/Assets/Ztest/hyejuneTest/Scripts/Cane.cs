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
        //���� ������Ʈ�� ��Ҵٸ�  or ��
        currentCollierObject = other.GetComponent<CollierCheckObject>();

        if (currentCollierObject != null)
        {
            activeProbelmName = currentCollierObject.GetObjectName();

            Debug.Log(activeProbelmName);
            outlineMaterial = currentCollierObject.GetMaterialShader();

            SetEffectEnabled(true);
            //exception code


        Debug.Log("���� ����");
            currentCollierObject.Active();

            //���⿡ problem set�ϱ�
            Debug.Log("enter");
            triggerEnterEvent?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SetEffectEnabled(false);


        Debug.Log("���⿡ DEACTIVE �߰����ְ�");
        triggerExitEvent?.Invoke();
    }

    void SetEffectEnabled(bool enabled)
    {
        outlineMaterial.SetFloat("_EffectEnabled", enabled ? 1.0f : 0.0f);
    }


}
