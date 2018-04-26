using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelLoad : MonoBehaviour {
  
  public void loadLevel(string levelToLoad) {
    //Load the level from LevelToLoad
    SceneManager.LoadScene(levelToLoad);
  }

  public void quit() {
    Application.Quit();
  }
}
