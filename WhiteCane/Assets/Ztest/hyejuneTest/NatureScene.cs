using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial  class NatureScene : MonoBehaviour
{
    [SerializeField]
    UnityEvent InitializeEvent;
}
public partial class NatureScene : MonoBehaviour
{
    private void Start()
    {
        InitializeEvent?.Invoke();
    }

}