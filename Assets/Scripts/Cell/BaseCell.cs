using UnityEngine;

public class BaseCell : MonoBehaviour
{
    [SerializeField] 
    private int health;
    [SerializeField]
    private int scoreBonus;

    private static PlayerScore score;

    public void Start(){
        if(!score){
            score = FindObjectOfType<PlayerScore>();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        health--;
        if(health==0){
            score.AddScore(scoreBonus);
            gameObject.SetActive(false);      
            Destroy(gameObject);  
        }
    }
}
