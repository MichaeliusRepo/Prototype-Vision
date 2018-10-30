using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerVisionController : MonoBehaviour
{

    public float ForceTime;

    public bool DisableVisionFeatures;


    private bool Vision = false;
    private bool visionChanged;
    private float timeLeft = 0;

    // Use this for initialization
    void Start()
    {
        if (!DisableVisionFeatures)
            UpdateVisibility();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        bool input = Input.GetKey(KeyCode.T);

        if (timeLeft <= 0 && Vision != input)
        {
            visionChanged = true;
            Vision = input;
        }
    }

    private void LateUpdate()
    {
        if (DisableVisionFeatures) return; // For debugging reasons

        if (visionChanged)
        {
            UpdateVisibility();

            visionChanged = false;
            timeLeft = ForceTime;
        }
        if (timeLeft > 0 )
            timeLeft -= Time.deltaTime;

    }

    private void UpdateVisibility()
    {
        var environments = GameObject.FindGameObjectsWithTag("Environment");
        foreach (var en in environments)
        {
            var spriteRenderer = en.gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
                spriteRenderer.enabled = !Vision;

            var tilemapRenderer = en.gameObject.GetComponent<TilemapRenderer>();
            if (tilemapRenderer != null)
                tilemapRenderer.enabled = !Vision;
        }

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
            enemy.gameObject.GetComponent<SpriteRenderer>().enabled = Vision;
    }
}
