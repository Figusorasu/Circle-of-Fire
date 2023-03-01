using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    //Movement
    public float speed;
    public float currentSpeed;

    [Space] //Health
    public int maxHealth;
    public int currentHealth;

    [Space] //Stamina
    public int maxStamina;
    public int currentStamina;

    [Space] //Dash
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    [Space]
    [Header("Movement")]
    public bool canDash = true;
    public bool isDashing = false;

    private float inputHorizontal, inputVertical;
    private Vector3 change;

    [Header("Components")]
    [SerializeField] private Animator anim;
    [SerializeField] private TrailRenderer trail;
    
    private GameMaster gm;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        currentSpeed = speed;
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

        if(inputVertical > 0) {
            trail.sortingOrder = 1;
        } else {
            trail.sortingOrder = -1;
        }
        
    }

    private void FixedUpdate() {
        if(!isDashing) {
            rb.velocity = new Vector2(inputHorizontal * currentSpeed, inputVertical * currentSpeed);
        }
    }

    public void Move(InputAction.CallbackContext ctx) {
        inputHorizontal = ctx.ReadValue<Vector2>().x;
        inputVertical = ctx.ReadValue<Vector2>().y;
        //Debug.Log("X: " + inputHorizontal);
        //Debug.Log("Y: " + inputVertical);
    }

    public void Dodge(InputAction.CallbackContext ctx) {
        if(ctx.performed && canDash) {
            Debug.Log("SPACE!");
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash() {
        Debug.Log("SPACEEEEEE!");
        canDash = false;
        isDashing = true;
        rb.velocity *= dashingPower;
        //rb.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y * dashingPower);
        trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trail.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        Debug.Log("DASH");
    }
}
