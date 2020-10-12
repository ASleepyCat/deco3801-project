using UnityEngine;
using System.Collections;
using MonoBehaviours;


public class PlayerStartPoint : MonoBehaviour
{
    private MonoBehaviours.PlayerMovement thePlayer;
    private CameraManagerDefault theCamera;

    // Start is called before the first frame update
    
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        thePlayer.transform.position = transform.position;

        theCamera = FindObjectOfType<CameraManagerDefault>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
