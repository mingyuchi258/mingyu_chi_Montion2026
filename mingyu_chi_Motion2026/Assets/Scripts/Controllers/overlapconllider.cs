using UnityEngine;
using System.Collections.Generic;

public class overlapconllider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List <Collider2D> r = new List <Collider2D>();
        int count = Physics2D.OverlapCollider(GetComponent<Collider2D>(),r);

        if (count > 0)
        {
            Debug.Log("overlap");
        }
       
    }
}
