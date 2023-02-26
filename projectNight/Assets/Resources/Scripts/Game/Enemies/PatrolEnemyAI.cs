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
        if(ReachedPatrolPoint()) {
            if(isWaiting == false) {
                StartCoroutine(Wait());
            }
        } else {
            isWaiting = false;
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
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
