using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class deneme : MonoBehaviour
{
    public UnityEvent closeBall;
   
    
    private void OnCollisionEnter(Collision collision)
    {
        closeBall?.Invoke();
    }
}
