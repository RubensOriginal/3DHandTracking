using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class SceneController : MonoBehaviour
{
    public List<GameObject> prefabs;
    
    public List<GameObject> objects;
    
    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { 
            objects.Add(Instantiate(prefabs[0]));
        }
    }
}
