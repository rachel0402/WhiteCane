using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PostProcessingScanOrigin : MonoBehaviour
{
    public Material material;
    public float customTime = 0.0f;
    public float maxTime = 1.0f;
    public Light point_light;

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
        Vector3 newPosition = new Vector3(set.x, point_light.transform.position.y, set.z);
        point_light.transform.position = newPosition;
        customTime = 0.0f;
        material.SetFloat("_CustomTime", customTime);
    }
}
