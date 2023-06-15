using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    public Material activeMaterial;
    public Material disableMaterial;

    public ColliderGameController gameController;

    private Renderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        gameController.StartGame();
        _renderer.material = activeMaterial;
    }
}
