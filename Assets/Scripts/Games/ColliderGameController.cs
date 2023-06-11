using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGameController : MonoBehaviour
{
    public GameObject prefab;
    
    public bool isRunning;
    public GameObject currentGO;
    
    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (!isRunning)
            {
                currentGO = Instantiate(prefab, transform);
                currentGO.GetComponent<ColliderObject>().gameController = this;
                isRunning = true;
            }
            else
            {
                Destroy(currentGO);
                isRunning = false;
            }
        }
    }

    public void Collision()
    {
        float x = Random.Range(-2.5f, 4.5f);
        float z = Random.Range(-7, -1);
        
        currentGO = Instantiate(prefab, new Vector3(x, 5.0f, z), new Quaternion(0,0,0, 0),transform);
        currentGO.GetComponent<ColliderObject>().gameController = this;
    }
}
