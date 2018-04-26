using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour {

  private bool hasCollided = false;
  public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.tag == "Player" && !hasCollided) {
      AudioClip sfx = audioClips[Random.Range(0,6)];
      AudioSource.PlayClipAtPoint(sfx, gameObject.transform.position);
      GameManager.gm.ScoreUp();
      hasCollided = true;
    }
  }
}
