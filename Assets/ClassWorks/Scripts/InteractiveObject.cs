using UnityEngine;

namespace ClassWorks
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CustomGameObjectData))]
    public class InteractiveObject : MonoBehaviour
    {
        [Header("Rotation")]
        [SerializeField]
        private Vector3 rotationAxis = Vector3.up;

        [SerializeField]
        [Tooltip("The speed of rotation in deg/sec")]
        private float rotationSpeed;

        [Header("Debugging Data")]
        [SerializeField]
        private CustomGameObjectData customGameObjectData;

        [SerializeField]
        private ObjectInteraction objectInteraction;

        public ObjectInteraction Interaction => objectInteraction;

        private void Awake()
        {
            customGameObjectData = GetComponent<CustomGameObjectData>();
            objectInteraction = GetComponent<ObjectInteraction>();
        }

        private void Update()
        {
            float rotationAngle = rotationSpeed * Time.deltaTime; // phi = w * dt
            transform.Rotate(rotationAxis, rotationAngle);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (objectInteraction != null)
                    objectInteraction.HandleInteraction(other.gameObject);
            }
        }
    }
}
