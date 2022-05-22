using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    PlayerMovement movement;


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            movement = other.GetComponentInParent<PlayerMovement>();

            movement.speedDown();
        }
    }
}
