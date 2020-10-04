using UnityEngine;

namespace MonoBehaviours
{
    public class CameraManager : MonoBehaviour
    {
        public Transform target;
        public Vector2 minPosition;
        public Vector2 maxPosition;
        
        // Update is called once per frame
        private void Update()
        {
            var transform1 = transform;
            Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform1.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform1.position = new Vector3(targetPosition.x, targetPosition.y, transform1.position.z);
        }
    }
}
