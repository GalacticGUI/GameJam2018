using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeGreen : MonoBehaviour {

    public SoundFX soundFX;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<PlayerController>().rupees += 1;
            soundFX.PlayRupees();
            Destroy(gameObject);
        }
    }
}
