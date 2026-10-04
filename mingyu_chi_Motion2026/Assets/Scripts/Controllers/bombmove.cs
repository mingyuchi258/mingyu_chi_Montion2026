using UnityEngine;

public class bombmove : MonoBehaviour
{

    public Vector3 direction;

    public float a = 2;
    public float mtime = 5;
    float speed = 1f;


    public Transform player;
    public float bombwithplayer = 0.5f;

    float time = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bombm();
    }


    public void bombm()
    {
        speed += a * Time.deltaTime;
        transform.position = transform.position + direction * speed * Time.deltaTime;

        time += Time.deltaTime;

        if (time >= mtime)
        {
            Destroy(gameObject);
        }

        float d = Vector2.Distance(transform.position, player.position);
        if (d <= bombwithplayer)
        {
            Destroy(gameObject);
        }
    }

}
