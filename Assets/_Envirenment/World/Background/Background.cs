using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Background : MonoBehaviour {

    Animator animator;
    [SerializeField] Sprite night, day;
    Image image;

    void Awake() {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        World.Instance.notifyNightChange += ChangeNight;
    }

	void ChangeNight(bool isNight) {
        animator.SetBool("isNight", isNight);
		// if(isNight) {
        //     image.sprite = night;
        // } else {
        //     image.sprite = day;
        // }
	}
}
