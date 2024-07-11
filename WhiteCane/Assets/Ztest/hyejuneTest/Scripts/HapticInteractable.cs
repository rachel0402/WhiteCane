using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HapticInteractable : MonoBehaviour
{
    [SerializeField]
    HapticImpulsePlayer controller;

    [Range(0, 1)]
    public float intensity;
    public float duration;

    private void Update()
    {
    }

    public void ActiveHaptic()
    {
        controller.SendHapticImpulse(intensity, duration);
    }


    public void Active()
    {

    }
}
