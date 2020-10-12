using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoBehaviours;
using UnityEngine.SceneManagement;

public class PlayMultipleStartPoint : MonoBehaviour
{
    private MonoBehaviours.PlayerMovement thePlayer;
    private CameraManagerDefault theCamera;

    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
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
