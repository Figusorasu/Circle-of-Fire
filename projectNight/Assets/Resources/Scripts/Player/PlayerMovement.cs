using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private GameMaster gm;

    [SerializeField] private float speed;
    private float inputHorizontal, inputVertical;
    private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(inputHorizontal * speed, inputVertical * speed);
    }

    public void Move(InputAction.CallbackContext ctx) {
        inputHorizontal = ctx.ReadValue<Vector2>().x;
        inputVertical = ctx.ReadValue<Vector2>().y;
    }
}
