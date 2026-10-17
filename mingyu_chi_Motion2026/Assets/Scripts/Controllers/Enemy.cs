using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public bombmove bombmovep;

    public float time = 0f;
    public float maxtime = 4;

    public float d = 1;


    public float speed = 1;
    public float distance = 3;
    private void Update()
    {
        EnemyMovement();

        time += Time.deltaTime;

        if (time >= maxtime)
        {
            time = 0f;
            int n = Random.Range(0, 2);
            if (n == 0)
            {
                makebomb(new Vector3(1f, 1f, 0f));
                makebomb(new Vector3(1f, -1f, 0f));
                makebomb(new Vector3(-1f, -1f, 0f));
                makebomb(new Vector3(-1f, 1f, 0f));
            }
            else
            {
                shoot();
            }

        }
    }

    public void EnemyMovement()
    {
        Vector3 direction = player.position - transform.position;
        Vector3 newp= transform.position + direction.normalized * distance;
        transform.position = Vector3.MoveTowards(transform.position, newp, speed * Time.deltaTime);
    }


    public void makebomb(Vector3 direction)
    {

        direction = direction.normalized;
        Vector3 bombp = transform.position + direction * d;
        bombmove bomb = Instantiate(bombmovep, bombp, Quaternion.identity);

        bomb.direction = direction;
        bomb.player = player;
    }



    public void shoot()
    {
            Vector3 direction = player.position - transform.position;
            makebomb(direction);

    }

}
