namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class ProcessKnob : MonoBehaviour
    {
        // A reference of the knobScript
        private Knob knobScript;

        // A reference the intrument gameobject
        private GameObject instrument;

        // A reference of the of canvas of this object
        private Canvas canvas;

        // The group that the process belongs to.
        [SerializeField]
        private string group;

        // The process of the knob
        [SerializeField]
        private string process;

        // The parameter from the audio mixer that the knob manipulates
        [SerializeField]
        private string param;

        // Values that will be used to caluclate the value of the parameter
        [SerializeField]
        private float value1;

        [SerializeField]
        private float value2;

        [SerializeField]
        private float value3;

        // The type of the paramater
        [SerializeField]
        private string type;

        // Use this for initialization
        void Start()
        {
            // connects the refernce with the knob script of that object
            knobScript = this.GetComponent<Knob>();

            // connects the refernce with the instrument that is related with that object
            instrument = knobScript.getObjectComps().getInstrument();

            if (param == "EQGainLM" || param == "EQGainMH")
            {
                transform.rotation = Quaternion.Euler(0, 145f, 0);
            }

            if (process == "Pan")
            {
                canvas = GetComponentInChildren<Canvas>();

                // Finds Instrument script on Instrument game object and sets this knob in the knob game object reference
                
            }

            // Sets the name of the knob that will be shown in the knob label
            knobScript.setFaderName(group + "\n" + process);
            // Sets the parameter name that will be used in order to manipulate the value of tha parameter
            knobScript.setParam(param);

            
        }

        // Update is called once per frame
        void Update()
        {
            // calculates the value of the parameter depending on the position of the knob
            float value = value1 + (transform.eulerAngles.y - value3) * value2;
            // Sets the value and type of the paramenter
            knobScript.setValue(value, type);

            if (param == "Gain")
            {
                // calculates the size of the parameter depending on the value
                float size = (value / 20) + 0.7f;
                // changes the scale of the instrument
                instrument.transform.localScale = new Vector3(size, size, size);
            }


            if (process == "Pan")
            {
                if (canvas.enabled == true)
                {
                    // sets the new potision of the instrument depending on the value
                    instrument.transform.position = new Vector3(value, instrument.transform.position.y, instrument.transform.position.z);
                }
                else
                {

                    rotationPanKnob();
                   
                }

                // calculates the pan value depending on the position of the Instrument game object in x
                float pan = instrument.transform.position.x / 10;
                // finds the audiosource on Instrument Object and manipulaters the pan value
                instrument.GetComponent<AudioSource>().panStereo = pan;
            }

        }

        // Method that changes the pan rotation knob
        public void rotationPanKnob()
        {
            // calculates the pan value from the position of the instrument gameobject in x axis
            float panValue = (instrument.transform.position.x * 12.5f) + 175;


            // changes the rotation of the knob in pan value
            this.transform.rotation = Quaternion.Euler(0, panValue, 0);

        }

    }
}