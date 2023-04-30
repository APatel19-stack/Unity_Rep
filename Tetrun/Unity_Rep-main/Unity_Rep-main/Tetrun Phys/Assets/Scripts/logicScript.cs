using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class logicScript : MonoBehaviour
{
    public Text coinsText;
    public int coinCount = 0;
    public int level;
    public playerScript playerScript;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject player;
    public Text timerText;
    public static logicScript instance;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;
    public Text finalTime;
    public Text bestTime;
    public float bestCheck;
    private bool hasPlayed = false;
    private string stillBest; 

    private void Start()
    {
        bestCheck = 10000f;
        bestTimeCheck();
        hasPlayed = true;
        level = 1;
        timerText.text = "00:00.00";
        beginTimer();
    }

    void Update()
    {
        if (playerScript.outBounds)
        {
            restartLevel();
            playerScript.outBounds = false;
        }
    }

    [ContextMenu("Increase Coins")]
    public void addCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        coinsText.text = coinCount.ToString();
    }

    [ContextMenu("Timer")]
    private void Awake()
    {
        instance = this;
    }

    public void beginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void endTimer()
    {
        timerGoing = false;
        
        
        bestTimeCheck();
    }

    public void bestTimeCheck()
    {
        if(elapsedTime < bestCheck)
        {
            finalTime.text = timerText.text;
            stillBest = finalTime.text;
            bestCheck = elapsedTime;
            bestTime.text = "Best Time:\n" + finalTime.text;
        } else if(elapsedTime > bestCheck)
        {
            bestTime.text = "Best Time:\n" + stillBest;
            finalTime.text = timerText.text;
        } else
        {
            bestTime.text = "Best Time:\n00.00:00";
        }
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = timePlayingStr;

            yield return null;
        }
    }



    private void levelCheck()
    {

    }

    public void restartLevel()
    {
        if(level == 1)
        {
            Debug.Log("reset");
            playerScript.outBounds = true;
            playerScript.currentLevel = spawn1;
        } else if(level == 2)
        {
            playerScript.outBounds = true;
            playerScript.currentLevel = spawn2;
        }
        
    }

    public void victory()
    {
        SceneManager.LoadScene(4);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        level = 1;
    }

    public void death()
    {
        SceneManager.LoadScene(3);
    }
}
