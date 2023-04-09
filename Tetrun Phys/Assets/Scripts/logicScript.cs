using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        level = 1;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        level = 1;
    }
}
