using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatMovement : MonoBehaviour
{
    private float horiMovement;
    private Animator catAnim;
    private SpriteRenderer catFlip;

    [SerializeField] float jumpHeight = 10f;
    [SerializeField] float movementSpeed = 7f;

    private Rigidbody2D catRB;

    private bool jumping;
    void Start()
    {
        catRB = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
        catFlip = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        horiMovement = Input.GetAxisRaw("Horizontal");
        catRB.velocity = new Vector2(horiMovement * movementSpeed, catRB.velocity.y);

        if (Input.GetButtonDown("Jump") && !jumping)
        {
            catRB.velocity = new Vector2(catRB.velocity.x, jumpHeight);
            jumping = true;
            catAnim.SetBool("Jumping", true);
        }

        if (horiMovement < 0f)
        {
            catFlip.flipX = true;
        }
        else if (horiMovement > 0f)
        {
            catFlip.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            jumping = false;
            catAnim.SetBool("Jumping", false);
        }
        if(other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("End");
        }
    }
   
}
