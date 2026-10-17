using UnityEngine;

public class lazer : MonoBehaviour
{

    public float a = 2;
    public float mtime = 5;
    float speed = 1f;


    public Transform enemy;
    public float withenemy = 0.5f;

    float time = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lazerm();
    }

    public void lazerm()
    {
        speed += a * Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;

        time += Time.deltaTime;

        if (time >= mtime)
        {
            Destroy(gameObject);
        }

        float d = Vector2.Distance(transform.position, enemy.position);
        if (d <= withenemy)
        {
            Destroy(gameObject);
        }
    }
}
