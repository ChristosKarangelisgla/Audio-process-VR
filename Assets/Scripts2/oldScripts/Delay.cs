namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Delay : MonoBehaviour
    {
        // A reference of the fader script
        public Fader faderScript;
        // A reference of the of the intrument object
        public GameObject instrument;

        // Use this for initialization
        void Start()
        {
            // connects the reference with the fader script of that object
            faderScript = this.GetComponent<Fader>();
            // connects the refernce with the instrument that is related with that object
            instrument = faderScript.getInstrument();

            // Sets the name of the knob that will be shown in the knob label
            faderScript.setFaderName("Delay");
            // Sets param to empty
            faderScript.setParam();

        }

        private void Update()
        {
            // Calculates and changes the emission rate on the particle systems component that exists in the Intrment gameobject
            instrument.GetComponent<ParticleSystem>().emissionRate = ((faderScript.getValue() + 80) / 2) - 4;
        }

    }
}
