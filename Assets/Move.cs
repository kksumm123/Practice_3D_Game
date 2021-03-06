using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 3f;
    public float lookSensitivity;
    Rigidbody rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    Vector3 pos;
    float moveX;
    float moveZ;
    public float forceY = 5.5f;
    bool isjmping = false;

    void Update()
    {
        Move4Dir();
        Jump();
        //transform.Rotate(0f, Input.GetAxis("Mouse X") * speed, 0f, Space.World);
        //transform.Rotate(Input.GetAxis("Mouse Y") * speed, 0f, 0f);
    }

    void Jump()
    {
        if (isjmping == false && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * forceY, ForceMode.Impulse);
            isjmping = true;
        }
    }

    void Move4Dir()
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isjmping = false;
    }
}
