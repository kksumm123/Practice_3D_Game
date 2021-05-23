using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 3f;

    Rigidbody rgdbody;
    private void Start()
    {
        rgdbody = GetComponent<Rigidbody>();
    }

    Vector3 pos;
    float moveX;
    float moveZ;
    public float forceY = 300;
    
    void Update()
    {
        Move4Dir();
        Jump();
    }

    private void Jump()
    {
        if (transform.position.y == 0 && Input.GetKeyDown(KeyCode.Space))
            rgdbody.AddForce(0, forceY, 0);
    }

    private void Move4Dir()
    {
        moveX = 0; moveZ = 0;
        if (Input.GetKey(KeyCode.W))
            moveZ = 1;
        if (Input.GetKey(KeyCode.S))
            moveZ = -1;
        if (Input.GetKey(KeyCode.A))
            moveX = -1;
        if (Input.GetKey(KeyCode.D))
            moveX = 1;

        pos = transform.position;
        pos.x += moveX * speed * Time.deltaTime;
        pos.z += moveZ * speed * Time.deltaTime;
        transform.position = pos;
    }
}
