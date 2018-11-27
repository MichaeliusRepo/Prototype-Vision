using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    SpriteRenderer sr;
    public string sceneName;
    bool doorOpen = false;
    public bool trigger = true;
    GameObject[] target;
    public string objective = "Key";


    // Use this for initialization
    void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
                                     	
	}

    private void FixedUpdate()
    {
        if (trigger == true)
        {

            target = GameObject.FindGameObjectsWithTag(objective);
            bool cleared = false;


            Debug.Log(target.Length);
            if (target.Length == 0)
                doorOpen = true;
                        
        }

        if (trigger == false)
            doorOpen = true;


        if (doorOpen == false | target == null)
            sr.color = Color.black;
        if (doorOpen == true)
            sr.color = Color.yellow;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorOpen)
        {

            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(sceneName);
            }

        }
    }
}
