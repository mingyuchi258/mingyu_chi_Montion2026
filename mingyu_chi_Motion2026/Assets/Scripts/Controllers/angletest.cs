using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class angletest : MonoBehaviour
{

    public List<float> angles;
    public float r;

    private int currentangleindex = 0;
    private float shiftprogress;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // float fortyfivedegree = 45;

        //float ffdinradians = fortyfivedegree * Mathf.Deg2Rad;

        //float twoPiRadians = 2 * Mathf.PI;
        //float tprInDegrees = twoPiRadians * Mathf.Rad2Deg;

        //float currentangle = 90;
        // Mathf.Cos(currentangle);

        //float firstAngle = 45f;
        //float secondAngle = 225f;

        //float firstVectorX = Mathf.Cos(45f * Mathf.Deg2Rad);
        //float secondVectorX = Mathf.Cos(225f * Mathf.Deg2Rad);

        //Debug.Log(firstVectorX);
        //Debug.Log(secondVectorX);

        //float x = 0.7f;
        //float y = 0.7f;

        //float angle = Mathf.Atan(y/x);

        //float x2 = -0.7f;
        //float y2 = 0.7f;

        //float angle2 = Mathf.Atan(y2 / x2);



    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            currentangleindex++;
            if(currentangleindex >= angles.Count)
            {
                currentangleindex = 0;
            }
        }

        shiftprogress += Time.deltaTime;



        float currentangle = angles[currentangleindex];
       float  currentangleinradians = currentangle * Mathf.Deg2Rad;

        Vector3 startpoint = Vector3.zero;
        Vector3 endpoint = new Vector3(Mathf.Cos(currentangleinradians),Mathf.Sin(currentangleinradians));

        Debug.DrawLine(startpoint, endpoint,Color.wheat);
    }


    public static float VectorToAngle(Vector3 inVector)
    {
        float angle = Mathf.Atan2(inVector.y, inVector.x) * Mathf.Rad2Deg;

        return angle - 90f;
    }


    public static float VectorDot(Vector3 a, Vector3 b)
    {
        float dotProduct = a.x * b.x + a.y * b.y;
        return dotProduct;
    }
}
