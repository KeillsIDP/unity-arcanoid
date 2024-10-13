using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;
    [SerializeField]
    private int amount;
    [SerializeField]
    private int maxGapsInARow;
    [SerializeField]
    private Transform genStart;
    [SerializeField]
    private Transform genBound;

    private int gapsInARow;

    private void Start() {
        Vector2 offsetX = new Vector2(prefabs[0].transform.localScale.x,0);
        Vector2 offsetY = new Vector2(0,prefabs[0].transform.localScale.y)/2;

        Vector2 currentPos = genStart.position;
        for(int i = 0; i<amount;i++){
            if(currentPos.x>genBound.position.x){
                currentPos -= offsetY;
                currentPos.x = genStart.position.x;
                i--;
                continue;
            }


            if(gapsInARow<maxGapsInARow && Random.Range(-1,5)<0){
                gapsInARow++;
                currentPos+=offsetX;
                continue;
            }

            gapsInARow = 0;
            GameObject prefab = Instantiate(prefabs[Random.Range(0,prefabs.Count)],currentPos,Quaternion.identity,transform);
            currentPos+=offsetX;
        }
    }
}
