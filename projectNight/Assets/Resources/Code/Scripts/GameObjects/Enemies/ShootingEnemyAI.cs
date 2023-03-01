using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float minimumDistance;

    [Space]
    public float timeBetweenShots;
    private float nextShotTime;
    
    [Header("Components")]
    public Transform target;
    public GameObject projectile;

    private void Update() {
        if(Time.time > nextShotTime) {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }

        if(Vector2.Distance(transform.position, target.position) < minimumDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        } else {
            //Attack Code
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack() {
        //Debug.Log("Attack!");
        yield return new WaitForSeconds(1);
    }
}
