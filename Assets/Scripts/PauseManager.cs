using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject settingMenu;

    private void Update() {
        if(!Input.GetKeyDown(KeyCode.Escape))
            return;
        settingMenu.SetActive(false);
        if(pauseMenu.activeSelf){
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        } else {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}
