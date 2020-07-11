using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Sprite sick;
    public Sprite healthy;

    public bool infected=false;
    public void Infect(){
        infected=true;
        renderer.sprite=sick;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("agent")){
            if(collision.collider.GetComponent<Infection>().infected){
                Infect();
            }
        }
    }
}
