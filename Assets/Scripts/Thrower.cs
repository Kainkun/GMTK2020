using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public float grabRange;
    public KeyCode grabKey;
    public bool holding=false;
    Transform target;
    public float throwForce;
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
            target.position=transform.position+transform.forward;
            target.LookAt(transform);
            if(Input.GetKeyUp(grabKey)){
                toss();
            }
        }
    }
    void toss(){
        target.GetComponent<Rigidbody>().AddForce((target.position-transform.position).normalized*throwForce,ForceMode.Impulse);
        holding=false;
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
        
    }
    void GrabAgent(Transform target){
        this.target=target;
        holding=true;
    }
}
