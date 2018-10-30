using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisionController : MonoBehaviour {

    private bool Vision;

	// Use this for initialization
	void Start () {
        Vision = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Vision = (Input.GetKey(KeyCode.T));
    }

    private void LateUpdate()
    {
        var environments = GameObject.FindGameObjectsWithTag("Environment");
        foreach (var en in environments)
        {
            var spriteRenderer = en.gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
                spriteRenderer.enabled = !Vision;
        }

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
            enemy.gameObject.GetComponent<SpriteRenderer>().enabled = Vision;

    }
}
