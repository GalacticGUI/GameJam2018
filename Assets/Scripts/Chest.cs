using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

    public SoundFX soundFX;
    public GameObject popup;
    public Sprite openChest;
    private SpriteRenderer renderer;

    private void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if (FindObjectOfType<PlayerController>().keys > 0) {
                FindObjectOfType<PlayerController>().keys -= 1;
                renderer.sprite = openChest;
                popup.SetActive(true);
            }
        }
    }
}
