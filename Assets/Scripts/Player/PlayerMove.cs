using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector3 Dir = Vector3.zero;
    private CharacterController Cac;
    
    void Start()
    {
        Cac = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Cac.isGrounded)
        {
            Dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Dir = transform.TransformDirection(Dir);
            Dir *= speed;

            if (Input.GetButton("Jump"))
            {
                Dir.y = jumpSpeed;
            }
        }

        Dir.y -= gravity * Time.deltaTime;
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * speed*130);

        Cac.Move(Dir * Time.deltaTime);
    }
}
