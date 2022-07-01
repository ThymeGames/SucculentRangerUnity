using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggeredSpawner : MonoBehaviour
{

    public bool isTriggered = false;
    public GameObject target;
    public Vector3 position;
    public Transform parent;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered) {

            Debug.Log("Triggered");

            isTriggered = true;

            Vector3 position_rel = parent.position + position;

            Instantiate(
                target,
                position_rel,
                Quaternion.identity,
                parent
            );

        }
    }
}
