using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Thrower : MonoBehaviour
{
    public float grabRange;
    public KeyCode grabKey;
    public bool holding=false;
    Transform target;
    public float throwForce;
    public GameObject whiffParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(grabKey)){
            AttemptGrab();
        }
        if(holding){
            target.position=Vector3.Lerp(target.position,transform.position+transform.forward,0.05f);
            //target.LookAt(transform);
            if(Input.GetKeyUp(grabKey)){
                toss();
            }
        }
    }
    void toss(){
        target.GetComponent<Rigidbody>().AddForce((target.position-transform.position).normalized*throwForce,ForceMode.Impulse);
        target.GetComponent<NavMeshAgent>().isStopped=false;
        holding=false;
        target=null;
    }
    void AttemptGrab(){
        
        Collider[] hits=Physics.OverlapSphere(transform.position+transform.forward,grabRange);
        foreach (var item in hits)
        {
            if(item.CompareTag("agent")){
                GrabAgent(item.transform);
                return;
            }
        }
        if(target==null){
            whiff();
        }
    }
    void whiff(){
        Instantiate(whiffParticles,transform.position+transform.forward,transform.rotation);
    }
    void GrabAgent(Transform target){
        this.target=target;
        holding=true;
        target.GetComponent<NavMeshAgent>().isStopped=true;
    }
}
