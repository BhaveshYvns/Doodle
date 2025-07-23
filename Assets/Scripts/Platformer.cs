using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    public float jumpforce = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = jumpforce;
            rb.velocity = velocity;
        }
    }
}

