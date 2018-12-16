using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string SceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Stops invincibility frames from carrying over to new level.
        Physics2D.IgnoreLayerCollision(0, 9, false);

        if (collision.tag == "Player")
            SceneManager.LoadScene(SceneName);
    }


}
