using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public float speed;
    private Vector3 targetPosition;
    private Rigidbody2D projectile_rb;

    private void Start() {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        projectile_rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {

        //projectile_rb.velocity = new Vector2(targetPosition.x * (speed * Time.deltaTime), targetPosition.y * (speed * Time.deltaTime));

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(transform.position == targetPosition) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Damage");
            Destroy(gameObject);
        } else if(other.gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
        
    }
}
