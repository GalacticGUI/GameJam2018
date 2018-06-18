using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeYellow : MonoBehaviour {

    public SoundFX soundFX;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<PlayerController>().currentHealth = 0;
            soundFX.PlayWilhelm();
            Destroy(gameObject);
        }
    }
}
