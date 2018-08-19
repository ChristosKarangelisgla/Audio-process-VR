namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;

    public class ControlReactor : MonoBehaviour
    {
        public TextMesh go;
        [SerializeField]
        private float value;
        private VRTK_Control_UnityEvents controlEvents;

        private void Start()
        {
            controlEvents = GetComponent<VRTK_Control_UnityEvents>();
            if (controlEvents == null)
            {
                controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
            }

            controlEvents.OnValueChanged.AddListener(HandleChange);

        }

        private void HandleChange(object sender, Control3DEventArgs e)
        {
            
            go.text = e.value.ToString() + "(" + e.normalizedValue.ToString() + "%)";
            value = e.normalizedValue;
            
        }

        public float getValue()
        {
            return value;
        }

        public VRTK_Control_UnityEvents getControlEvents()
        {
            return controlEvents;
        }
    }
}