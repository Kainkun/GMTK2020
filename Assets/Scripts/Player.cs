using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    Vector2 input;
    NavMeshAgent navMeshAgent;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {

    }


    void Update()
    {
        GetInput();
        GetClick();
        Movement();
    }

    void GetInput()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        input = Vector2.ClampMagnitude(input, 1);
    }

    void Movement()
    {
        Vector3 velocity = new Vector3(input.x, 0, input.y) * navMeshAgent.speed;
        navMeshAgent.velocity = velocity;
    }

    void GetClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform.GetComponent<Infection>())
            {
                if (hit.transform.GetComponent<Infection>().infected)
                    hit.transform.GetComponent<Infection>().Explode();

            }
        }
    }
}
