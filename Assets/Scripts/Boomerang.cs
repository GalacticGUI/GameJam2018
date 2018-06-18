using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {

    public SoundFX soundFX;
    public GameObject player;
    public GameObject[] treasure;
    // Weapon variables
    private Rigidbody2D rb2d;
    private bool isReturning = false;
    public bool hasReturned = false;
    private float boomSpeed = 7.0f;
    public int boomDir;
    private float range;
    private float boomDistance = 7.5f;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        range = Vector2.Distance(transform.position, player.transform.position);
        if (range > boomDistance) {
            isReturning = true;
        }
        if (isReturning && range < 1) {
            isReturning = false;
            hasReturned = true;
        }
        switch (boomDir) {
            case 1: // up
                if (!isReturning) {
                    rb2d.MovePosition(new Vector2(transform.position.x, transform.position.y + boomSpeed * Time.deltaTime));
                }
                else {
                    rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, player.transform.position, boomSpeed * Time.deltaTime);
                }
                break;
            case 2: // down
                if (!isReturning) {
                    rb2d.MovePosition(new Vector2(transform.position.x, transform.position.y - boomSpeed * Time.deltaTime));
                }
                else {
                    rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, player.transform.position, boomSpeed * Time.deltaTime);
                }
                break;
            case 3: // left
                if (!isReturning) {
                    rb2d.MovePosition(new Vector2(transform.position.x - boomSpeed * Time.deltaTime, transform.position.y));
                }
                else {
                    rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, player.transform.position, boomSpeed * Time.deltaTime);
                }
                break;
            case 4: // right
                if (!isReturning) {
                    rb2d.MovePosition(new Vector2(transform.position.x + boomSpeed * Time.deltaTime, transform.position.y));
                }
                else {
                    rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, player.transform.position, boomSpeed * Time.deltaTime);
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            soundFX.PlayTakeDamage();
            int index = Random.Range(0, treasure.Length);
            GameObject item = (GameObject)Instantiate(treasure[index]);
            item.transform.position = other.gameObject.transform.position;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Wall") {
            isReturning = true;
            soundFX.PlayWallBounce();
        }
    }
}
