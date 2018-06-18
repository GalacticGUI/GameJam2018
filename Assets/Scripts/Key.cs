using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public SoundFX soundFX;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<PlayerController>().keys += 1;
            soundFX.PlayPickUpKey();
            Destroy(gameObject);
        }
    }
}
