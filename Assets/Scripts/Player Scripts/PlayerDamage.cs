using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour {

    //private Rigidbody2D rg;
    Renderer rend;
    Color c;
    bool immunity;
    public int HitPoints;
    private static int lifePoints;
    float recoveryTime;
    private PlayerSoundTriggers sfxPlayer;

    // Use this for initialization
    void Start () {
        //rg = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        immunity = false;
        //lifePoints = 3;
        recoveryTime = 3;
        sfxPlayer = GetComponent<PlayerSoundTriggers>();
        lifePoints = HitPoints;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other) //Enemy interaction and damage
    {
        if ((other.gameObject.layer == 9 || other.gameObject.layer == 10) && immunity == false) // 9 is Enemy Layer, 10 is Traps
        {
            if (lifePoints > 1)
            {
                StartCoroutine("ImmunityFrames");
                lifePoints -= 1;
                sfxPlayer.PlayHitSFX();
            }
            else
            {
                RestartGame();
            }
            //Debug.Log("Oh yeah baby!");
            //gameObject.SetActive(false);
            //other.gameObject.SetActive(false);
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>()
        }
    }
    IEnumerator ImmunityFrames()
    {
        Physics2D.IgnoreLayerCollision(0, 9, true);
        immunity = true;
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(recoveryTime);
        Physics2D.IgnoreLayerCollision(0, 9, false);
        immunity = false;
        c.a = 1f;
        rend.material.color = c;
    }


    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
