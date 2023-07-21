using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Animator leftHand;
    public Animator rightHand;

    public AudioSource walkSound;
    public AudioSource runSound;
    public AudioSource jumpSound;


    public float speed = 12f;
    public float tempSpeed;
    public float runSpeed = 12f;

    public float gravity = -9.81f;
    public float jump = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

	private void Start()
	{
        tempSpeed = speed;

    }
    // Update is called once per frame
    void Update()
    {
        speed = tempSpeed;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
		if (Input.GetKey(KeyCode.LeftShift))
		{
            tempSpeed = speed;
            speed = runSpeed;
            leftHand.SetBool("run", true);
            rightHand.SetBool("run", true);
            runSound.enabled = true;

		}
		else
		{
            rightHand.SetBool("run", false);
            leftHand.SetBool("run", false);
            runSound.enabled = false;
        }
 
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
            jumpSound.Play();
        }



        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
		if (x!= 0 || z!=0)
		{
            leftHand.SetBool("move", true);
            rightHand.SetBool("move", true);
            walkSound.enabled = true;
		}
		else
		{
            leftHand.SetBool("move", false);
            rightHand.SetBool("move", false);
            walkSound.enabled = false;


        }

    }
}

