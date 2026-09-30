using UnityEngine;

public class moon : MonoBehaviour
{
    public Transform planet;

    float mangle = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(2,30,planet);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {

        mangle += speed * Time.deltaTime;
        float mrad = mangle * Mathf.Deg2Rad;
        transform.position = target.position + new Vector3(Mathf.Cos(mrad), Mathf.Sin(mrad), 0) * radius;
    }
}
