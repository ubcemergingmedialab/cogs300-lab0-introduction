using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1f;
    private int numJump = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") & numJump < 2) {
            rb.AddForce(new Vector3(0f, 400f, 0f));
            numJump++;
        }

        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Vector3 direction = new Vector3(h, 0f, v);
        transform.Translate(direction);


    }

    void OnCollisionEnter(Collision collision) {
        numJump = 0;
    }
}
