using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorScript : MonoBehaviour
{

    public GameObject block;
    public Transform blockTrans;
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && !triggered)
        {
            Debug.Log("spawn block");
            Instantiate(block, blockTrans.position, Quaternion.identity);
            triggered = true;
        }
    }
}
