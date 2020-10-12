using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerDefault : MonoBehaviour
{
    public Transform target;
    private static bool cameraExist;

    // Start is called before the first frame update
    void Start()
    {
        if (!cameraExist)
        {
            cameraExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}