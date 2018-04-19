using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetActive()
    {
        animator.SetBool("isActive", true);
    }

    public void SetNotActive()
    {
        animator.SetBool("isActive", false);
    }
}
