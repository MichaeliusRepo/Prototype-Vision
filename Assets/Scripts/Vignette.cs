using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vignette : MonoBehaviour
{
    public bool Disable;
    private readonly float MinimumScale = 0.6f;

    private RectTransform rectTransform;

    // Use this for initialization
    void Start()
    {
        if (!Disable)
            GetComponent<Image>().enabled = true;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        bool isActive = GetComponent<Image>().IsActive();

        float scale = rectTransform.localScale.x;

        if (scale > MinimumScale)
            scale -= (1.15f * Time.deltaTime);

        if (scale < MinimumScale)
            scale = MinimumScale;

        rectTransform.localScale = new Vector3(scale, scale, 0);
    }
}
