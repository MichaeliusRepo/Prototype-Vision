using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementToggleOnce : MonoBehaviour
{

    // For some reason, this script only shows the text once.
    // I don't know why, but it kinda works. So it's cool, I guess...?

    public GameObject TextField;
    private Text text;
    private float alpha = 0;
    private float add = 0;


    // Use this for initialization
    void Start()
    {
        text = TextField.GetComponent<Text>();
        text.color = new Color(1, 1, 1, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (add == 0) return;

        alpha += add;
        Mathf.Clamp(alpha, 0, 1);
        text.color = new Color(1, 1, 1, alpha);

        if (alpha == 0 || alpha == 1)
            add = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
            add = 0.01f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
            add = -0.01f;
    }
}
