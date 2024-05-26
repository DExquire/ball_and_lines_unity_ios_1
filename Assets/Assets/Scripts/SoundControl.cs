using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public void SwitchOnSound(bool trig)
    {
        Debug.Log("sound " + trig);
        Camera.main.GetComponent<AudioListener>().enabled = trig;
    }
}
