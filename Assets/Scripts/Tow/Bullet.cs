using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeTime = 10;

    public float Force;

    public Rigidbody2D Rigidbody;
    public LayerMask collisionWith;
    public bool CanTowed;
    public Vector2 TowPosition;


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if ((collisionWith.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            CanTowed = true;
            TowPosition = Rigidbody.position;
            Rigidbody.Sleep();
        }
    }
}
