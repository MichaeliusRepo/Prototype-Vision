using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rg;
    public int HorizontalSpeed;
    public int VerticalJumpSpeed;
    public LayerMask Terrain;
    public float CeilingDistance;

    private bool grounded = false;


    // Use this for initialization
    void Start () {
        rg = GetComponent<Rigidbody2D>();
    }
	

	// Update is called once per frame
	void Update () {
        grounded = (rg.velocity.y == 0);

        Vector2 origin = rg.position;


        RaycastHit2D topLeftHit = Physics2D.Raycast(new Vector2(origin.x - 0.4f, origin.y), Vector2.up, CeilingDistance, Terrain);
        RaycastHit2D topRightHit = Physics2D.Raycast(new Vector2(origin.x + 0.4f, origin.y), Vector2.up, CeilingDistance, Terrain);


        if (topRightHit.collider != null || topLeftHit.collider != null)
        { // Did hit!
            grounded = false;
            rg.velocity = new Vector2(rg.velocity.x, 0);
            rg.AddForce(new Vector2(0, -5));
        }


        if (rg.velocity.y == 0)
            rg.AddForce(new Vector2(0, -5));



    }

    private void FixedUpdate()
    {
        var x = HorizontalSpeed * Input.GetAxis("Horizontal");
        var y = (Input.GetKey(KeyCode.UpArrow) && grounded) ? VerticalJumpSpeed : rg.velocity.y;
        rg.velocity = new Vector2(x, y);

    }

}
