using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    private GameObject scannerObject;

    [SerializeField]
    private ParticleSystem Particle;
    private bool start = false;
    public float time = 0.0f;
    public float fin = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Particle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (time < fin)
            {
                time += Time.deltaTime;
                if (!Particle.isPlaying)
                {
                    Particle.Play();
                }
            }
            else
            {
                start = false;
                Particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                time = 0.0f; // Reset time for the next use

                scannerObject.SetActive(false);
            }
        }
    }

    public void Set_Origin(Vector3 set)
    {
        this.transform.position = set;
        Particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        start = true;
        time = 0.0f; // Reset time when starting
    }
}