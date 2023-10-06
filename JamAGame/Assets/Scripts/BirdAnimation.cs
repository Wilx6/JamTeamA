using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    private Animator birdAnim;
    private Rigidbody2D birdRB;
    void Start()
    {
        birdAnim = GetComponent<Animator>();
        birdRB = GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Cat Player")
        {
           birdAnim.SetBool("Flying", true);

            birdRB.velocity = new Vector2(-8f, 8f);
            
        }
    }

}
