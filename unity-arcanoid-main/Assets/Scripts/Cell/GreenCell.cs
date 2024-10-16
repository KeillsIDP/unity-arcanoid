using UnityEngine;

public class GreenCell : MonoBehaviour
{
    [SerializeField] 
    private int health;
    [SerializeField]
    private int scoreBonus;
    [SerializeField] 
    private GameObject bonusPrefab; 

    private static PlayerScore score;

    public void Start()
    {
        if (!score)
        {
            score = FindObjectOfType<PlayerScore>();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        health--;

        if (health == 0)
        {
            score.AddScore(scoreBonus);

            if (bonusPrefab != null)
            {
                Instantiate(bonusPrefab, transform.position, Quaternion.identity);
            }

 
            gameObject.SetActive(false);      
            Destroy(gameObject);  
        }
    }
}
