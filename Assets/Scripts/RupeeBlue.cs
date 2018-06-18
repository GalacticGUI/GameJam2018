using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeBlue : MonoBehaviour {

    public SoundFX soundFX;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<PlayerController>().rupees += 5;
            soundFX.PlayRupees();
            Destroy(gameObject);
        }
    }
}
