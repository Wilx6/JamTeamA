using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    private float horiMovement;

    [SerializeField] float jumpHeight;
    [SerializeField] float movementSpeed;

    private Rigidbody2D catRB;

    void Start()
    {
        jumpHeight = 14f; // temporary
        movementSpeed = 7f; // also temporary

        catRB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horiMovement = Input.GetAxisRaw("Horizontal");
        catRB.velocity = new Vector2(horiMovement * movementSpeed, catRB.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            catRB.velocity = new Vector2(catRB.velocity.x, jumpHeight);
        }
    }
}
