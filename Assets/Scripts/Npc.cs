using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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

    }

    IEnumerator HumanLoop()
    {
        while(true)
        {
            if(Random.Range(0,10) != 0) //10% chance to 
            {
                yield return new WaitForSeconds(Random.Range(1, 5));
                MoveRandomDirection(5);
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(1, 5));
                MoveRandomPosition(5);
                yield return new WaitForSeconds(Random.Range(5, 10));
            }

            yield return null;
        }
    }

    void GoToPosition(Vector3 position)
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

}
