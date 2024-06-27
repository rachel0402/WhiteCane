using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class CollierCheckObject : MonoBehaviour
{
    [SerializeField]
    string myObjectName;

    [SerializeField]
    MeshRenderer meshRenderer;

    [SerializeField]
    int ountlineIndex= 1;

    [SerializeField]
    private UnityEvent activeEvent;
    [SerializeField]
    private UnityEvent deactiveEvent;
}
public partial class CollierCheckObject : MonoBehaviour
{
    public void Active()
    {
        //    Debug.Log("QuizDataController �� SET PROBLEM�ϱ� /");

        //���� ���� ACTIVE
        Debug.Log("���� ����");
        MainSystem.Instance.DataManager.QuizData.QuizDataController.SetProblem(myObjectName);

        activeEvent?.Invoke();
    }
    public void Deactive()
    {
        deactiveEvent?.Invoke();
    }
    public string GetObjectName()
    {
        return myObjectName;
    }
    [SerializeField]
    private GameObject particle;
    public void DistanceEnter()
    {
        particle.SetActive(true);
    }
    public void DistanceExit()
    {
        particle.SetActive(false);
    }
    public Material GetMaterialShader()
    {
        //������ ���� �ش� ������Ʈ��
        return meshRenderer.materials[ountlineIndex];
    }
}