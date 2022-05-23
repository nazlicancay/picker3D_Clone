using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> levels = new List<GameObject>();
    public GameObject Player;
    public int levelCount = 1;
    public int levelCountDisplay = 1;
    public bool NextLevel;
    public UIManager uı;
    public PlayerMovement playerMovement;
    public GameManager gameManager;
    public bool nextlevel;



   
    void Start()
    {
        levelCount = PlayerPrefs.GetInt("levelCount");
        if (levelCount >= levels.Count)
        {
            levelCount = 0;
            PlayerPrefs.SetInt("levelCount", levelCount);
        }
        levelCountDisplay = PlayerPrefs.GetInt("levelDisplay");
        uı.Levelcount.text = "Level " + levelCountDisplay;
        Instantiate(levels[levelCount]);
        if (nextlevel)
        {
            uı.StartText.SetActive(false);
        }


    }


    public void UpdateLevel()
    {

        nextlevel = true;
        levelCount++;
        levelCountDisplay++;
        Debug.Log(levelCountDisplay);
        PlayerPrefs.SetInt("levelCount", levelCount);
        PlayerPrefs.SetInt("levelDisplay", levelCountDisplay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //GameManager.Instance.StartGame();
        uı.FailPanel.gameObject.SetActive(false);
        if (levelCount == 0)
        {
            levels[levelCount].gameObject.SetActive(true);
        }
        else
        {
            levels[levelCount - 1].gameObject.SetActive(true);

        }

    }

}