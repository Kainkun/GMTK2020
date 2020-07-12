using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : MonoBehaviour
{
    float fearRadius = 3;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Vector2 playerPos;
            playerPos.x = transform.position.x;
            playerPos.y = transform.position.z;
            foreach (GameObject npc in Manager.instance.healthyNpcs)
            {
                Vector2 npcPos;
                npcPos.x = npc.transform.position.x;
                npcPos.y = npc.transform.position.z;

                if(Vector2.Distance(playerPos, npcPos) < fearRadius)
                {
                    Npc npcComp = npc.GetComponent<Npc>();
                    npc.GetComponent<Infection>().spriteRenderer.color = Color.blue;
                    npcComp.Speed = npcComp.Speed * 3;
                    npcComp.Speed = npcComp.Acceleration * 3;
                    npcComp.RunAwayFrom(transform.position, 5);
                }
            }
        }
    }
}
