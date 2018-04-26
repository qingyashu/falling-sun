using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  [Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
  public GameObject player;

  public enum gameStates {Playing, Death, GameOver};
  public gameStates gameState = gameStates.Playing;
  public int score = 0;
  public static int maxScore = 0;

  public AudioSource backgroundMusic;
  public AudioClip gameOverSFX;

  public GameObject playingCanvas;
  public Text mainScoreDisplay;
  public GameObject gameoverCanvas;
  public Text gameOverScoreDisplay;
  public Text maxScoreDisplay;

  public GameObject spawner;

  public static GameManager gm;

	// Use this for initialization
	void Start () {
		if (gm == null) {
      gm = gameObject.GetComponent<GameManager>();
    }

    if (player == null) {
      player = GameObject.FindWithTag("Player");
    }
    playingCanvas.SetActive(true);
    gameoverCanvas.SetActive(false);
    maxScoreDisplay.text = "Highest: " + maxScore.ToString();
    spawner.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Application.Quit();
    }
		switch (gameState) {
      case gameStates.Playing:
        break;
      case gameStates.Death:
        if (backgroundMusic) {
          backgroundMusic.volume -= 0.01f;
          if (backgroundMusic.volume <= 0.0f) {
            AudioSource.PlayClipAtPoint(gameOverSFX, gameObject.transform.position);
            gameState = gameStates.GameOver;
          }
        }
        else {
          AudioSource.PlayClipAtPoint(gameOverSFX, gameObject.transform.position);
          gameState = gameStates.GameOver;
        }

        break;
      case gameStates.GameOver:
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {
          SceneManager.LoadScene("play");
        }
        break;
    }
	}

  public void DropDeadZone() {
    playingCanvas.SetActive (false);
    gameoverCanvas.SetActive (true);
    spawner.SetActive (false);
    GameObject []clouds = GameObject.FindGameObjectsWithTag("cloud");
    foreach (GameObject cloud in clouds) {
      cloud.SetActive(false);
    }
    gameState = gameStates.Death;
    if (score > maxScore) {
      maxScore = score;
    }
    gameOverScoreDisplay.text = score.ToString() + " / " + maxScore.ToString();
  }

  public void ScoreUp() {
    this.score ++;
    mainScoreDisplay.text = score.ToString ();
  }
}
