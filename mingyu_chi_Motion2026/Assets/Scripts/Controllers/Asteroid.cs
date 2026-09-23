using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public Vector3 newposition;

    // Start is called before the first frame update
    void Start()
    {
        chooseposition();
    }

    // Update is called once per frame
    void Update()
    {
        asteroidmovement();
    }


    public void chooseposition()
    {
        Vector2 nd = Random.insideUnitCircle * maxFloatDistance;

        Vector3 direction = new Vector3(nd.x, nd.y, 0f);
        newposition = transform.position + direction;
    }

    public void asteroidmovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, newposition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, newposition) <= arrivalDistance)
        {
            chooseposition();
        }
    }
}
