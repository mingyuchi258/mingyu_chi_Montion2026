using UnityEngine;

public class angle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Vector3 facingDirection = transform.up;
        float facingAngle = angletest.VectorToAngle(facingDirection);

        Debug.Log(facingAngle);
        Debug.Log(transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
