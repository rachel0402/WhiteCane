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

}
public partial class CollierCheckObject : MonoBehaviour
{
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