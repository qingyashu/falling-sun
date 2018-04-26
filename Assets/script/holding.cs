using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holding : MonoBehaviour {

  private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
    
	}
	
	// Update is called once per frame
	void Update () {
	  if (Input.GetKeyDown("space")) {
      animator.SetTrigger("holding");
    }
    else if (Input.GetKeyUp("space")) {
      animator.SetTrigger("exitHolding");
    }
	}
  
}
