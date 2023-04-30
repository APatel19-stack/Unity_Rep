using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class mainMenuLogic : MonoBehaviour
{
    public Text bestTime;
    private int laps = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(laps == 0)
        {
            bestTime.text = "Best Time:\n00.00:00";
            laps++;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
