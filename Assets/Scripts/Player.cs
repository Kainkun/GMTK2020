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
}
