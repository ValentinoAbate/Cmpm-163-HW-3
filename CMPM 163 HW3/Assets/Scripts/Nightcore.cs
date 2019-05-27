using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Nightcore : MonoBehaviour
{
    private AudioSource src;
    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void NightcoreMode(bool on)
    {
        src.pitch = on ? 1.25f : 1;
    }
}
