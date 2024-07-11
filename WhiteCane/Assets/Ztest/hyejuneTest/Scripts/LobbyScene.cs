using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LobbyScene : MonoBehaviour
{
    [SerializeField]
    private UnityEvent InitializeEvent;

    private void Start()
    {
        InitializeEvent?.Invoke();
    }
}
