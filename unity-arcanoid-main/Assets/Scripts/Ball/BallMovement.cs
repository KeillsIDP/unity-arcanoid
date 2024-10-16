using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] 
    private int speed;
    private new Rigidbody2D rigidbody;
    private Vector2 savedPos;
    private float timeOnSamePos;
    private int ballStrength = 1;  

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(GetComponent<BallStartUp>())
            return;
        if(rigidbody.velocity.magnitude<5)
            rigidbody.velocity = transform.right * speed * 2;
        if(Vector2.Distance(savedPos,transform.position)>0.05f){
            savedPos = transform.position;
            timeOnSamePos = 0;
            return;
        }

        timeOnSamePos += Time.deltaTime;
        if(timeOnSamePos>0.5f){
            ChangeDirection(-transform.right);
            timeOnSamePos = 0;
        }
    }

private void OnCollisionEnter2D(Collision2D collision) {
    Vector2 normal = collision.contacts[0].normal;
    Vector2 randomDir = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
    Vector2 newDirection = Vector2.Reflect(transform.right, normal) + randomDir;
    ChangeDirection(newDirection);

   
    BaseCell cell = collision.gameObject.GetComponent<BaseCell>();
    if (cell != null)
    {
        for (int i = 0; i < ballStrength; i++)
        {
            cell.TakeDamage();  
        }
    }
}

    private void ChangeDirection(Vector2 direction){
        transform.right = direction;
        rigidbody.velocity = direction * speed;
    }

    public void SetBallStrength(int strength)
    {
        ballStrength = strength;
    }

    public void SetBallColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
