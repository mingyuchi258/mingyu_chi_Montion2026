using UnityEngine;
using UnityEngine.InputSystem;

public class vectoraddition : MonoBehaviour
{

    public Transform rtransform;
    public Transform btransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 rp = new Vector2(rtransform.position.x, rtransform.position.y);
        Vector2 bp = new Vector2(btransform.position.x, btransform.position.y);

        Vector2 rPlusb = rp + bp;

        Vector2 origin = new Vector2(0, 0);

        if (Keyboard.current.rKey.isPressed)
        {
            Debug.DrawLine(origin, rp, Color.red);
        }

        if (Keyboard.current.bKey.isPressed)
        {
            Debug.DrawLine(origin, bp, Color.blue);
        }
        if (Keyboard.current.rKey.isPressed && Keyboard.current.bKey.isPressed)
        {
            Debug.DrawLine(origin, rPlusb, Color.magenta);
        }

        float rbsize = Mathf .Sqrt(rPlusb.x * rPlusb.x + rPlusb.y *rPlusb.y);
        Debug.Log(rbsize);

        Vector2 fromrtob = btransform.position - rtransform.position;

    }
}
