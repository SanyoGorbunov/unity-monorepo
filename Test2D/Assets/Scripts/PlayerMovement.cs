using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 velocity;
    private Vector3 direction;
    private bool hasMoved;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.x == 0)
        {
            hasMoved = false;
        }
        else if(velocity.x != 0 && !hasMoved)
        {
            hasMoved = true;
            MoveByDirection();
        }

        velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void MoveByDirection()
    {
        if (velocity.x < 0)
        {
            if (velocity.y > 0)
            {
                direction = new Vector3(-0.5f, 0.5f);
            }
            else
            if (velocity.y < 0)
            {
                direction = new Vector3(-0.5f, -0.5f);
            }
            else
            {
                direction = new Vector3(-1.0f, 0.0f); // move left
            }
        }
        else if (velocity.x > 0)
        {
            if (velocity.y > 0)
            {
                direction = new Vector3(0.5f, 0.5f);
            }
            else
            if (velocity.y < 0)
            {
                direction = new Vector3(0.5f, -0.5f);
            }
            else
            {
                direction = new Vector3(1.0f, 0.0f); // move right
            }
        }
        transform.position += direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position -= direction;

    }
}
