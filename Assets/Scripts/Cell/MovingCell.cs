using UnityEngine;

public class MovingCell : MonoBehaviour
{
    [SerializeField] 
    private int movementDelta;
    [SerializeField] 
    private int speed;
    [SerializeField]
    private LayerMask boundsMask;
    private float startX;
    private void Start() {
        startX = transform.position.x;
    }
    private void Update() {
        if(Physics2D.Raycast(transform.position,transform.right,0.1f,boundsMask).collider)
            transform.right = -transform.right;
        if((transform.position + transform.right/5).x>=startX+movementDelta 
            || (transform.position + transform.right/5).x<=startX-movementDelta)
            transform.right = -transform.right;
        transform.position = Vector2.MoveTowards(transform.position,transform.position+transform.right/5,Time.deltaTime*speed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        transform.right = -transform.right;
    }
}
