using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour {

    public Rigidbody2D rg;
    public float gravityStrength;

    // Use this for initialization
    void Start () {
        rg = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //if (rg.velocity.y == 0)
            //rg.AddForce(new Vector2(0,-1));
            //rg.velocity = new Vector2(rg.velocity.x, gravityStrength);

    }
}
