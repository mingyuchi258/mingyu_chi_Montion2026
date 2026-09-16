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

    public Vector3 AbombOffset = new Vector3(0, 1, 0);

    public Vector3 Bbmboffset = new Vector3(0, -1, 0);
    public float bs = 2;
    public int n = 3;



    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            Spawnbombatoffset(AbombOffset);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            spawnbomtrail(bs,n);
        }
    }

    public void Spawnbombatoffset(Vector3 v)
    {
        Vector3 bombp = transform.position + v;
        Instantiate(bombPrefab, bombp, Quaternion.identity);

    }


    public void spawnbomtrail(float bs,int n)
    {
        for (int i = 0; i <= n; i++)
        {
            Vector3 bp = Bbmboffset * bs * i;

            Spawnbombatoffset(bp);
        }
    }


    public void spawnbombonrandomcorner(float d)
    {

    }


}
