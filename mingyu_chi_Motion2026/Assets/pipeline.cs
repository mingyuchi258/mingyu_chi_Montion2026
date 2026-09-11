using UnityEngine;
using UnityEngine.InputSystem;

public class pipeline : MonoBehaviour
{
    //Store mouse position
    Vector2[] mposition=new Vector2[100];
    
    int i = 0;

    float time= 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //when long-pressing the mouse
        if (Mouse.current.leftButton.isPressed)
        {
            time += Time.deltaTime;
            //if still pressing after 0.1 second
            if (time >= 0.1f)
            {
                Vector3 nowMP = Mouse.current.position.ReadValue();
                nowMP = Camera.main.ScreenToWorldPoint(nowMP);

                //draw a line when there are at least two points
                if (i >0)
                {
                    Debug.DrawLine(mposition[i -1], nowMP, Color.white,1);
                }

                mposition[i]= nowMP;
                i++;

                time = 0;
            }
        }
        
        if (i >=100)
        {
            i = 0;
        }
    }
}
