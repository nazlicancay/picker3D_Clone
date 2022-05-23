using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLine : MonoBehaviour
{

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.Instance.JumpMove();
            PlayerMovement.Instance.Jumpforward = PlayerController.Instance.TabCount + 1.1f * 10f;
            Debug.Log(PlayerController.Instance.TabCount);
           

        }
    }
}
