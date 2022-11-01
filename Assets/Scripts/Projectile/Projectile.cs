using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float lifetime;
    [HideInInspector]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
       if (lifetime <= 0)
            lifetime = 1.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime); 
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            Destroy(gameObject);
    }
}
