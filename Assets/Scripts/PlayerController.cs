using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rigidbody;
    public int HorizontalSpeed;
    public int VerticalJumpSpeed;

    private bool grounded = false;


    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }
	

	// Update is called once per frame
	void Update () {
        grounded = (rigidbody.velocity.y == 0);


	}

    private void FixedUpdate()
    {
        var x = HorizontalSpeed * Input.GetAxis("Horizontal");
        var y = (Input.GetKey(KeyCode.UpArrow) && grounded) ? VerticalJumpSpeed : rigidbody.velocity.y;
        rigidbody.velocity = new Vector2(x, y);

    }

}
