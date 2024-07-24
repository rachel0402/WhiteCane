using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class CollierCheckObject : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;

    [SerializeField]
    private AudioSource sound;

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
        sound.Play();
    }
    public void DistanceExit()
    {
        particle.SetActive(false);
        sound.Pause();
    }

    //public Material GetMaterialShader()
    //{
    //    //내꺼에 대한 해당 오브젝트만
    //    return meshRenderer.materials[ountlineIndex];
    //}
}