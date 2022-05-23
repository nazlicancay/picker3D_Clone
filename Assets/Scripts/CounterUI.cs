using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterUI;

    int count;

    public void CountUp()
    {
        count++;
        counterUI.text = count.ToString();
    }

    public void CountDown()
    {
        count--;
        counterUI.text = count.ToString();
    }
}
