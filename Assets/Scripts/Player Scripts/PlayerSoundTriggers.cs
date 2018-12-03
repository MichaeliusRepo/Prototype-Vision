using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundTriggers : MonoBehaviour
{

    // Remember to disable "Mute Audio" while game is running!

    public AudioClip landSFX;
    public AudioClip toggleSFX;
    public AudioClip hitSFX;
    private Rigidbody2D rg;
    private Vector3 previousVelocity;

    // Use this for initialization
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        //source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentVelocity = rg.velocity;

        // Landed
        if (previousVelocity.y < -2 && currentVelocity.y == 0)
            AudioSource.PlayClipAtPoint(landSFX, rg.position);

        previousVelocity = currentVelocity;
    }

    public void PlayToggleSFX() { AudioSource.PlayClipAtPoint(toggleSFX, rg.position); }
    public void PlayHitSFX() { AudioSource.PlayClipAtPoint(hitSFX, rg.position); }

}
