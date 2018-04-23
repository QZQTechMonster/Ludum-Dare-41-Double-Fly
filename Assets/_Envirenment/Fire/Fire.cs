using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    Animator animator;
    [SerializeField] GameObject mlight;

    void Awake() {
        animator = GetComponent<Animator>();
    }
    public void SetActive() {
        animator.SetBool("isActive", true);
        mlight.SetActive(true);
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
