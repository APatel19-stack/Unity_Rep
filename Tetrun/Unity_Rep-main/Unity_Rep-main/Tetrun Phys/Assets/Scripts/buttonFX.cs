using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource mySound;
    [SerializeField] private AudioClip hover, clicked;

    public void HoverSound()
    {
        //mySound.PlayOneShot(hover);
        soundManager.instance.playSound(hover);
    }

    public void ClickSound()
    {
        //mySound.PlayOneShot(clicked);
        soundManager.instance.playSound(clicked);
    }
}
