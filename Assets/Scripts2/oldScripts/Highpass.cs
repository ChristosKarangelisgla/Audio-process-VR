namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class Highpass : MonoBehaviour
    {
        // A reference of the knobScript
        private Knob knobScript;

        // Use this for initialization
        void Start()
        {
            // connecting the refernce with the knob script of that object
            knobScript = this.GetComponent<Knob>();

            // Sets the name of the knob that will be shown in the knob label
            knobScript.setFaderName("Filter\nHighpass");
            // Sets the parameter name that will be used in order to manipulate the value of tha parameter
            knobScript.setParam("Highpass");
        }

        // Update is called once per frame
        void Update()
        {
            // calculates the value of the parameter depending on the position of the knob
            float value = (transform.eulerAngles.y - 50) * 88;
            // Sets the value and type of the paramenter
            knobScript.setValue(value, "Hz");

        }
    }
}