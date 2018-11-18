using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{

    // Source: Rakesh's blog, "2D Background Scrolling & Parallax Scolling in Unity3D"
    // December 6th, 2016, by Rakesh Malik

    private Rigidbody2D target;
    public float speed;

    private float initPos;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        this.transform.position = target.position;
        initPos = transform.localPosition.x;
        GameObject objectCopy = GameObject.Instantiate(this.gameObject);
        Destroy(objectCopy.GetComponent<ScrollBackground>());
        objectCopy.transform.SetParent(this.transform);
        objectCopy.transform.localPosition = new Vector3(getWidth(), 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float targetVelocity = target.velocity.x;
        // Using -speed was the for speedup, omit minus for slowdown.
        //this.transform.Translate(new Vector3(-speed * targetVelocity, 0, 0) * Time.deltaTime);
        this.transform.Translate(new Vector3(speed * targetVelocity, 0, 0) * Time.deltaTime);

        float width = getWidth();

        if (targetVelocity > 0)
        {
            if (initPos - this.transform.localPosition.x > width)
                this.transform.Translate(new Vector3(width, 0, 0));
        }
        else
            if (initPos - this.transform.localPosition.x < 0)
            this.transform.Translate(new Vector3(-width, 0, 0));

        //var targetPos = target.position;
        this.transform.position = new Vector3(this.transform.position.x, target.position.y, this.transform.position.z);
    }

    float getWidth()
    {
        return this.GetComponent<SpriteRenderer>().bounds.size.x;
    }
}
