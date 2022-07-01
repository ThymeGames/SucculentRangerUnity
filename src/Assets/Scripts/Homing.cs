using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{

    public Transform target;  // can move
    public float velocityMagnitude = 1f;
    public float height = 1f;
    public float gravityScale = 2f;

    bool isOnTop = false;
    Rigidbody2D rb;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        y = target.transform.position.y + height;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isOnTop) {

            Vector3 target_position = target.position;
            target_position.y = y;
            Vector3 direction = target_position - transform.position;
            
            float h = direction.magnitude;
            isOnTop = h < 0.1f;

            Vector3 velocity = direction / h * velocityMagnitude;
            transform.position += velocity * Time.fixedDeltaTime;

        } else {

            rb.gravityScale = gravityScale;
        }
    }
}
