using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class CollierCheckObject : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;


    //[SerializeField]
    //MeshRenderer meshRenderer;

    //[SerializeField]
    //int ountlineIndex= 1;

    [SerializeField]
    private UnityEvent activeEvent;
    [SerializeField]
    private UnityEvent deactiveEvent;
}
public partial class CollierCheckObject : MonoBehaviour
{
    public void Active()
    {
        activeEvent?.Invoke();
    }
    public void Deactive()
    {
        deactiveEvent?.Invoke();
    }

    public void DistanceEnter()
    {
        //Distance Check
        particle.SetActive(true);
    }
    public void DistanceExit()
    {
        particle.SetActive(false);
    }

    //public Material GetMaterialShader()
    //{
    //    //������ ���� �ش� ������Ʈ��
    //    return meshRenderer.materials[ountlineIndex];
    //}
}