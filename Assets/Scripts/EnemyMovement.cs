using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Rigidbody2D rg;
    public int speed;
    public bool horizontal = true;
    public bool restricted = false;
    public float floor;
    public LayerMask Terrain;


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
        if (horizontal == true) {
            if (rg.velocity.x == 0)
                speed = -speed;

            if (restricted == true) {

                Vector2 origin = rg.position;

                RaycastHit2D left = Physics2D.Raycast(new Vector2(origin.x - 0.5f, origin.y), Vector2.down, floor, Terrain);
                RaycastHit2D right = Physics2D.Raycast(new Vector2(origin.x + 0.5f, origin.y), Vector2.down, floor, Terrain);

                Debug.DrawRay(new Vector2(origin.x - 0.5f, origin.y), new Vector2(0, -floor), Color.black);
                Debug.DrawRay(new Vector2(origin.x + 0.5f, origin.y), new Vector2(0, -floor), Color.black);

                if (left.collider == false)
                    speed = -speed;

                if (right.collider == false)
                    speed = -speed;

            }

            rg.velocity = new Vector2(speed, rg.velocity.y);
        }

        if (horizontal == false) {
            if (rg.velocity.y == 0)
                speed = -speed;

            rg.velocity = new Vector2(rg.velocity.x, speed);
        } 
            


    }
}
