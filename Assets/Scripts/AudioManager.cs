using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {



    private static AudioClip gameOverSound;
    private static AudioClip gameWinSound;
    private static AudioClip fire1;
    private static AudioClip fire2;
    private static AudioClip fire3;
    private static AudioClip[] fires;
    private static AudioSource audioSrc;
    private bool canPlay = true;
    public static AudioClip fire {
        get {
            int index = Random.Range(0, fires.Length);
            return fires[index];
        }

    }
    // Start is called before the first frame update
    void Start() {
        gameOverSound = Resources.Load<AudioClip>("Sounds/gameover");
        gameWinSound = Resources.Load<AudioClip>("Sounds/stagewin");
        fire1 = Resources.Load<AudioClip>("Sounds/laser1");
        fire2 = Resources.Load<AudioClip>("Sounds/laser2");
        fire3 = Resources.Load<AudioClip>("Sounds/laser3");
        audioSrc = this.GetComponent<AudioSource>();
        fires = new AudioClip[3] { fire1, fire2, fire3 };

    }

    // Update is called once per frame
    void Update() {
        // tryToPlay(this);
    }

    private static void tryToPlay(AudioManager theAudioManager) {
        if (theAudioManager.canPlay) {
            audioSrc.PlayOneShot(fire);

            theAudioManager.canPlay = false;
            theAudioManager.StartCoroutine(theAudioManager.delayPlay());
        }
    }

    private IEnumerator delayPlay() {
        yield return new WaitForSeconds(3);
        this.canPlay = true;
    }


    public static bool playAudio(string audioName) {
        if (audioSrc != null) {
            switch (audioName) {
                case "fire":
                    audioSrc.PlayOneShot(fire);
                    return true;
                case "gamewin":
                    audioSrc.PlayOneShot(gameWinSound);
                    return true;
                case "gameover":
                    audioSrc.PlayOneShot(gameOverSound);
                    return true;
                default:
                    return false;

            }
        } else Debug.Log("AUDIO SOURCE IS NULL");
        return false;

    }
}
