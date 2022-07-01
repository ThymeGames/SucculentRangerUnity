using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{

    public Rigidbody2D projectile;
    public Vector3 velocity;
    public float timeBetweenAttacks = 2.0f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks) {
            timer = 0f;
            Throw();
        }

    }

    void Throw()
    {
        Rigidbody2D rb = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
        );
        rb.velocity = velocity;
        Destroy(rb.gameObject, 5f);
    }

}
