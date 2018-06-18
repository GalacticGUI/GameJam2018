using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {

    public AudioSource playerAttack;
    public AudioSource[] beeAttack;
    public AudioSource[] octoAttack;
    public AudioSource[] playerDeath;
    public AudioSource[] rupees;
    public AudioSource[] takeDamage;
    public AudioSource buttonSelect;
    public AudioSource pickUpKey;
    public AudioSource wallBounce;
    public AudioSource goat;
    public AudioSource wilhelm;

	public void PlayPlayerAttack() {
        playerAttack.Play();
    }

    public void PlayBeeAttack() {
        int index = Random.Range(0, beeAttack.Length);
        beeAttack[index].Play();
    }

    public void PlayOctoAttack() {
        int index = Random.Range(0, octoAttack.Length);
        octoAttack[index].Play();
    }

    public void PlayPlayerDeath() {
        int index = Random.Range(0, playerDeath.Length);
        playerDeath[index].Play();
    }

    public void PlayTakeDamage() {
        int index = Random.Range(0, takeDamage.Length);
        takeDamage[index].Play();
    }

    public void PlayRupees() {
        int index = Random.Range(0, rupees.Length);
        rupees[index].Play();
    }

    public void PlayButtonSelect() {
        buttonSelect.Play();
    }

    public void PlayPickUpKey() {
        pickUpKey.Play();
    }

    public void PlayWallBounce() {
        wallBounce.Play();
    }

    public void PlayGoat() {
        goat.Play();
    }

    public void PlayWilhelm() {
        wilhelm.Play();
    }
}
