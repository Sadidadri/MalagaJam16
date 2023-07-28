using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Configuracion movimiento player
    Rigidbody2D body;
    float horizontal;
    float vertical;

    //Configuracion de disparo
    public GameObject bulletPrefab;
    float shootingPositionOffset = 0.8f;
    Vector2 lastPositionBulletStart = Vector2.right;
    //public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    public float runSpeed = 20.0f;

    void Start ()
    {
    body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
        // Movimiento del personaje
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical");

    if(horizontal != 0 || vertical != 0) {
        lastPositionBulletStart.x = horizontal;
        lastPositionBulletStart.y = vertical;
    }
        

    if(horizontal > 0){

        transform.localScale = new Vector2(1.25f,1.25f);
    }else if (horizontal < 0){
        transform.localScale = new Vector2(-1.25f, -1.25f);
    }

    //Disparo del personaje
    if (Time.time >= nextFireTime)
        {
            if (Input.GetKey(KeyCode.Space)) // Change this to the input you want to use for shooting
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    
    private void FixedUpdate()
        {  
            //Movimiento del jugador
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }

        private void Shoot()
        {
            Vector2 shootingDirection = new Vector2( body.transform.position.x + (lastPositionBulletStart.x * shootingPositionOffset), body.transform.position.y + (lastPositionBulletStart.y * shootingPositionOffset));
            GameObject bullet = Instantiate(bulletPrefab, shootingDirection, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            
            bulletRigidbody.velocity = lastPositionBulletStart * (runSpeed + 5.0f) ;
        }


}