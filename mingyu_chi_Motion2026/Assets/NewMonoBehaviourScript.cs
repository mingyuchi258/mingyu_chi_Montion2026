using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 origin = new Vector2(0, 0);

        Vector2 dvector = new Vector2(0, 1);

        Vector2 evector = new Vector2(3, -2);



        Debug.DrawLine(origin, dvector, Color.yellow,15f);

        Debug.DrawLine(origin, evector, Color.gray, 15f);






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
