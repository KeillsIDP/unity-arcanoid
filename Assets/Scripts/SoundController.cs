using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider soundSlider;
    public void ChangeMusicVolume(){
        PlayerPrefs.SetFloat("mv",musicSlider.value);
    }

    public void ChangeSoundVolume(){
        PlayerPrefs.SetFloat("sv",soundSlider.value);
    }
}
