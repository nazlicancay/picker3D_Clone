using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLine : MonoBehaviour
{
    public int touchCount;


    public void CountTouch()
    {
        if(Input.touchCount > 0 && Input.GetMouseButtonDown(0))
        {
            touchCount += 1;
        }
    }
}
