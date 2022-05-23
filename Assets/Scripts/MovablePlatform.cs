using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using MoreMountains.NiceVibrations;

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
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {

            Collider colider = other.gameObject.GetComponent<Collider>();
            colider.enabled = false;
            colider.gameObject.SetActive(false);
            Rigidbody rb =  other.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;

            Pointballs.Add(other.gameObject);
            other.transform.parent = balls.transform;
            if (!once)
            {
                once = true;
                Invoke("CheckGameStatus", 0.7f);
            }

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

        if (Pointballs.Count >= BallNumberToPass)
        {
            MovePlatformUp();
            Destroy(this);
        }

        else
        {
      
         UIManager.Instance.FailPanel.SetActive(true);
         MMVibrationManager.Vibrate();

        }
    }

   
}
