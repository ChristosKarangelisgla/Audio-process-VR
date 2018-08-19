namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class Pan : MonoBehaviour
    {
        // A reference of the knobScript
        private Knob knobScript;
        // A reference of the of the intrument object
        private GameObject instrument;
        // A reference of the of canvas of this object
        private Canvas canvas;


        void Start()
        {
            // connects the reference with the knob script of that object
            knobScript = this.GetComponent<Knob>();
            // connects the refernce with the instrument that is related with that object
            instrument = knobScript.getObjectComps().getInstrument();
            // connects the refernce with the canvas that exist in that object as a childeren object
            canvas = GetComponentInChildren<Canvas>();

            // Sets the name of the knob that will be shown in the knob label
            knobScript.setFaderName("Pan");

            knobScript.setParam("DontSet");

            // Finds Instrument script on Instrument game object and sets this knob in the knob game object reference
            //----> instrument.GetComponent<Instrument>().setKnob(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            // calculates the value of the parameter depending on the position of the knob
            float value = (transform.eulerAngles.y - 175) / 12.5f; // * 0.08
            if (canvas.enabled == true)
            {
                // sets the new potision of the instrument depending on the value
                instrument.transform.position = new Vector3(value, instrument.transform.position.y, instrument.transform.position.z);
            } else {
                // calls the rotationPanKnob method from Instument script on Instrument Object


                //---->instrument.GetComponent<Instrument>().rotationPanKnob();
            }

            // Sets the value and type of the paramenter
            knobScript.setValue(value, "");

            // calculates the pan value depending on the position of the Instrument game object in x
            float pan = instrument.transform.position.x / 10;
            // finds the audiosource on Instrument Object and manipulaters the pan value
            instrument.GetComponent<AudioSource>().panStereo = pan;



        }
    }
}