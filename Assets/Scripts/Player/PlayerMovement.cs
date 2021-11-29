using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRb;
    public Animator anim;
    [SerializeField]
    private float speed;
    public Vector3 direction;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        if (!myRb)
        {
            Debug.LogError("No rb found");
        }
        anim = GetComponent<Animator>();
        if (!anim)
        {
            Debug.LogError("No animator found");
        }
    }
    void FixedUpdate()
    {
        direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        PlayAnimationsAndMove();
    }

    void MoveCharacter()
    {
        myRb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

    void PlayAnimationsAndMove()
    {
        if (direction != Vector3.zero)
        {
            MoveCharacter();
            direction.x = Mathf.Round(direction.x);
            direction.y = Mathf.Round(direction.y);
            anim.SetBool("isMoving", true);
            anim.SetFloat("moveX", direction.x);
            anim.SetFloat("moveY", direction.y);

        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
