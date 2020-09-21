using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var transform1 = transform;
        var position = target.transform.position;
        transform1.position = new Vector3(position.x, position.y, transform1.position.z);
    }
}
