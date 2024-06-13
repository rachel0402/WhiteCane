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

    private void OnTriggerEnter(Collider other)
    {
        //���� ������Ʈ�� ��Ҵٸ�  or ��
        CollierCheckObject collierObject = other.GetComponent<CollierCheckObject>();

        if (collierObject != null)
        {
            activeProbelmName = collierObject.GetObjectName();
            outlineMaterial = collierObject.GetMaterialShader();

            SetEffectEnabled(true);
            //exception code
            Debug.Log("���⿡ problem set�ϱ�");

            //���⿡ problem set�ϱ�
            Debug.Log("enter");
            triggerEnterEvent?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SetEffectEnabled(false);

        Debug.Log("exit");
        triggerExitEvent?.Invoke();
    }

    void SetEffectEnabled(bool enabled)
    {
        outlineMaterial.SetFloat("_EffectEnabled", enabled ? 1.0f : 0.0f);
    }


}
