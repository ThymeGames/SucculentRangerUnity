using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitaSpawner : MonoBehaviour
{

    public bool isTriggered = false;
    public GameObject Lita;

    public float x = 0;
    public float y = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawner started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered) {
            Debug.Log("Triggered");
            isTriggered = true;
            Instantiate(Lita, new Vector3(x, y, 0), Quaternion.identity);
        }
    }

}
