using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public  int TabCount;
    public bool startCount;

    public void OnTap(int tapCount)
    {
         TabCount = tapCount;
         Debug.Log(TabCount);
        
        
    }
}
