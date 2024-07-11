using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public partial class ColliderEnterCheck : MonoBehaviour
{
    [SerializeField]
    private UnityEvent activeEvent;
    [SerializeField]
    private UnityEvent deactiveEvent;
}
public partial class ColliderEnterCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("¿Ãµø");
            activeEvent?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}