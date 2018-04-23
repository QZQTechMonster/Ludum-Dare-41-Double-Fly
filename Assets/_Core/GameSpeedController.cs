using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedController : MonoBehaviour {

    float gameSpeed = 0;
    [SerializeField] Text tutorialText;
	[SerializeField] string tutorialString;

    Rigidbody2D rgb;

    bool isStop = false;
    float activeTime;

    [SerializeField] bool canControlAfterDestroy;

    void Start() {
        rgb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Player") return;
        World.Instance.SetControl(false);
        tutorialText.text = tutorialString;
        tutorialText.text = tutorialText.text.Replace("\\n", "\n");
        rgb.isKinematic = true;
        Time.timeScale = gameSpeed;
        isStop = true;
        activeTime = Time.realtimeSinceStartup;

    }


	void Update() {
        if (isStop && Time.realtimeSinceStartup - activeTime > 1 &&
        Input.GetKeyDown(KeyCode.Space)) {
            Time.timeScale = 1;
            tutorialText.text = "";
            World.Instance.ChangeNight();
            World.Instance.SetControl(canControlAfterDestroy);
            rgb.isKinematic = false;
            Destroy(gameObject);
        }
	}

}
