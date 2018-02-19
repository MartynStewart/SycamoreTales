using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    public void ThisButtonHit() {
        Debug.Log("Button Pressed");
    }

    public void LoadLevel(string LevelName) {
        SceneManager.LoadScene(LevelName);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void GameOverScreen() {
        Invoke("GameOver", 5); 
    }

    private void GameOver() {
        SceneManager.LoadScene("Menu");
    }
}