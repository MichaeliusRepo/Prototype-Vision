using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Rigidbody2D rg;
    public float speed = 2f;
    public float floordistance = 0.5f;
    public float hitdistance = 0.05f;
    public LayerMask terrain;
    public LayerMask entities;
    public bool horizontal = true;
    public bool restricted = false;
    public bool friendhit = false;
    public bool gravity = true;
    int dir = 1;


    //private bool goingRight;

    // Use this for initialization
    void Start () {
        rg = GetComponent<Rigidbody2D>();
        if (gravity == false)
            rg.gravityScale = 0;
        //goingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        

	}

    private void FixedUpdate()
    {
        if (horizontal == true) {
            if (rg.velocity.x == 0) {
                speed = -speed;
                dir = dir * -1;
            }
            

            Vector2 origin = rg.position;

            if (restricted == true) {

                

                RaycastHit2D downleft = Physics2D.Raycast(new Vector2(origin.x - 0.5f, origin.y), Vector2.down, floordistance, terrain);
                RaycastHit2D downright = Physics2D.Raycast(new Vector2(origin.x + 0.5f, origin.y), Vector2.down, floordistance, terrain);

                

                Debug.DrawRay(new Vector2(origin.x - 0.5f, origin.y), new Vector2(0, -floordistance), Color.black);
                Debug.DrawRay(new Vector2(origin.x + 0.5f, origin.y), new Vector2(0, -floordistance), Color.black);

                

                if (downleft.collider == false)
                {
                    speed = -speed;
                    dir = dir * -1;
                }

                if (downright.collider == false)
                {
                    speed = -speed;
                    dir = dir * -1;
                }
                

            }

            if (friendhit == false) {

                Vector2 sidewalk = new Vector2(1*dir, 0);
                RaycastHit2D topcheck = Physics2D.Raycast(new Vector2(origin.x +.55f*dir, origin.y + .4f), sidewalk, hitdistance, entities);
                RaycastHit2D midcheck = Physics2D.Raycast(new Vector2(origin.x +.55f*dir, origin.y), sidewalk, hitdistance, entities);
                RaycastHit2D botcheck = Physics2D.Raycast(new Vector2(origin.x +.55f*dir, origin.y - .4f), sidewalk, hitdistance, entities);

                Debug.DrawRay(new Vector2(origin.x +.55f*dir, origin.y + .4f), sidewalk, Color.black);
                Debug.DrawRay(new Vector2(origin.x +.55f*dir, origin.y), sidewalk, Color.black);
                Debug.DrawRay(new Vector2(origin.x +.55f*dir, origin.y - .4f), sidewalk, Color.black);

                if (topcheck.collider == true || midcheck.collider == true || botcheck.collider == true) {

                    speed = -speed;
                    dir = dir*-1;

                }

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
