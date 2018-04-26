using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifting : MonoBehaviour {

  public float speed = 1;
  public float vanishingHeight = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * Time.deltaTime * speed);
    if (transform.position.y > vanishingHeight) {
      Destroy(gameObject);
    }
	}

}
