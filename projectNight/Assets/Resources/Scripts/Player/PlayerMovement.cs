using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameMaster gm;

    private float inputHorizontal, inputVertical;
    private Rigidbody2D rb;
    

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(inputHorizontal * speed, inputVertical * speed);
    }

    public void Move(InputAction.CallbackContext ctx) {
        inputHorizontal = ctx.ReadValue<Vector2>().x;
        inputVertical = ctx.ReadValue<Vector2>().y;
    }
}
