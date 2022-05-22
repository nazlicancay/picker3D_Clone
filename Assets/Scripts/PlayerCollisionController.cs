using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerCollisionController : MonoBehaviour
{
    public UnityEvent OnBallInside;
    public UnityEvent OnBallOutside;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            OnBallInside?.Invoke();

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
