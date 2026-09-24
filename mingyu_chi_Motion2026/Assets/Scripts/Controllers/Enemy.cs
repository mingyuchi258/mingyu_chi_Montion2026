using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float speed = 1;
    public float distance = 3;
    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        Vector3 direction = player.position - transform.position;
        Vector3 newp= transform.position + direction.normalized * distance;
        transform.position = Vector3.MoveTowards(transform.position, newp, speed * Time.deltaTime);
    }

}
