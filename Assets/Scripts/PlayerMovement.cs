using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    //Configuracion movimiento player
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float PLAYER_ORIENTATION_SCALE = 1;


    //Configuracion de disparo
    public GameObject bulletPrefab;
    float shootingPositionOffset = 0.8f;
    Vector2 lastPositionBulletStart = Vector2.right;
    //public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    //Config lanzallamas
    public GameObject flameThrower;
    public float flamethrowerDuration = 3f; // Duration of the flamethrower in seconds
    private bool isFlamethrowerActive = false;
    float offset = 2.8f;

    public float runSpeed = 20.0f;

    //Leveling count
    [SerializeField] Text levelText;
    int levelNumber;

    void Start ()
    {
        flameThrower.SetActive(false);
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
    levelNumber = int.Parse(levelText.text);
    // Movimiento del personaje
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical");

    if(horizontal != 0 || vertical != 0) {
        lastPositionBulletStart.x = horizontal;
        lastPositionBulletStart.y = vertical;
    }
        

    if(horizontal > 0){
        flameThrower.transform.position = new Vector2(transform.position.x + offset,transform.position.y + .5f);
        transform.localScale = new Vector2(PLAYER_ORIENTATION_SCALE * -1,PLAYER_ORIENTATION_SCALE);
    }else if (horizontal < 0){
        flameThrower.transform.position = new Vector2((transform.position.x - offset ) ,transform.position.y +.5f);
        transform.localScale = new Vector2(PLAYER_ORIENTATION_SCALE, PLAYER_ORIENTATION_SCALE);
    }else{
        flameThrower.transform.position = new Vector2(flameThrower.transform.position.x,transform.position.y + .5f);
    }

    if(levelNumber >= 3){
         if (Input.GetKey(KeyCode.E)) 
            {
                ActivateFlamethrower();

            }
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

    // Call this function to activate the flamethrower
    public void ActivateFlamethrower()
    {
        if (!isFlamethrowerActive)
        {
            StartCoroutine(ActivateFlameThrowerCoroutine());
        }
    }

      private IEnumerator ActivateFlameThrowerCoroutine()
    {
        isFlamethrowerActive = true;

        
        if (flameThrower != null)
        {
            flameThrower.SetActive(true);
        }


        // Wait for the ability duration
        yield return new WaitForSeconds(flamethrowerDuration);


        flameThrower.SetActive(false);
        isFlamethrowerActive = false;
    }

    
    private void FixedUpdate()
        {  
            //Movimiento del jugador
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }

        private void Shoot()
        {
            Vector2 shootingDirection = new Vector2( body.transform.position.x + (lastPositionBulletStart.x * shootingPositionOffset), body.transform.position.y + (lastPositionBulletStart.y * shootingPositionOffset) + .5f);
            
            GameObject bullet = BulletObjectPool.SharedInstance.GetPooledObject(); 
            if (bullet != null) {
                bullet.SetActive(true);
                bullet.transform.position = shootingDirection;
                Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
                bulletRigidbody.velocity = lastPositionBulletStart * (runSpeed + 5.0f) ;
            }
        //GameObject bullet = Instantiate(bulletPrefab, shootingDirection, Quaternion.identity);
        //Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        //bulletRigidbody.velocity = lastPositionBulletStart * (runSpeed + 5.0f) ;
        }


}