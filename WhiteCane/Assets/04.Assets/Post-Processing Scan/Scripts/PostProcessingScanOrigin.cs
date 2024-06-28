using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PostProcessingScanOrigin : MonoBehaviour
{
    public Material material;
    public float customTime = 0.0f;
    public float maxTime = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        if (customTime < maxTime)
        {
            customTime += Time.deltaTime;
            if (material != null)
            {
                material.SetFloat("_CustomTime", customTime);
            }
        }
    }

    void LateUpdate()
    {
        material.SetVector("_Origin", transform.position);
    }

    public void Set_Origin(Vector3 set)
    {
        this.transform.position = set;
        customTime = 0.0f;
        material.SetFloat("_CustomTime", customTime);
    }
}
