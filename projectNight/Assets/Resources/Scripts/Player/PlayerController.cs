using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameMaster gm;
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;

    [Header("Player Stats")]
    public int maxHealth;
    public int maxStamina;
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int currentStamina;


    // Movement
    private float inputHorizontal, inputVertical;
    private Rigidbody2D rb;
    private Vector3 change;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void Update() {
        change = Vector3.zero;
        change.x = inputHorizontal;
        change.y = inputVertical;
        if(change != Vector3.zero) {
            anim.SetFloat("moveX", inputHorizontal);
            anim.SetFloat("moveY", inputVertical);
            anim.SetBool("isMoving", true);
        } else {
            anim.SetBool("isMoving", false);
        }
        
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(inputHorizontal * speed, inputVertical * speed);
    }

    public void Move(InputAction.CallbackContext ctx) {
        inputHorizontal = ctx.ReadValue<Vector2>().x;
        inputVertical = ctx.ReadValue<Vector2>().y;
        //Debug.Log("X: " + inputHorizontal);
        //Debug.Log("Y: " + inputVertical);
    }
}
