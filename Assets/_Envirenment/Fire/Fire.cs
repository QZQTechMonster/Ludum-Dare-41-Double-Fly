using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    Animator animator;
    [SerializeField] GameObject mlight;
    AudioSource audioSouce;

    void Awake() {
        animator = GetComponent<Animator>();
        audioSouce = GetComponent<AudioSource>();
    }
    public void SetActive() {
        animator.SetBool("isActive", true);
        mlight.SetActive(true);
        audioSouce.Play();
    }

    public void SetNotActive() {
        animator.SetBool("isActive", false);
        StartCoroutine("CloseLight");
    }

    IEnumerator CloseLight() {
        yield return new WaitForSeconds(0.8f);
        mlight.SetActive(false);
    }
}
