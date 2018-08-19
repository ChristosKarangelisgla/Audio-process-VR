namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class EqGainLM : MonoBehaviour
    {
        // A reference of the knobScript
        //private Knob knobScript;

        // Use this for initialization
        void Start()
        {
            //Sets the initial rotation of the knob
            transform.rotation = Quaternion.Euler(0, 145f, 0);

            // connects the refernce with the knob script of that object
            //knobScript = this.GetComponent<Knob>();

            // Sets the name of the knob that will be shown in the knob label
            //knobScript.setFaderName("EQ LM\nGain");
            // Sets the parameter name that will be used in order to manipulate the value of tha parameter
            //knobScript.setParam("EQGainLM");
        }

        // Update is called once per frame
        void Update()
        {
            // calculates the value of the parameter depending on the position of the knob
            //float value = 0.05f + (transform.eulerAngles.y - 50) * 0.01f;
            // Sets the value and type of the paramenter
            //knobScript.setValue(value, "dB");

        }
    }
}