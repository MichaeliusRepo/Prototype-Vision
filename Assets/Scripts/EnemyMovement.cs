using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Rigidbody2D rg;
    public int Speed;

    //private bool goingRight;

	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody2D>();
        //goingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        

	}

    private void FixedUpdate()
    {
        if (rg.velocity.x == 0)
            Speed = -Speed;

        rg.velocity = new Vector2(Speed, rg.velocity.y);


    }
}
