using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coinScript : MonoBehaviour
{
    public logicScript logic;
    bool moveCoin;
    public float speed = 5f;
    GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("toCoins");
    }

    private void Update()
    {
        if (moveCoin)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            logic.addCoins(1);
            moveCoin = true;
            //Destroy(gameObject, 1f);
        }
        if(collision.gameObject.tag == "toCoins" && moveCoin)
        {
            Destroy(gameObject);
        }
    }
}
