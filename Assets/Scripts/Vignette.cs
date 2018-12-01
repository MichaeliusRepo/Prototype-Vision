using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vignette : MonoBehaviour {

    public bool Disable;


	// Use this for initialization
	void Start () {
        if (!Disable)
            GetComponent<Image>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
