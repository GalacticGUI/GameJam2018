using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public SoundFX soundFX;
    private Animator animator;
    public GameObject boomerang;
    public GameObject popup;

    // HUD Elements: Health
    public Sprite[] heartSprites;
    public Image heartUI;
    public int maxHealth = 6;
    public int currentHealth;

    // HUD Elements: Rupees
    public Text rupeeText;
    public int rupees = 0;

    // HUD Elements: Keys
    public Text keyText;
    public int keys = 0;

    // Movement variables
    private Rigidbody2D rb2d;
    public float moveSpeed;
    public float xMin, xMax, yMin, yMax;
    private float xInput, yInput;
    private int facing = 2;             // up = 1, down = 2, left = 3, right = 4

    private float respawnTimer;
    private float respawnCoolDown = 5;
    private bool canRespawn = false;

    
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void FixedUpdate() {
        if (!canRespawn) {
            PlayerMovement();
            PlayerAttack();
        }
       
        if (currentHealth <= 0 && !canRespawn) {
            currentHealth = 0;
            soundFX.PlayPlayerDeath();
            popup.SetActive(true);
            respawnTimer = Time.time;
            canRespawn = true;
        }

        heartUI.sprite = heartSprites[currentHealth];

        rupeeText.text = "x" + rupees.ToString();
        keyText.text = "x" + keys.ToString();

        if (boomerang.GetComponent<Boomerang>().hasReturned) {
            boomerang.SetActive(false);
            boomerang.GetComponent<Boomerang>().hasReturned = false;
        }

        if (canRespawn) {
            if(Time.time - respawnTimer > respawnCoolDown) {
                currentHealth = maxHealth;
                respawnTimer = 0;
                canRespawn = false;
            }
        }

        if (popup.activeSelf && Input.GetButtonDown("Cancel")) {
            popup.SetActive(false);
        }

        if (Input.GetButtonDown("Exit")) {
            Application.Quit();
            Debug.Log("Exiting Game!");
        }
    }

    private void PlayerMovement() {
        // get player input and move the player
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(xInput) > Mathf.Abs(yInput)) {
            rb2d.MovePosition(new Vector2(transform.position.x + xInput * moveSpeed * Time.deltaTime, transform.position.y));
            if (xInput > 0) {
                // moving right
                animator.Play("Player_Right");
                facing = 4;
            }
            else {
                // moving left
                animator.Play("Player_Left");
                facing = 3;
            }
        }
        else {
            rb2d.MovePosition(new Vector2(transform.position.x, transform.position.y + yInput * moveSpeed * Time.deltaTime));
            if (yInput > 0) {
                // moving up
                animator.Play("Player_Up");
                facing = 1;
            }
            else {
                // moving down
                animator.Play("Player_Down");
                facing = 2;
            }
        }
    }

    private void PlayerAttack() {
        if (Input.GetButtonDown("Fire1")) {
            soundFX.PlayPlayerAttack();
            boomerang.SetActive(true);
            switch (facing) {
                case 1: // up
                    boomerang.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 2, 0), new Quaternion(0, 0, 0, 0));
                    boomerang.GetComponent<Boomerang>().boomDir = 1;
                    break;
                case 2: // down
                    boomerang.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y - 2, 0), new Quaternion(0, 0, 0, 0));
                    boomerang.GetComponent<Boomerang>().boomDir = 2;
                    break;
                case 3: // left
                    boomerang.transform.SetPositionAndRotation(new Vector3(transform.position.x - 2, transform.position.y, 0), new Quaternion(0, 0, 0, 0));
                    boomerang.GetComponent<Boomerang>().boomDir = 3;
                    break;
                case 4: // right
                    boomerang.transform.SetPositionAndRotation(new Vector3(transform.position.x + 2, transform.position.y, 0), new Quaternion(0, 0, 0, 0));
                    boomerang.GetComponent<Boomerang>().boomDir = 4;
                    break;
            }
        }
    }
}
