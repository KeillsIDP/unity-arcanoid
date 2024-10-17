using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    private void Update() {
        source.volume = PlayerPrefs.GetFloat("mv");
    }
}
