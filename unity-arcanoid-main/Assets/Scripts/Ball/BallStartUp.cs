using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallStartUp : MonoBehaviour
{
    [SerializeField] 
    private int startForce;

    private Rigidbody2D rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(!Input.GetMouseButtonDown(0))
            return;

        transform.parent = null;
        rigidbody.AddForce(Vector2.up*startForce);
        
        transform.right = Vector2.up;
        Destroy(this);
    }
}
