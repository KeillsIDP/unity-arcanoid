using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    private Transform healthIconsHandler;
    [SerializeField]
    private GameObject ballStartUp;
    [SerializeField]
    private GameObject endScreen;

    private int health = 3;

    public void AddHealth(){
        if(health>=3)
            return;
        health++;

        for(int i = 0; i<healthIconsHandler.childCount; i++){
            GameObject gameObject = healthIconsHandler.GetChild(i).gameObject;
            if(gameObject.activeSelf)
                continue;
            
            gameObject.SetActive(true);
            break;
        }
    }

    public void DecreaseHealth(){
        health--;
        for(int i = healthIconsHandler.childCount-1; i>=0; i--){
            GameObject gameObject = healthIconsHandler.GetChild(i).gameObject;
            if(!gameObject.activeSelf)
                continue;
            
            gameObject.SetActive(false);
            break;
        }

        if(health<=0)
            endScreen.SetActive(true);
            
        ballStartUp.SetActive(true);
    }
}
