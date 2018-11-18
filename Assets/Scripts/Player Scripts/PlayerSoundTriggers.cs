using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundTriggers : MonoBehaviour {

    // Remember to disable "Mute Audio" while game is running!

    public AudioClip landSFX;
    private Rigidbody2D rg;
    private Vector3 previousVelocity;

    // Use this for initialization
    void Start () {
        rg = GetComponent<Rigidbody2D>();
        //source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 currentVelocity = rg.velocity;

        // Landed
        if (previousVelocity.y < 0 && currentVelocity.y == 0)
            AudioSource.PlayClipAtPoint(landSFX, rg.position);

        previousVelocity = currentVelocity;
    }

}
