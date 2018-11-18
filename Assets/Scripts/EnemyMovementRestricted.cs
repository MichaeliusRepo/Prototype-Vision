using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRestricted : MonoBehaviour {

    public Rigidbody2D rg;
    public int speed;
    public float floor;
    public LayerMask Terrain;



    // Use this for initialization
    void Start () {
        rg = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        Vector2 origin = rg.position;

        RaycastHit2D left = Physics2D.Raycast(new Vector2(origin.x - 0.5f, origin.y), Vector2.down, floor, Terrain);
        RaycastHit2D right = Physics2D.Raycast(new Vector2(origin.x + 0.5f, origin.y), Vector2.down, floor, Terrain);

        Debug.DrawRay(new Vector2(origin.x - 0.5f, origin.y),new Vector2(0, -floor), Color.black);
        Debug.DrawRay(new Vector2(origin.x + 0.5f, origin.y),new Vector2(0, -floor ), Color.black);

        if (rg.velocity.x == 0)
            speed = -speed;

        if (left.collider == false)
            speed = -speed;

        if (right.collider == false)
            speed = -speed;
        
        rg.velocity = new Vector2(speed, rg.velocity.y);
    }

}
