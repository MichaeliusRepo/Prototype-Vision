using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInactive : MonoBehaviour {

    public string triggerTag = "Player";

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == triggerTag)
            gameObject.active = false;
    }

}
