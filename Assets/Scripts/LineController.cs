using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{

    private LineRenderer _lineRenderer;

    public Transform origin;
    public Transform destination;
    
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.2f;
        _lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, origin.position);
        _lineRenderer.SetPosition(1, destination.position);
    }
}
