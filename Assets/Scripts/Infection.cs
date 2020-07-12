using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite sick;
    public Sprite healthy;

    public bool infected=false;

    private void Awake()
    {
        Manager.MaxNpc++;

        if (infected)
        {
            Manager.InfectedNpc++;
            Manager.instance.infectedNpcs.Add(gameObject);
        }
        else
        {
            Manager.HealthyNpc++;
            Manager.instance.healthyNpcs.Add(gameObject);
        }
    }

    private void Start()
    {

    }

    public void Infect(){
        if (infected)
            return;

        infected=true;
        spriteRenderer.sprite=sick;
        Manager.HealthyNpc--;
        Manager.instance.healthyNpcs.Remove(gameObject);
        Manager.InfectedNpc++;
        Manager.instance.infectedNpcs.Add(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("agent")){
            if(collision.collider.GetComponent<Infection>().infected){
                Infect();
            }
        }
    }

    private void OnDestroy()
    {
        if (infected)
        {
            Manager.InfectedNpc--;
            Manager.instance.infectedNpcs.Remove(gameObject);
        }
        else
        {
            Manager.HealthyNpc--;
            Manager.instance.healthyNpcs.Remove(gameObject);
        }
    }
}
