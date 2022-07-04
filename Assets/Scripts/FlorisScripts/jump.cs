using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [SerializeField] private float thrust = 20;
    public bool GroundHit;
    private Rigidbody m_RigidBody;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter()
    {
        GroundHit = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundHit)
        {
            m_RigidBody.AddForce(transform.up * thrust);
            GroundHit = false;
        }
    }
}