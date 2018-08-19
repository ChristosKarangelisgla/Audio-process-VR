namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class Gain : MonoBehaviour
    {
        // A reference of the knobScript
        private Knob knobScript;
        // A reference the intrument gameobject
        private GameObject instrument;


        void Start()
        {
            // connects the reference with the knob script of that object
            knobScript = this.GetComponent<Knob>();
            // connects the refernce with the instrument that is related with that object
            instrument = knobScript.getObjectComps().getInstrument();

            // Sets the name of the knob that will be shown in the knob label
            knobScript.setFaderName("Gain");
            // Sets the parameter name that will be used in order to manipulate the value of tha parameter
            knobScript.setParam("Gain");
        }

        // Update is called once per frame
        void Update()
        {
            // calculates the value of the parameter depending on the position of the knob
            float value = (transform.eulerAngles.y - 50) * 0.04f;
            // Sets the value and type of the paramenter
            knobScript.setValue(value, "dB");

            // calculates the size of the parameter depending on the value
            float size = (value / 20) + 0.7f;
            // changes the scale of the instrument
            instrument.transform.localScale = new Vector3(size, size, size);

        }
    }
}