using UnityEngine;

public class rowgeneration : MonoBehaviour
{
    //quantity to generate
    public int number = 5;
    //set the side length of the square
    public float s = 1f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //
    public void Draw()
    {

        for (int i = 0; i < number; i++)
        {
            //for the *n*-th generated rectangle, its length along the x-axis is a specific multiple of the original square's side length
            float x = i * s;

            //find the four points of the rectangle
            Vector2 upright = new Vector2(x + s, s);

            Vector2 upleft = new Vector2(x, s);

            Vector2 downright = new Vector2(x + s, 0);

            Vector2 downleft = new Vector2(x, 0);


            //the line connecting two points
            Debug.DrawLine(downleft, downright, Color.white, 5f);

            Debug.DrawLine(downright, upright, Color.white, 5f);

            Debug.DrawLine(upright, upleft, Color.white, 5f);

            Debug.DrawLine(upleft, downleft, Color.white, 5f);
        }
    }
    }
