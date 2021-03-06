using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent GameStarted;
    public GameObject StartText;

    private void Update()
    {
        if (StartText.activeInHierarchy && Input.touchCount>0)
        {
            GameStarted.Invoke();
        }

        if(Input.GetMouseButtonDown(0) && StartText.activeInHierarchy)
        {
            GameStarted.Invoke();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
