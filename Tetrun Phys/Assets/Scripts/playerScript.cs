using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class playerScript : MonoBehaviour {

    private Rigidbody2D rb;
    private float jump = 11f;
    private float speed = 8f;
    public GameObject indicator;
    private bool canJump = true;
    public int health = 6;
    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public bool outBounds = false;
    public logicScript logic;
    public GameObject currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            canJump = false;
        }

        //if (!Mathf.Approximately(0, moveX))
        //{
        //    transform.rotation = moveX > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        //}

        checkHealth();

        if (outBounds)
        {
            transform.position = currentLevel.transform.position;
            outBounds = false;
        }

        if(health <= 0)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;

        if (collision.gameObject.tag == "spike" && health > 0)
        {
            health--;
        }
    }

    private void checkHealth()
    {
        // player health
        if (health == 6)
        {
            heart3.GetComponent<Image>().sprite = fullHeart;
            heart2.GetComponent<Image>().sprite = fullHeart;
            heart1.GetComponent<Image>().sprite = fullHeart;
        }
        else if (health == 5)
        {
            heart3.GetComponent<Image>().sprite = halfHeart;
            heart2.GetComponent<Image>().sprite = fullHeart;
            heart1.GetComponent<Image>().sprite = fullHeart;
        }
        else if (health == 4)
        {
            heart3.GetComponent<Image>().sprite = emptyHeart;
            heart2.GetComponent<Image>().sprite = fullHeart;
            heart1.GetComponent<Image>().sprite = fullHeart;
        }
        else if (health == 3)
        {
            heart3.GetComponent<Image>().sprite = emptyHeart;
            heart2.GetComponent<Image>().sprite = halfHeart;
            heart1.GetComponent<Image>().sprite = fullHeart;
        }
        else if (health == 2)
        {
            heart3.GetComponent<Image>().sprite = emptyHeart;
            heart2.GetComponent<Image>().sprite = emptyHeart;
            heart1.GetComponent<Image>().sprite = fullHeart;
        }
        else if (health == 1)
        {
            heart3.GetComponent<Image>().sprite = emptyHeart;
            heart2.GetComponent<Image>().sprite = emptyHeart;
            heart1.GetComponent<Image>().sprite = halfHeart;
        }
        else if (health <= 0)
        {
            heart3.GetComponent<Image>().sprite = emptyHeart;
            heart2.GetComponent<Image>().sprite = emptyHeart;
            heart1.GetComponent<Image>().sprite = emptyHeart;
            Debug.Log("dead");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "outOfBounds")
        {
            logic.restartLevel();
            transform.position = currentLevel.transform.position;
        }
        if(collision.gameObject.tag == "endLevel")
        {
            logic.level++;
            logic.restartLevel();
            transform.position = currentLevel.transform.position;
        }
        if(collision.gameObject.tag == "finalLevel")
        {
            logic.victory();
        }
    }

    public void Death()
    {
        logic.restartLevel();
        transform.position = currentLevel.transform.position;
        health = 6;
    }
}
