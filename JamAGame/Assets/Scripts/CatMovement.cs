using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    private float horiMovement;

    [SerializeField] float jumpHeight = 10f;
    [SerializeField] float movementSpeed = 7f; 

    private Rigidbody2D catRB;

    private bool jumping;
    void Start()
    {
        catRB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horiMovement = Input.GetAxisRaw("Horizontal");
        catRB.velocity = new Vector2(horiMovement * movementSpeed, catRB.velocity.y);

        if (Input.GetButtonDown("Jump") && !jumping)
        {
            catRB.velocity = new Vector2(catRB.velocity.x, jumpHeight);
            jumping = true;
        }
     
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            jumping = false;
        }
    }
}
