using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerVisionController : MonoBehaviour
{

    public float Cooldown;
    public GameObject VisionBackground;
    public bool DisableVisionFeatures;


    private bool Vision = false;
    private bool visionChanged;
    private float timeLeft = 0;
    private PlayerSoundTriggers sfxPlayer;

    // Use this for initialization
    void Start()
    {
        sfxPlayer = GetComponent<PlayerSoundTriggers>();
        if (!DisableVisionFeatures)
            UpdateVisibility();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        bool input = Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3);

        if (timeLeft <= 0 && input)
        {
            visionChanged = true;
            Vision = !Vision;
        }
    }

    private void LateUpdate()
    {
        if (DisableVisionFeatures) return; // For debugging reasons

        if (visionChanged)
        {
            UpdateVisibility();

            visionChanged = false;
            timeLeft = Cooldown;
            sfxPlayer.PlayToggleSFX();
        }
        if (timeLeft > 0)
            timeLeft -= Time.deltaTime;

        //if (Vision)
        //{
        //    var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        //    VisionBackground.GetComponent<Transform>().position = new Vector3(PlayerPosition.x, PlayerPosition.y, 15);
        //}


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

            var vignette = en.gameObject.GetComponent<RectTransform>();
            if (vignette != null)
                vignette.localScale = new Vector3(3, 3, 0);
        }

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
            enemy.gameObject.GetComponent<SpriteRenderer>().enabled = Vision;

        var visionDoors = GameObject.FindGameObjectsWithTag("Vision Door");
        foreach (var visionDoor in visionDoors)
        {
            visionDoor.gameObject.GetComponent<SpriteRenderer>().enabled = !Vision;
            visionDoor.gameObject.GetComponent<BoxCollider2D>().enabled = !Vision;
        }

        VisionBackground.GetComponent<SpriteRenderer>().enabled = Vision;
        //var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        //VisionBackground.GetComponent<Transform>().position = new Vector3(PlayerPosition.x, PlayerPosition.y, 15);
    }
}
