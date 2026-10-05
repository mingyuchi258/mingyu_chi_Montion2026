using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class looker : MonoBehaviour
{

    public List<Transform> targets;
    private int targetindex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 firstTarget = targets[targetindex].position;

        Vector3 vectorToFirstTarget = firstTarget - transform.position;

        float angleToFirstTarget = angletest.VectorToAngle(vectorToFirstTarget);

        //We have to set the whole vector for eulerAngles
        transform.eulerAngles = new Vector3(0f, 0f, angleToFirstTarget);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            targetindex++;
            if (targetindex >= targets.Count)
            {
                targetindex = 0;
            }
        }
    }
}
