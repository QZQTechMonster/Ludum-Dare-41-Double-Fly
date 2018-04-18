using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Background : MonoBehaviour {

    [SerializeField] Sprite night, day;
    Image image;

    void Start() {
        image = GetComponent<Image>();
        World.Instance.notifyNightChange += ChangeNight;

    }

	void ChangeNight(bool isNight) {
		if(isNight) {
            image.sprite = night;
        } else {
            image.sprite = day;
        }
	}
}
