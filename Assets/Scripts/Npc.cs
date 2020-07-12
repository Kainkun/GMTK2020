using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public bool walkAround;
    float startingSpeed;
    float startingAcceleration;
    

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        walkAround = true;
        startingSpeed = navMeshAgent.speed;
        startingAcceleration = navMeshAgent.acceleration;
    }

    void Start()
    {
        Vector3 rot = transform.eulerAngles;
        rot.y = Random.Range(0f, 360f);
        transform.eulerAngles = rot;

        StartCoroutine(HumanLoop());

    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    public float Speed
    {
        get { return navMeshAgent.speed; }
        set { navMeshAgent.speed = value;}
    }

    public float Acceleration
    {
        get { return navMeshAgent.acceleration; }
        set { navMeshAgent.acceleration = value; }
    }

    IEnumerator HumanLoop()
    {
        while(true)
        {
            while (walkAround)
            {

                if (Random.Range(0, 10) != 0) //10% chance to 
                {
                    yield return new WaitForSeconds(Random.Range(0, 2));
                    MoveRandomDirection(5);
                    yield return new WaitForSeconds(Random.Range(1, 5));
                }
                else
                {
                    yield return new WaitForSeconds(Random.Range(1, 5));
                    MoveRandomPosition(5);
                    yield return new WaitForSeconds(Random.Range(5, 10));
                }

                yield return null;
            }
            yield return null;
        }
    }

    public void GoToPosition(Vector3 position)
    {
        position.y = 0;
        navMeshAgent.SetDestination(position);
    }

    void MoveRandomDirection(float maxDistance = 1)
    {
        Vector3 r = Random.insideUnitSphere;
        r.y = 0;
        GoToPosition(transform.position + r * maxDistance);
    }

    void MoveRandomPosition(float maxDistance = 1)
    {
        Vector3 pos = Manager.RandomPositionInRect(Manager.playspace);
        GoToPosition(pos);
    }

    public void RunAwayFrom(Vector3 position, float time)
    {
        StartCoroutine(RunAway(position, time));
    }

    IEnumerator RunAway(Vector3 position, float time)
    {
        walkAround = false;
        position.y = 0;
        //Vector3 spread = Random.insideUnitSphere * 1;
        //spread.y = 0;
        GoToPosition((transform.position - position).normalized * 10);
        GetComponent<Infection>().spriteRenderer.color = Color.blue;
        Speed *= 3;
        Acceleration *= 3;

        yield return new WaitForSeconds(time);

        walkAround = true;
        GetComponent<Infection>().spriteRenderer.color = Color.white;
        Speed = startingSpeed;
        Acceleration = startingAcceleration;

    }

}
