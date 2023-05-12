using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goTosetting : MonoBehaviour
{
    public Scene scene;
    public void toSetting()
    {
        SceneManager.LoadScene(2);
    }
}
