using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public  int TabCount;

    public void OnTap(int tapCount)
    {
        TabCount = tapCount;
        Debug.Log(TabCount);
    }
}
