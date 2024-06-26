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
        //    Debug.Log("QuizDataController 의 SET PROBLEM하기 /");

        //딱한 번만 ACTIVE
        Debug.Log("문제 세팅");
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

    public Material GetMaterialShader()
    {
        //내꺼에 대한 해당 오브젝트만
        return meshRenderer.materials[ountlineIndex];
    }
}