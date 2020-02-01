using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float customGravity = 20;
    public float speed;
    public float jumpSpeed, jumpIncreaseSpeed;
    public int maxJumps = 2;
    public float maxHoldTime;

    public bool characterControllerMode = false;

    private bool completedJump;
    private int jumpsInAir = 0;
    private float holdTime;
    private bool holdingJump;

    private CharacterController characterController;
    private new Rigidbody rigidbody;
    private new Collider collider;
    private Vector3 moveDir;

    void Awake ()
    {
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if(characterControllerMode)
        {
            characterController.enabled = true;
            rigidbody.isKinematic = true;
            collider.enabled = false;

            CharacterControllerUpdate();
        }
        else
        {
            characterController.enabled = false;
            rigidbody.isKinematic = false;
            collider.enabled = true;
        }
    }

    void CharacterControllerUpdate()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        float y = moveDir.y;
        moveDir = moveDir.normalized;
        moveDir.y = y;
        if (characterController.isGrounded)
        {
            moveDir.y = 0;
            moveDir *= speed;

            jumpsInAir = 0;
        }
        else
        {
            if (holdTime >= maxHoldTime)
            {
                moveDir.y -= customGravity * Time.deltaTime;
            }
            else
            {
                moveDir.y -= (customGravity*.8f) * Time.deltaTime;
            }
            moveDir.x *= speed;
            moveDir.z *= speed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            bool validJump = true;
            if (!holdingJump)
            {
                if (jumpsInAir >= maxJumps)
                {
                    validJump = false;
                }
                else
                {
                    holdTime = 0;
                    jumpsInAir++;
                    completedJump = false;
                }
            }
            if (validJump)
            {
                Jump();
                holdingJump = true;
            }
        }
        else
        {
            holdingJump = false;
            if (!completedJump)
            {
                moveDir.y /= 2.0f;
                completedJump = true;
            }
        }


        //moveDir.x = Mathf.Clamp(moveDir.x, -speed, speed);
        characterController.Move(moveDir * Time.deltaTime);
    }

    void Jump()
    {
        if(!holdingJump)
        {
            moveDir.y = jumpSpeed;
            return;
        }
        holdTime += Time.deltaTime;
        if (holdTime >= maxHoldTime)
        {
            if(!completedJump)
                moveDir.y /= 2.0f;

            completedJump = true;
            return;
        }
        moveDir.y *= jumpIncreaseSpeed;
    }
}
