using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{

    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Origin(Vector3 set)
    {
        this.transform.position = set;
        particle.Play();
    }
}
