using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   Rigidbody2D body;

float horizontal;
float vertical;

public float runSpeed = 8.0f;

void Start ()
{
   body = GetComponent<Rigidbody2D>(); 
}

void Update ()
{
    
   horizontal = Input.GetAxisRaw("Horizontal");
   if(horizontal > 0){
    transform.localScale = new Vector2(1.25f,1.25f);
   }else if (horizontal < 0){
    transform.localScale = new Vector2(-1.25f, -1.25f);
   }
   vertical = Input.GetAxisRaw("Vertical"); 
}

private void FixedUpdate()
{  
   body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
}
}
