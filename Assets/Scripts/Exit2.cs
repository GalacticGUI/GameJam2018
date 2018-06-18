using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit2 : MonoBehaviour {

    public SoundFX soundFX;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.transform.position = new Vector2(64.44f, 24.27f);
            soundFX.PlayGoat();
        }
    }
}
