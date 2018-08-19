namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DenyRotation : MonoBehaviour
    {
        // reference of rotation of the tab label
        Quaternion rotation;
        // reference of position of the tab label
        Vector3 position;

        void Awake()
        {
            //initialise the rotation and position to current values
            rotation = transform.rotation;
            position = transform.position;
        }
        void Update()
        {
            // updates the rotation and position to static values denying any movement done by the knob
            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
