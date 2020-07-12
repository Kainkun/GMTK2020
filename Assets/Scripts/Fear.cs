using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : MonoBehaviour
{
    float fearRadius = 5;

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
                    npcComp.RunAwayFrom(transform.position, 2);
                }
            }
            foreach (GameObject npc in Manager.instance.infectedNpcs)
            {
                Vector2 npcPos;
                npcPos.x = npc.transform.position.x;
                npcPos.y = npc.transform.position.z;

                if (Vector2.Distance(playerPos, npcPos) < 10)
                {
                    Npc npcComp = npc.GetComponent<Npc>();
                    npcComp.GoToPosition(transform.position);
                }
            }
        }
    }
}
