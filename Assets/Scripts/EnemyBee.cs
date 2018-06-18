using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBee : MonoBehaviour {

    public SoundFX soundFX;
    private Rigidbody2D rb2d;
    private Animator animator;

    public Transform target;
    public float moveSpeed;
    public float awareDistance;
    public float attackDistance;
    public float minDistance;

    public float attackCoolDown;
    private float attackTimer;
    private bool canAttack = true;

    private float range;
    private float xDistance, yDistance;
    private float xDirection, yDirection;

    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        xDistance = (target.position.x - transform.position.x);
        yDistance = (target.position.y - transform.position.y);
        xDirection = Mathf.Sign(target.position.x - transform.position.x);
        yDirection = Mathf.Sign(target.position.y - transform.position.y);

        range = Vector2.Distance(transform.position, target.position);
        if (range <= awareDistance && range > minDistance) {
            if (Mathf.Abs(xDistance) > Mathf.Abs(yDistance)) {
                rb2d.MovePosition(new Vector2(transform.position.x + xDirection * moveSpeed * Time.deltaTime, transform.position.y));
                if (xDirection > 0) {
                    animator.Play("Bee_Right");
                }
                else {
                    animator.Play("Bee_Left");
                }
            }
            else {
                rb2d.MovePosition(new Vector2(transform.position.x, transform.position.y + yDirection * moveSpeed * Time.deltaTime));
                if (yDirection < 0) {
                    animator.Play("Bee_Down");
                }
                else {
                    animator.Play("Bee_Up");
                }
            }
        }

        if (range <= attackDistance) {
            if (canAttack) {
                // attack player
                target.GetComponent<PlayerController>().currentHealth -= 1;
                soundFX.PlayBeeAttack();
                attackTimer = Time.time;
                canAttack = false;
            }
        }
        if (Time.time - attackTimer > attackCoolDown) {
            canAttack = true;
        }
    }
}
