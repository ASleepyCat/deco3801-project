using UnityEngine;

namespace MonoBehaviours
{
    public class CameraManager : MonoBehaviour
    {
        public Transform target;
        public Vector2 minPosition;
        public Vector2 maxPosition;
        public float smoothing;
        
        private void FixedUpdate()
        {
            var position = target.position;
            var transformPosition = transform.position;
            var targetPosition = new Vector3(position.x, position.y, transformPosition.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transformPosition = Vector3.Lerp(transformPosition, targetPosition, smoothing);
            transform.position = transformPosition;
        }
    }
}
