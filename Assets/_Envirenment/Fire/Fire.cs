using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    [SerializeField] Sprite activeSprite, notActiveSprite;
    SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetActive() {
        spriteRenderer.sprite = activeSprite;
    }

    public void SetNotActive() {
        spriteRenderer.sprite = notActiveSprite;
    }
}
