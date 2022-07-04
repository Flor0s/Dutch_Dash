using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    [SerializeField] private float xMin = -2, xMax = 2;
    [SerializeField] private float journyTime = 1f;
    [SerializeField] private float thrust = 20;
    [SerializeField] private float LaneSwitchStrength;
    private Rigidbody m_RigidBody;

    public bool GroundHit;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter()
    {
        GroundHit = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Player.transform.position += new Vector3(0, 0, -LaneSwitchStrength);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Player.transform.position += new Vector3(0, 0, LaneSwitchStrength);
        }

        if (Input.GetKeyDown(KeyCode.Space) && GroundHit)
        {
            m_RigidBody.AddForce(transform.up * thrust);
            GroundHit = false;
        }

        Vector3 newpos = new Vector3(Player.transform.position.x, Player.transform.position.y, Mathf.Clamp(Player.transform.position.z, xMax, xMin));
        Player.transform.position = Vector3.Lerp(Player.transform.position, newpos, journyTime);
    }
}