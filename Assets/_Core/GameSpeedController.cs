using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedController : MonoBehaviour {

    [SerializeField] float gameSpeed = 1;
    [SerializeField] Text tutorialText;
	[SerializeField] string tutorialString;

    bool isStop = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Player") return;
        print("trig");
        tutorialText.text = tutorialString;
        Time.timeScale = gameSpeed;
        isStop = true;
    }


	void Update() {
        if (isStop && Input.GetKeyDown(KeyCode.Space)) {
            print("Des");
            Time.timeScale = 1;
            tutorialText.text = "";
            Destroy(gameObject);
        }
	}

}
