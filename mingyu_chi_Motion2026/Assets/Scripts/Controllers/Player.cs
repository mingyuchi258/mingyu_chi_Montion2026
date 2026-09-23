using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //task1
    public Vector3 AbombOffset = new Vector3(0, 1, 0);

    public Vector3 Bbmboffset = new Vector3(0, -1, 0);
    //distance between the player and the bomb
    public float bs = 2;
    //number of bomb
    public int n = 3;

    //task2
    //specified distance
    public float indistance = 2;


    //task3
    public Transform target;

    public float ratio = 0.5f;


    //task4
    public float maxrange = 5;
    public List<Transform>asteroid = new List<Transform>();


    //task1
    Vector3 r = Vector3.right;
    Vector3 l = Vector3.left;
    Vector3 u = Vector3.up;
    Vector3 d = Vector3.down;

    Vector3 currentvelocity;
    public float speed;
    //b
    public float accelerationtime;
    public float currentacceleration;

    public float maxspeed;
    //c
    public float deceleration = 2;



    void Start()
    {
        currentacceleration = speed / accelerationtime;
        //transform.position = warpPoint * Time.deltaTime;


    }

    void Update()
    {

        playermovement();
        

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            Spawnbombatoffset(AbombOffset);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            spawnbomtrail(bs,n);
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            spawnbombonrandomcorner(indistance);
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            warpplayer(target,ratio);
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            detectasteroids(maxrange, asteroid);
        }

        
    }

    public void Spawnbombatoffset(Vector3 v)
    {
        //bomb's position is the player's position plus offset
        Vector3 bombp = transform.position + v;
        Instantiate(bombPrefab, bombp, Quaternion.identity);

    }


    public void spawnbomtrail(float bs,int n)
    {
        //spawn a specified number of bombs at a specified distance
        for (int i = 1; i <= n; i++)
        {
            Vector3 bp = Bbmboffset * bs * i;

            Spawnbombatoffset(bp);
        }
    }





    public void spawnbombonrandomcorner(float indistance)
    {
        //x=0*2-1=-1 or x=1*2-1=2-1=1
        //y=0*2-1=-1 or y=1*2-1=2-1=1
        int x = Random.Range(0, 2) * 2 - 1;
        int y = Random.Range(0, 2) * 2 - 1;

        Vector3 bv = new Vector3(x, y, 0);

        Vector3 bd = bv.normalized * indistance;

        Spawnbombatoffset(bd);


    }





    public void warpplayer(Transform target, float ratio)
    {

        transform.position = Vector3.Lerp(transform.position, target.position, ratio);
    }





    public void detectasteroids(float inrange, List<Transform> inasteroids)
    {

        for (int i = 0; i < inasteroids.Count; i++)
        {

            Transform asteroid = inasteroids[i];
            Debug.DrawLine(transform.position, asteroid.position, Color.green,2);
        }



    }



    public void playermovement()
    {

        Vector3 accelerationdirection = Vector3.zero;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            accelerationdirection += l;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            accelerationdirection += r;
        }

        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerationdirection += u;
        }

        if (Keyboard.current.downArrowKey.isPressed)
        {
            accelerationdirection += d;
        }
        //ACCELERATION DIRECTION REPRESENTS THE DIRECTION WE ARE ACCELERATING
        //WE NORMALIZE IT 
        //AND THEN SET THE AMOUNT TO ACCELERATE BY:
        currentvelocity += accelerationdirection.normalized * Time.deltaTime;
        if (currentvelocity.magnitude > maxspeed)
        {
            currentvelocity = currentvelocity.normalized * maxspeed;
        }
        transform.position = transform.position + currentvelocity  * Time.deltaTime;
        //if the button is not being pressed, decelerate at the specified rate
        if (accelerationdirection == Vector3.zero)
        {

            float newSpeed = currentvelocity.magnitude - deceleration * Time.deltaTime;
            currentvelocity = currentvelocity.normalized * newSpeed;

        }
    }


}
