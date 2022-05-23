using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MovablePlatform : MonoBehaviour
{
    public int BallNumberToPass;
    //public int BallStored = 0 ;
    public GameObject balls;
    public List<GameObject> Pointballs;
    public TextMeshPro PointcountText;


    private bool once = false;

    private void Update()
    {
        PointcountText.text = (Pointballs.Count + " /" + BallNumberToPass);
        if(PlayerMovement.Instance.speed <= 0)
        {
            CheckGameStatus();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Collider colider = other.gameObject.GetComponent<Collider>();
            colider.gameObject.SetActive(false);
            Rigidbody rb =  other.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;

            Pointballs.Add(other.gameObject);
            other.transform.parent = balls.transform;

        }
    }


    public void MovePlatformUp()
    {
        transform.DOLocalMoveY(0, 2f).OnComplete(() => ContinueGame()); 
    }

 /*   public void BallStoredCount()
    {
        BallStored += 1;
        Debug.Log("ball");
    }
 */
    public void ContinueGame()
    {
        PlayerMovement.Instance.SpeedUp();
        for (int i =0; i < Pointballs.Count - 1; i++)
        {
            Pointballs[i].gameObject.SetActive(false);
        }
    }

    public void CheckGameStatus()
    {
        Debug.Log("pointballs " + Pointballs.Count);
        Debug.Log("ball numbers " + BallNumberToPass);

        if (Pointballs.Count >= BallNumberToPass)
        {
            MovePlatformUp();
        }

        else
        {
            if (!once)
            {
                once = true;
                //UIManager.Instance.FailPanel.SetActive(true);
            }
        }
    }

   
}
