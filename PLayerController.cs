using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Increased default value so you can see movement immediately
    public float thrustForce = 10f; 
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 1. Get Mouse Position
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; 

            // 2. Convert to World Position
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            // 3. Calculate Direction
            Vector3 direction = worldPos - transform.position;
            direction.z = 0; 

            // 4. Rotate
            transform.up = direction;

            // 5. Move (FIXED)
            // We use .normalized to make the speed consistent
            // We use ForceMode2D.Impulse for an instant "dash" feel
            rb.AddForce(direction.normalized * thrustForce, ForceMode2D.Impulse); 
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
{
Destroy(gameObject);
}
}