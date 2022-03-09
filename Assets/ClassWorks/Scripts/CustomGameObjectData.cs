using UnityEngine;

namespace ClassWorks
{
    public class CustomGameObjectData : MonoBehaviour
    {
        [System.Serializable]
        public enum CustomObjectType
        {
            Invalid = -1,
            Unique = 0,
            Coin,
            Ruby,
            Emerald,
            Diamond,
            Heart,
            Flag,
        }

        [SerializeField]
        private CustomObjectType customObjectType;

        [SerializeField]
        public string displayName;

        private void OnValidate()
        {
            if (displayName == "")
            {
                displayName = "Unnamed Object";
            }
        }
    }
}
