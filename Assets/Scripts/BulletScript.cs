using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Camera"))
        {
           //Simular destruccion del gameobject
            gameObject.SetActive(false);
        }
    }
}