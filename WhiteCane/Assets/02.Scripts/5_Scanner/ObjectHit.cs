using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public Scanner Origin;

    private void OnCollisionEnter(Collision collision)
    {
        Origin.Set_Origin(this.transform.position);
    }
}
