using UnityEngine;

namespace MonoBehaviours
{
    public class CameraManager : MonoBehaviour
    {
        public Transform target;
        public Vector2 minPosition;
        public Vector2 maxPosition;
        public float smoothing;

        // Update is called once per frame

        void Start()
        {
           
        }
        private void Update()
        {
            if (transform.position != target.position)
            {
                Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

                targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
                targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }
            else
            {

            }
        }
    }
}
