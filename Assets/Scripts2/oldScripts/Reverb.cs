namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Reverb : MonoBehaviour
    {
        // A reference of the faderScript
        private Fader faderScript;
        // A reference the intrument gameobject
        private GameObject instrument;

        // Use this for initialization
        void Start()
        {
            // connects the reference with the Fader script of that object
            faderScript = this.GetComponent<Fader>();
            // connects the refernce with the instrument that is related with that object
            instrument = faderScript.getInstrument();

            // Sets the name of the fader that will be shown in the fader label
            faderScript.setFaderName("Reverb");
            // Sets the parameter
            faderScript.setParam();

        }

        private void Update()
        {
           // culculates and changes the range value of the Light component in Instrument gameObject
            instrument.GetComponent<Light>().range = ((faderScript.getValue() + 80) / 40) - 0.2f;
        }

    }
}
