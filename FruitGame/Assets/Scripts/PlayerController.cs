using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    private float jumpForce = 5.0f;

    [SerializeField]
    public KeyCode jump;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0);


        rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);
        //transform.Translate(direction * speed * Time.deltaTime);


        if (Input.GetKey(jump))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }


    }
}
