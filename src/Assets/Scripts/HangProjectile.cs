using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangProjectile : MonoBehaviour
{

    public Rigidbody2D projectile;
    // public Vector3 velocity;
    public float timeBetweenAttacks = 2f;
    public float height = 1f;
    
    public string target_tag;
    GameObject target;
    float timer;

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
            Hang();
        }
    }

    void Hang()
    {
        GameObject target  = GameObject.FindGameObjectWithTag(target_tag);
        Vector3 position = target.transform.position;
        // Vector3 position = target.position;
        
        Debug.Log(position);
        position.y += height;

        Rigidbody2D rb = Instantiate(
            projectile,
            transform.position, // position,
            Quaternion.identity
        );

        Homing c = rb.gameObject.GetComponent<Homing>();
        if (c != null) {
            c.target = target.transform;
        }

        // rb.velocity = velocity;
        Destroy(rb.gameObject, 5f);
    }

}
