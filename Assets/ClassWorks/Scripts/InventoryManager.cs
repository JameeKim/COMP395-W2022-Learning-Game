using System.Collections.Generic;
using UnityEngine;

namespace ClassWorks
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private bool displayed;

        [SerializeField]
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();

        private InventoryManagerUI inventoryManagerUI;

        private void Awake()
        {
            inventoryManagerUI = GetComponent<InventoryManagerUI>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
                displayed = !displayed;
        }

        private void OnGUI()
        {
            if (!displayed) return;

            if (inventoryManagerUI != null)
            {
                inventoryManagerUI.DisplayInventory();
            }
        }

        public void Add(InteractiveObject obj)
        {
            ObjectInteraction interaction = obj.Interaction;

            switch (interaction.Multiplicity)
            {
                case ObjectInteraction.InteractionMultiplicity.Unique:
                    Insert(obj);
                    break;
                case ObjectInteraction.InteractionMultiplicity.AccumulateCount:
                    AccumulateCount();
                    break;
                case ObjectInteraction.InteractionMultiplicity.AccumulateValue:
                    AccumulateValue();
                    break;
                case ObjectInteraction.InteractionMultiplicity.Invalid:
                default:
                    Debug.LogError($"Invalid interaction multiplicity ${interaction.Multiplicity.ToString()}");
                    break;
            }
        }

        private void Insert(InteractiveObject obj)
        {
            Debug.LogError($"Method {nameof(Insert)} not implemented");
        }

        private void AccumulateCount()
        {
            Debug.LogError($"Method {nameof(AccumulateCount)} not implemented");
        }

        private void AccumulateValue()
        {
            Debug.LogError($"Method {nameof(AccumulateValue)} not implemented");
        }
    }
}
