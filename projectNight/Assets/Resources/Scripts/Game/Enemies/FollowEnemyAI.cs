using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float minimumDistance;
    
    [Header("Components")]
    public Transform target;

    private void Update() {
        if(Vector2.Distance(transform.position, target.position) > minimumDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else {
            //Attack Code
            StartCoroutine(Attack());
        }

        Debug.DrawLine(transform.position, target.position);
    }

    private IEnumerator Attack() {
        //Debug.Log("Attack!");
        yield return new WaitForSeconds(1);
    }

}
