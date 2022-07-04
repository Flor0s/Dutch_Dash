using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform Player;
    [SerializeField] private float thrust = 20;
    [SerializeField] private float journyTime;
    [SerializeField] private int LaneNumber;
    [SerializeField] private float RayCastSize = 0.5f;
    private Rigidbody m_RigidBody;
    private Animator m_animator;

    private int LayerMask = 1 << 8;

    public bool GroundHit;

    public Transform[] Lanes;

    public AudioSource jumpsound;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody>();
        LaneNumber = 2;
    }

    private void OnCollisionEnter()
    {
        GroundHit = true;
    }

    //lane 0 is 2 in de array
    //dus
    //-2 = 0
    //-1 = 1
    // 0 = 2
    // 1 = 3
    // 2 = 4

    private void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, RayCastSize, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 0.5f, Color.red);
            Debug.Log("Did not Hit");
            PlayerMovementA();
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, RayCastSize, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1, Color.red);
            Debug.Log("Did not Hit");
            PlayerMovementD();
        }

        if (Input.GetKeyDown(KeyCode.Space) && GroundHit || Input.GetKeyDown(KeyCode.UpArrow) && GroundHit)
        {
            m_RigidBody.AddForce(transform.up * thrust);
            m_animator.SetBool("Jumping", true);
            jumpsound.Play();
            GroundHit = false;
        }

        if (GroundHit)
        {
            m_animator.SetBool("Jumping", false);
        }
        else
        {
            m_animator.SetBool("Jumping", true);
        }
    }

    public void UpdatePlayer()
    {
        //Player.position = Lanes[LaneNumber].position;
        Player.position = new Vector3(Player.position.x, Player.position.y, Lanes[LaneNumber].position.z);
    }

    public void PlayerMovementA()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (LaneNumber > 0)
            {
                LaneNumber -= 1;
                UpdatePlayer();
            }
        }
    }

    public void PlayerMovementD()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (LaneNumber < Lanes.Length - 1)
            {
                LaneNumber += 1;
                UpdatePlayer();
            }
        }
    }
}