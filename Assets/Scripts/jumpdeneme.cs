using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class jumpdeneme : MonoBehaviour
{
    public bool Jump;
   
    void Update()
    {
        if(Jump)
        transform.DOJump(new Vector3(transform.position.x, 2f, transform.position.z+3), 3f, 1, 1f);
        Jump = false;
    }
}
