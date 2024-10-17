using UnityEngine;

public class GreenCell : MonoBehaviour
{
    [SerializeField] 
    private GameObject bonusPrefab; 

    private void OnDestroy() {
        if(Time.timeScale == 0)
            return;
        Instantiate(bonusPrefab, transform.position, Quaternion.identity);
    }
}
