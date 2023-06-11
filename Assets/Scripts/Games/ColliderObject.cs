using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObject : MonoBehaviour
{
    public ColliderGameController gameController;

    private bool _destroyed;
    
    // Start is called before the first frame update
    void Start()
    {
        _destroyed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");

        if (_destroyed)
            return;

        if (collision.gameObject.name.StartsWith("Point"))
        {
            _destroyed = true;
            gameController.Collision();
            Destroy(gameObject);
        }
    }
}
