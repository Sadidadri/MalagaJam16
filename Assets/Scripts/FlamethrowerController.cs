using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerController : MonoBehaviour
{

    public string playerTag = "Player";
    float offset = 2.8f;

    public float damageTime = 0.5f; // Adjust this value to set the duration of hit
    private bool damagingInProgress = false;
    private float damageTimer = 0f;

    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    private void Update()
    {
        transform.position = new Vector2(offset + playerTransform.position.x,playerTransform.position.y);
    }

}
