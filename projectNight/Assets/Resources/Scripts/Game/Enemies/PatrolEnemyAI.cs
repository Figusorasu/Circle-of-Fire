using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float waitTime;
    [Space]
    private int currentPointIndex;
    private bool once;

    [Header("Components")]
    public Transform[] patrolPoints;

    private void Update() {
        

        if(transform.position != patrolPoints[currentPointIndex].position) { // If not reached the next patrol point
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);

        } else { // when reach the patrol point
            if(once == false) {
                once = true;
                StartCoroutine(Wait());
            }

        }

    }

    private IEnumerator Wait() {
        yield return new WaitForSeconds(waitTime);
        if(currentPointIndex + 1 < patrolPoints.Length) {
            currentPointIndex++;
        } else {
            currentPointIndex = 0;
        }
        once = false;
    }

}
