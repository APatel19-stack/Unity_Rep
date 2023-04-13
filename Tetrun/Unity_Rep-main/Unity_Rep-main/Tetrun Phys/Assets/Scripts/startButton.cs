using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public void StartGame()
    {
        // buttonClick.Play(1);
        SceneManager.LoadScene(1);
    }
}
