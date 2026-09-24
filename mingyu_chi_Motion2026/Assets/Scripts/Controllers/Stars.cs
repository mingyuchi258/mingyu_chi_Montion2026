using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public int n = 0;
    public float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= drawingTime)
        {
            time = 0f;
            n++;
        }

        Vector3 startp = starTransforms[n].position;
        Vector3 endp = starTransforms[n + 1].position;

        Vector3 point = Vector3.Lerp(startp, endp, time / drawingTime);

        Debug.DrawLine(startp, point);
    }
}
