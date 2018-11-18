using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour {

    private Rigidbody2D rg;

	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 10) // 9 is Enemy Layer, 10 is Traps
        {
            //Debug.Log("Oh yeah baby!");
            gameObject.SetActive(false);

            //other.gameObject.SetActive(false);

            RestartGame();
        }

    }


    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
