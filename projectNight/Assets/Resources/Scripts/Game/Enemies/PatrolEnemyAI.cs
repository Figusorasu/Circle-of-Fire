using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float waitTime;
    public Transform[] patrolPoints;
    
    [SerializeField] private int currentPointIndex;
    [SerializeField] private bool isWaiting = false;


    private void Update() {
        Debug.Log("Current point index: " + currentPointIndex);
        Debug.Log("Next patrol point pos:" + patrolPoints[currentPointIndex].position);
        Debug.Log("Enemy pos:" + transform.position);

        if(ReachedPatrolPoint()) {
            Debug.Log("Woooo cipaaaa");
            if(isWaiting == false) {
                Debug.Log("działaj dupo");
                StartCoroutine(Wait());
            }
        } else {
            isWaiting = false;
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
        /*
        if(transform.position != patrolPoints[currentPointIndex].position) { // If not reached the next patrol point
            isWaiting = false;
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);

        } else { // when reach the patrol point
            Debug.Log("Woooo cipaaaa");
            if(isWaiting == false) {
                Debug.Log("działaj dupo");
                StartCoroutine(Wait());
            }
        }*/

    }

    private IEnumerator Wait() {
        Debug.Log("dupa");
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        if(currentPointIndex + 1 < patrolPoints.Length) {
            currentPointIndex++;
        } else {
            currentPointIndex = 0;
        }
    }

    private bool ReachedPatrolPoint() {
        if(transform.position.x == patrolPoints[currentPointIndex].position.x && transform.position.y == patrolPoints[currentPointIndex].position.y) {
            return true;
        } else {
            return false;
        }

    }

}
