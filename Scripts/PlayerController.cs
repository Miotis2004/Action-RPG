using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : NetworkBehaviour
{
    public Camera playerFollowCam;

    public float animSpeed = 1.5f;
    public float lookSmoother = 3.0f;
    public bool useCurves = true;

    public float useCurvesHeight = 0.5f;

    public float forwardSpeed = 7.0f;
    public float backwardSpeed = 2.0f;
    public float rotateSpeed = 2.0f;
    public float jumpPower = 3.0f;

    private CapsuleCollider col;
    private Rigidbody rb;

    private Vector3 velocity;

    private float orgColHeight;
    private Vector3 orgVectColCenter;

    private TargetedSpell ts;

    private NetworkAnimator anim;
    private AnimatorStateInfo currentBaseState;

    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int restState = Animator.StringToHash("Base Layer.Rest");

    private void Awake()
    {
        anim = GetComponent<NetworkAnimator>();
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        

        orgColHeight = col.height;
        orgVectColCenter = col.center;
    }

    private void Start()
    {
        if (!isLocalPlayer)
        {
            playerFollowCam.gameObject.SetActive(false);
            
        }
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        
    }

    private void FixedUpdate()
    {
        
        if (!isLocalPlayer)
        {
            return;
        }

        


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.animator.SetFloat("Speed", v);
        anim.animator.SetFloat("Direction", h);
        anim.animator.speed = animSpeed;
        currentBaseState = anim.animator.GetCurrentAnimatorStateInfo(0);
        rb.useGravity = true;

        if (v > 0.1)
        {
            
            v *= forwardSpeed * Time.fixedDeltaTime;
        }
        else if (v < -0.1)
        {
           
            v *= backwardSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (currentBaseState.nameHash == locoState)
            {
                if (!anim.animator.IsInTransition(0))
                {
                    rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                    anim.animator.SetBool("Jump", true);
                }
            }
        }
        
            transform.Translate(Vector3.forward * v);
            transform.Rotate(0, h * rotateSpeed, 0);
        
        

        if (currentBaseState.nameHash == locoState)
        {
            if (useCurves)
            {
                ResetCollider();
            }
        }
        else if (currentBaseState.nameHash == jumpState)
        {
            //playerFollowCam.SendMessage("setCameraPositionJumpView");

            if (!anim.animator.IsInTransition(0))
            {
                if (useCurves)
                {
                    float jumpHeight = anim.animator.GetFloat("JumpHeight");
                    float gravityControl = anim.animator.GetFloat("GravityControl");

                    if (gravityControl > 0)
                    {
                        rb.useGravity = false;
                    }

                    Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
                    RaycastHit hit = new RaycastHit();

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.distance > useCurvesHeight)
                        {
                            col.height = orgColHeight - jumpHeight;
                            float adjCenterY = orgVectColCenter.y + jumpHeight;
                            col.center = new Vector3(0, adjCenterY, 0);
                        }
                        else
                        {
                            ResetCollider();
                        }
                    }
                }
                anim.animator.SetBool("Jump", false);
            }
        }
        else if (currentBaseState.nameHash == idleState)
        {
            if (useCurves)
            {
                ResetCollider();
            }
            if (Input.GetButtonDown("Jump"))
            {
                anim.animator.SetBool("Rest", true);
            }
        }
        else if (currentBaseState.nameHash == restState)
        {
            if (!anim.animator.IsInTransition(0))
            {
                anim.animator.SetBool("Rest", false);
            }
        }
    }

    private void ResetCollider()
    {
        col.height = orgColHeight;
        col.center = orgVectColCenter;
    }

    
    
}
