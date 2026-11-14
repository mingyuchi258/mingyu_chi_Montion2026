using UnityEngine;
using UnityEngine.InputSystem;

public class overlappoint : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mp = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (rb.OverlapPoint(mp))
        {
            Debug.Log("mouse on square");
        }
    }
}
