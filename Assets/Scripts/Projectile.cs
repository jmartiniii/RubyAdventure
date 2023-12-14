using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    private float timeToLive = 3.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    void Update()
    {
        timeToLive -= Time.deltaTime;

        if (timeToLive < 0)
        {
            Destroy(gameObject);
        }

        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        //if (e != null)
        //{
        //    e.Fix();
        //}
        if (other.collider.CompareTag("Player") || other.collider.CompareTag("Cog"))
        {
            return;
        } 
        else
        {
            if (other.collider.CompareTag("Enemy"))
            {
                e.Fix();
            }

            Destroy(gameObject);
        }
    }
}