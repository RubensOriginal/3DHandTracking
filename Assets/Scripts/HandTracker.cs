using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour
{

    public UDPServer server;
    public GameObject[] handPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (server.Data == null)
            return;
        
        string data = server.Data.Remove(server.Data.Length - 1, 1).Remove(0, 1);

        string[] points = data.Split(',');

        for (int i = 0; i < points.Length; i += 3)
        {
            float x = 7.0f - float.Parse(points[i]) / 100.0f;
            float y = float.Parse(points[i + 1]) / 100.0f;
            float z = 0.5f + (float.Parse(points[i + 2]) / 100.0f * (-1.0f));

            handPoints[i / 3].transform.localPosition = new Vector3(x, z, y * (-1.0f));
        }

        // Debug.Log(data);
    }
}
