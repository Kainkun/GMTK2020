using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public static Rect playspace;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Camera cam = Camera.main;
        playspace.Set(cam.transform.position.x, cam.transform.position.z, 2 * cam.aspect * cam.orthographicSize, 2 * cam.orthographicSize);
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
}
