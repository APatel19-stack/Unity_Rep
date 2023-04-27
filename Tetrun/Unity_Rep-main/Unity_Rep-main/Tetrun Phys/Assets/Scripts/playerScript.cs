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
    public int health = 1;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public bool outBounds = false;
    public logicScript logic;
    public GameObject currentLevel;
    public AudioSource playerSound;
    [SerializeField] private AudioClip jumpSound, deathSound, rotationSound;

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
            soundManager.instance.playSound(jumpSound);
            rb.velocity = new Vector2(rb.velocity.x, jump);
            canJump = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            soundManager.instance.playSound(rotationSound);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            soundManager.instance.playSound(rotationSound);
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
            health = 0;
        }
    }

    private void checkHealth()
    {
        // player health check
        if (health <= 0)
        {
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
            logic.endTimer();
            logic.victory();
        }
    }

    public void Death()
    {
        soundManager.instance.playSound(deathSound);
        logic.death();
    }
}
