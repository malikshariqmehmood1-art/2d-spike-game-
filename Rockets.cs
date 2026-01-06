using UnityEngine;

public class Rockets : MonoBehaviour
{
    // I removed the speed variables from here so the Inspector can't break them.
    public float minSize = 0.5f;
    public float maxSize = 0.5f; 

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 1. Safety settings
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        
        // Drag helps slow things down if they get too fast naturally
        rb.drag = 0; 
        rb.angularDrag = 0.5f; 

        // 2. Physics Material
        PhysicsMaterial2D bouncyMat = new PhysicsMaterial2D();
        bouncyMat.friction = 0f;      
        bouncyMat.bounciness = 1f;    
        if (GetComponent<Collider2D>() != null)
        {
            GetComponent<Collider2D>().sharedMaterial = bouncyMat;
        }

        // 3. Size
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);
        
        // 4. Spin (Very gentle)
        float randomTorque = Random.Range(-0.5f, 0.5f); 
        rb.AddTorque(randomTorque); 

        // 5. SPEED (HARDCODED)
        // I am typing the numbers directly here. 
        // 2f is slow walking speed. 4f is a light jog.
        float finalSpeed = Random.Range(2f, 4f); 
        
        rb.velocity = Vector2.right * finalSpeed;
    }

}