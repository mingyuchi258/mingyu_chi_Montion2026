using UnityEngine;
using UnityEngine.InputSystem;

public class squarespawner : MonoBehaviour
{

    public float s = 0.5f;

    void Update()
    {
        Vector2 mousep = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Debug.DrawLine(mousep + new Vector2(-s, s),mousep + new Vector2(s, s),Color.gray);

        Debug.DrawLine(mousep + new Vector2(s, s),mousep + new Vector2(s, -s), Color.gray);

        Debug.DrawLine(mousep + new Vector2(s, -s),mousep + new Vector2(-s, -s), Color.gray);

        Debug.DrawLine(mousep + new Vector2(-s, -s),mousep + new Vector2(-s, s), Color.gray);


        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Debug.DrawLine(mousep + new Vector2(-s, s), mousep + new Vector2(s, s), Color.white,5);

            Debug.DrawLine(mousep + new Vector2(s, s), mousep + new Vector2(s, -s), Color.white,5);

            Debug.DrawLine(mousep + new Vector2(s, -s), mousep + new Vector2(-s, -s), Color.white,5);

            Debug.DrawLine(mousep + new Vector2(-s, -s), mousep + new Vector2(-s, s), Color.white,5);
        }
    }
}


