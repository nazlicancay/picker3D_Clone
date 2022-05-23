using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FinishLineCreator : MonoBehaviour
{
    public GameObject scoreCube;
    public List<GameObject> scoreCubes = new List<GameObject>();
    public TextMeshPro Text;
    int Score = 100;
    public int MaxScore;
    float posy;
    public Transform FinisLinePos;
    void Update()
    {

        CreateScoreCubes();
    }

    public void CreateScoreCubes()
    {

        if (Score < MaxScore)
        { 
            GameObject clone = Instantiate(scoreCube);
            clone.transform.parent = FinisLinePos;
            posy = clone.transform.position.z;
            scoreCubes.Add(clone);
            clone.transform.DOMoveZ( posy + scoreCubes.Count*4, 0.5f);
            GameObject child = scoreCubes[scoreCubes.Count - 1].transform.GetChild(0).gameObject;
            Score += 50;
            TextMeshPro text = child.GetComponentInChildren<TextMeshPro>();
            text.text = Score.ToString();


        }


    }

}