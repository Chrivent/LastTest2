using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name;
    public long ID;
    public bool IsLocal;
    public PlayerMovement Movement;

    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Movement != null && IsLocal)
        {
            Movement.Move();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 startPos = transform.position + transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(startPos, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Player")))
            {
                Debug.DrawRay(startPos, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                Debug.Log("Player Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
                Debug.Log("Shot");
            }
        }
    }
}
