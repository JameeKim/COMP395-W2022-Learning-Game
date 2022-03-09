using UnityEngine;

namespace ClassWorks
{
    public class ObjectInteraction : MonoBehaviour
    {
        public enum InteractionType
        {
            Invalid = -1,
            PutInInventory = 0,
            Use,
            DestroySelf,
            DestroyPlayer,
            DestroySelfAndPlayer,
            GetKicked,
            Grabbed,
            Thrown, // only valid if already Grabbed
            MaxInteractionType = 20,
        }

        public enum InteractionMultiplicity
        {
            Invalid = -1,
            Unique = 0,
            AccumulateCount,
            AccumulateValue,
        }

        #region InspectorProperties

        [SerializeField]
        private InteractionType interactionType;

        [SerializeField]
        private InteractionMultiplicity interactionMultiplicity;

        #endregion // InspectorProperties

        public InteractionType Type => interactionType;
        public InteractionMultiplicity Multiplicity => interactionMultiplicity;

        public void HandleInteraction(GameObject player)
        {
            switch (interactionType)
            {
                case InteractionType.PutInInventory:
                    HandlePutInInventory(player);
                    break;
                case InteractionType.Use:
                    HandleUse();
                    break;
                case InteractionType.DestroySelf:
                    HandleDestroySelf();
                    break;
                case InteractionType.DestroyPlayer:
                    HandleDestroyPlayer(player);
                    break;
                case InteractionType.DestroySelfAndPlayer:
                    HandleDestroySelfAndPlayer(player);
                    break;
                case InteractionType.GetKicked:
                    HandleGetKicked();
                    break;
                case InteractionType.Grabbed:
                    HandleGrabbed(player);
                    break;
                case InteractionType.Thrown:
                    HandleThrown(player);
                    break;
                case InteractionType.MaxInteractionType:
                case InteractionType.Invalid:
                default:
                    Debug.LogError($"Invalid interaction type {interactionType.ToString()}");
                    break;
            }
        }

        private void HandlePutInInventory(GameObject player)
        {
            InventoryManager inventoryManager = player.GetComponent<InventoryManager>();
            if (inventoryManager == null)
                inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            inventoryManager.Add(GetComponent<InteractiveObject>());
        }

        private void HandleUse()
        {
            Debug.LogError("Method {nameof(HandleUse)} not implemented");
        }

        private void HandleDestroySelf()
        {
            Debug.LogError($"Method {nameof(HandleDestroySelf)} not implemented");
        }

        private void HandleDestroyPlayer(GameObject player)
        {
            Debug.LogError($"Method {nameof(HandleDestroyPlayer)} not implemented");
        }

        private void HandleDestroySelfAndPlayer(GameObject player)
        {
            HandleDestroyPlayer(player);
            HandleDestroySelf();
        }

        private void HandleGetKicked()
        {
            Debug.LogError($"Method {nameof(HandleGetKicked)} not implemented");
        }

        private void HandleGrabbed(GameObject player)
        {
            Debug.LogError($"Method {nameof(HandleGrabbed)} not implemented");
        }

        private void HandleThrown(GameObject player)
        {
            Debug.LogError($"Method {nameof(HandleThrown)} not implemented");
        }
    }
}
