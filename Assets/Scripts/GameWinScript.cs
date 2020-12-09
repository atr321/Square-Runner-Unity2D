using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameWinScript : MonoBehaviour {

    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!hasPlayed) {
        Debug.Log("teste");
            this.hasPlayed = AudioManager.playAudio("gamewin");
        }
    }

    public void goBackToGame() {
        SceneManager.LoadScene(0);
    }
}
