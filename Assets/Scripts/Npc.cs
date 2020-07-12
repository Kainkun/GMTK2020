using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public bool walkAround;
    
    Vector3 movementDirection;

    public float avoidanceStrength;
    public float visionRadius;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        walkAround = true;
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
        if(movementDirection!=Vector3.zero){
            Collider[] nearCols=Physics.OverlapSphere(transform.position,visionRadius);
            Vector3 total=Vector3.zero;
            int count=0;
            foreach (var item in nearCols)
            {         
                if(item!=GetComponent<Collider>()&&item.CompareTag("agent")){
                    total -= (transform.position - item.transform.position)*(transform.position-item.transform.position).magnitude;
                    count++;
                }
            }
            if(count!=0){
                movementDirection = Vector3.Lerp(movementDirection, -total, avoidanceStrength);
                movementDirection.y=0;
                movementDirection.Normalize();
            }
            navMeshAgent.SetDestination(transform.position+movementDirection);
        }
    }
    private void avoidOtherAgents(){

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
        movementDirection=r.normalized;
    }

    void MoveRandomPosition(float maxDistance = 1)
    {
        Vector3 pos = Manager.RandomPositionInRect(Manager.playspace);
        Vector3 direction=(pos-transform.position);
        direction.y=0;
        direction.Normalize();
        movementDirection=direction;
    }

    public void RunAwayFrom(Vector3 position, float distance)
    {
        walkAround = false;
        position.y = 0;
        Vector3 spread = Random.insideUnitSphere * 1;
        spread.y = 0;
        GoToPosition((transform.position - position).normalized * distance + spread);
    }

}
