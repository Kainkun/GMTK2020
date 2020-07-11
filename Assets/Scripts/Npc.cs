using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movementGoal;
    public float moveSpeed = 0.15f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(HumanLoop());
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = (movementGoal - rb.position).normalized * moveSpeed;
        //rb.AddForce((movementGoal - rb.position).normalized * moveSpeed);
    }

    IEnumerator HumanLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));
            MoveRandomDirection(5);

            yield return null;
        }
    }

    void GoToPosition(Vector2 position)
    {
        movementGoal = position;
    }

    void MoveRandomDirection(float maxDistance = 1)
    {
        GoToPosition(rb.position + Random.insideUnitCircle * maxDistance);
    }

}
