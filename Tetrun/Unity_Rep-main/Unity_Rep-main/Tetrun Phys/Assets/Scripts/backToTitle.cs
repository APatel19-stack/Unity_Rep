using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToTitle : MonoBehaviour
{
    public Scene scene;
    public void backTitle()
    {
        SceneManager.LoadScene(0);
    }
}
