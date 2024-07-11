using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class FootSound : MonoBehaviour
{
    [SerializeField]
   private AudioSource footAudio;
}
public partial class FootSound : MonoBehaviour
{
    public void FootSoundActive()
    {
        footAudio.Play();
    }
    public void FootSoundDeactive()
    {
        footAudio.Stop();
    }
}