using UnityEngine;

namespace MonoBehaviours
{
    public class CameraManager : MonoBehaviour
    {
        public Transform target;

        // Update is called once per frame
        private void Update()
        {
            var transform1 = transform;
            var position = target.transform.position;
            transform1.position = new Vector3(position.x, position.y, transform1.position.z);
        }
    }
}
