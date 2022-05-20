using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerCollisionController : MonoBehaviour
{
    public UnityEvent OnBallInside;
    public UnityEvent OnBallOutside;

    [ContextMenu("On Trigger Enter")]
    public void OnTriggerEnterr()
    {

        OnBallInside?.Invoke();

    }

    [ContextMenu("On Trigger Exit")]
    public void OnTriggerExitt()
    {

        OnBallOutside?.Invoke();

    }

}
