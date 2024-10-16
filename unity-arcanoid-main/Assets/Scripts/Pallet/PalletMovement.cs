using System;
using System.Collections.Generic;
using UnityEngine;

public class PalletMovement : MonoBehaviour
{
    [SerializeField] 
    private int speed;
    [SerializeField]
    private bool mouseInput;
    [SerializeField] 
    private List<Transform> bounds;
    private Camera camera;

    private void Start() {
        camera = Camera.main;
    }

    private void Update()
    {
        if(mouseInput)
            MouseMovement();
        else
            KeyboardMovement();
    }

    private void KeyboardMovement(){
        float input = Input.GetAxisRaw("Horizontal");
        Movement(transform.position+transform.right*input);
    }

    private void MouseMovement(){
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        float input = camera.ScreenToWorldPoint(mousePosition).x;
        Movement(new Vector2(input+0.5f,transform.position.y));
    }

    private void Movement(Vector2 destination){
        foreach(Transform bound in bounds){
            float posX = bound.position.x;
            int boundSign = Math.Sign(posX);

            if (boundSign>0 && transform.position.x>posX && destination.x>posX)
                return;
            else if (boundSign<0 && transform.position.x<posX && destination.x<posX)
                return;
        }

        transform.position = Vector2.MoveTowards(transform.position,
                                                 destination,
                                                 Time.deltaTime * speed);
    }
}
