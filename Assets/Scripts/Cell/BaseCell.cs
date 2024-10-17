using TMPro;
using UnityEngine;

public class BaseCell : MonoBehaviour
{
    [SerializeField] 
    private int health;
    [SerializeField]
    private int scoreBonus;
    [SerializeField]
    private Transform text;
    private static PlayerScore score;
    private static Camera camera;

    public void Start(){
        if(!score){
            score = FindObjectOfType<PlayerScore>();
        }

        if(!camera){
            camera = Camera.main;
        }
    }

    private void OnEnable() {
        text.transform.parent = FindObjectOfType<Canvas>().transform;
        text.GetComponent<TMP_Text>().text = health.ToString();
    }

    private void Update() {
        text.position = camera.WorldToScreenPoint(transform.position);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        BallDamage ballDamage = other.gameObject.GetComponent<BallDamage>();
        if(!ballDamage)
            return;
        
        health-=ballDamage.GetDamage();
        if(health<=0){
            score.AddScore(scoreBonus);
            gameObject.SetActive(false);  
            text.gameObject.SetActive(false);    
            Destroy(gameObject);  
        }
        text.GetComponent<TMP_Text>().text = health.ToString();
    }
}
