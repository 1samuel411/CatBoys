﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float offset;

    public float customGravity = 20;
    public float speed;
    public float grappleSpeed;
    public float jumpSpeed, jumpIncreaseSpeed;
    public int maxJumps = 2;
    public float maxHoldTime;

    public bool characterControllerMode = false;

    private bool completedJump;
    private int jumpsInAir = 0;
    private float holdTime;
    private bool holdingJump;

    private bool grappling;
    private bool canGrapple = true;
    private bool grappled;

    private CharacterController characterController;
    private new Rigidbody rigidbody;
    private new Collider collider;
    private LineRenderer lineRenderer;
    private Vector3 moveDir;
    private Vector3 grapplePos;
    private Vector3 grapplePosSmoothed;

    public Animator animatorA, animatorB;

    public Transform rotationDir;

    void Awake ()
    {
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        float speed = 0;
        if (characterControllerMode)
        {
            speed = characterController.velocity.magnitude;
            if (characterController.velocity.z < -0.1f)
            {
                front = true;
            }
            else if (characterController.velocity.z > 0.1f)
            {
                front = false;
            }
            else
            {
                if(Mathf.Abs(characterController.velocity.x) > 0.2f)
                    front = true;
            }
            characterController.enabled = true;
            rigidbody.isKinematic = true;
            collider.enabled = false;

            CharacterControllerUpdate();
        }
        else
        {
            front = true;
            speed = rigidbody.velocity.magnitude;
            characterController.enabled = false;
            rigidbody.isKinematic = false;
            collider.enabled = true;

            RigidbodyUpdate();
        }

        animatorA.SetBool("Front", front);
        animatorB.SetBool("Front", front);
        animatorA.SetFloat("Speed", speed);
        animatorB.SetFloat("Speed", speed);
        RaycastHit hit;
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 diff = (mousePos - playerScreenPos);
        float angle = (Mathf.Atan2(diff.y, -diff.x) * 180 / Mathf.PI) - 90;
        rotationDir.eulerAngles = new Vector3(0, angle, 0);
    }

    void RigidbodyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopGrappling();
        }

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position + (Vector3.up * (characterController.height / 2.0f)) + (Vector3.forward * 0.1f));
        lineRenderer.material.mainTextureScale = new Vector2((transform.position - grapplePosSmoothed).magnitude, 0.2f);
        lineRenderer.SetPosition(1, grapplePosSmoothed);

        grapplePosSmoothed = Vector3.MoveTowards(grapplePosSmoothed, grapplePos, 60 * Time.deltaTime);

        if ((grapplePos - grapplePosSmoothed).magnitude < 1)
        {
            Vector3 dir = grapplePos - (transform.position + (Vector3.up * (characterController.height / 2.0f)));
            if ((transform.position - grapplePos).magnitude <= 4f)
            {
                rigidbody.AddForce(dir * grappleSpeed, ForceMode.VelocityChange);
            }
            rigidbody.AddForce(dir * ((transform.position + (Vector3.up * (characterController.height / 2.0f))) - grapplePos).magnitude * grappleSpeed, ForceMode.Acceleration);
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 15);
        }
    }

    void ListenForGrapple()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 99999f))
            {
                Debug.Log(hit.transform.name);
                if(hit.transform.gameObject.tag == "Grappleable")
                {
                    Grapple(hit.point);
                }
            }
        }
    }

    void Grapple(Vector3 pos)
    {
        if (grappled)
            return;
        if (!canGrapple)
            return;
        grappled = true;
        grappling = true;
        grapplePosSmoothed = transform.position;
        grapplePos = pos;
        characterControllerMode = false;
        canGrapple = false;
    }

    void StopGrappling()
    {
        grappling = false;
        jumpsInAir = 0;
        characterControllerMode = true;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(characterController.isGrounded == false)
        {
            if (hit.point.y >= transform.position.y + characterController.height && moveDir.y > 0)
                moveDir.y = 0;
        }
    }

    private bool front;
    void CharacterControllerUpdate()
    {
        lineRenderer.positionCount = 0;
        ListenForGrapple();
        if (grappling)
            return;

        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        float y = moveDir.y;
        moveDir.y = 0;
        moveDir = moveDir.normalized;
        moveDir.y = y;
        if (characterController.isGrounded)
        {
            canGrapple = true;
            grappled = false;
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
