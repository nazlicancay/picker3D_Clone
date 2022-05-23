using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Slope : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.Instance.playerTransform.DORotate( new Vector3(-20,0,0),0.5f);
            PlayerMovement.Instance.MoveUp();

          
        }
    }
}
