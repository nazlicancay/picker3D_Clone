using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;
using UnityEngine.Events;
public class PlayerCollisionController : Singleton<PlayerCollisionController>
{
    public UnityEvent OnBallInside;
    public UnityEvent OnBallOutside;
    public int BallCount = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            MMVibrationManager.Vibrate();
            OnBallInside?.Invoke();

        }

        if (other.gameObject.CompareTag("Win"))
        {
            UIManager.Instance.WinPanel.SetActive(true);
            MMVibrationManager.Vibrate();
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
    {
            OnBallOutside?.Invoke();
            

        }

    }

   

    

}
