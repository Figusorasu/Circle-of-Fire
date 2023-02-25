using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public float speed;
    private Vector3 targetPosition;

    private void Start() {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(transform.position == targetPosition) {
            Debug.Log("PifPaf");
            Destroy(gameObject);
        }
    }
}
