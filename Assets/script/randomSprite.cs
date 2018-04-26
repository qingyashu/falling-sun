using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
    int i = Random.Range(1, 6);
    string spriteName = "sprite" + i.ToString();
    gameObject.transform.Find(spriteName).gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
