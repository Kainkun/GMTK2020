using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public static Rect playspace;
    public TextMeshProUGUI UiStats;
    public GameObject UiWin;

    static int maxNpc, healthyNpc, infectedNpc, deadNpc;

    public static int MaxNpc
    {
        get { return maxNpc; }
        set
        {
            maxNpc = value;
            UpdateUI();
        }
    }

    public static int HealthyNpc
    {
        get { return healthyNpc; }
        set
        {
            healthyNpc = value;
            UpdateUI();
        }
    }

    public static int InfectedNpc
    {
        get { return infectedNpc; }
        set
        {
            infectedNpc = value;
            UpdateUI();
        }
    }

    public static int DeadNpc
    {
        get { return deadNpc; }
        set
        {
            deadNpc = value;
            UpdateUI();
        }
    }



    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Camera cam = Camera.main;
        playspace.Set(cam.transform.position.x, cam.transform.position.z, 2 * cam.aspect * cam.orthographicSize, 2 * cam.orthographicSize);
        UpdateUI();
    }

    void Update()
    {
        
    }

    public static Vector3 RandomPositionInRect(Rect rect)
    {
        float x = Random.Range(-rect.xMax, rect.xMax);
        float y = Random.Range(-rect.yMax, rect.yMax);

        return new Vector3(x, 0, y);
    }

    static void UpdateUI()
    {
        /*  NPCs: ##
            Healthy: ##
            Infected: ##
            Dead: ##*/

        string stats =
            $"NPCS: {MaxNpc}\n" +
            $"Healthy: {HealthyNpc}\n" +
            $"Infected: {InfectedNpc}\n" +
            $"Dead: {DeadNpc}";
        Manager.instance.UiStats.SetText(stats);

        if (Time.frameCount > 0 && healthyNpc == 0)
            Manager.instance.UiWin.SetActive(true);
    }
}
