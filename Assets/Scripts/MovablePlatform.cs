using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MovablePlatform : MonoBehaviour
{
    public int BallNumberToPass;
    public int BallStored = 0 ;
    public GameObject balls;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
           Rigidbody rb =  other.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
            other.transform.parent = balls.transform;
            if(BallStored >= BallNumberToPass)
            {
                MovePlatformUp();
            }
        }
    }



    public void MovePlatformUp()
    {
        transform.DOLocalMoveY(0, 2f).OnComplete(() => ContinueGame()); 
    }

    public void BallStoredCount()
    {
        BallStored += 1;
        Debug.Log("ball");
    }

    public void ContinueGame()
    {
        PlayerMovement.Instance.SpeedUp();
        for (int i =0; i < transform.childCount - 1; i++)
        {
            balls.SetActive(false);
        }
    }
}
