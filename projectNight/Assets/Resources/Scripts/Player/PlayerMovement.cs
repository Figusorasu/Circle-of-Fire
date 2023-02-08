using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameMaster gm;

    public float speed;
    private float inputHorizontal, inputVertical;
    private Rigidbody2D rb;
    public Animator anim;
    

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void Update() {
        if (rb.velocity.x >= 0) {
            anim.SetBool("WalkRight", true);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
        } else if (rb.velocity.x <= 0) {
            anim.SetBool("WalkRight", false);
            anim.SetBool("WalkLeft", true);
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
        } else if (rb.velocity.y >= 0) {
            anim.SetBool("WalkRight", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkUp", true);
            anim.SetBool("WalkDown", false);
        } else if (rb.velocity.y <= -0) {
            anim.SetBool("WalkRight", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", true);
        } else {
            anim.SetBool("WalkRight", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(inputHorizontal * speed, inputVertical * speed);
    }

    public void Move(InputAction.CallbackContext ctx) {
        inputHorizontal = ctx.ReadValue<Vector2>().x;
        inputVertical = ctx.ReadValue<Vector2>().y;
    }
}
