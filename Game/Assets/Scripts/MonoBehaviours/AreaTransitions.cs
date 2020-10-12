using System.Collections;
using System.Collections.Generic;
using MonoBehaviours;

using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    private CameraManager cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;
    public Vector3 movePlayer;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam.minPosition = newMinPos;
            cam.maxPosition = newMaxPos;

            other.transform.position += movePlayer;
        }
    }
}
