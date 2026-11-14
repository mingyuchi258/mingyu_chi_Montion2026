using UnityEngine;

public class contasct : MonoBehaviour
{
    Rigidbody2D rb;
    ContactPoint2D[] contacts = new ContactPoint2D[1];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int count = rb.GetContacts(contacts);

        if (count > 0)
        {
            Debug.Log("!");
        }
    }
}
