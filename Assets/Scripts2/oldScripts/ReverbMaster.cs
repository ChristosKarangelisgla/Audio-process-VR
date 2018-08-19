namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ReverbMaster : MonoBehaviour
    {
        // A reference of the fader script
        private Fader faderScript;

        // Use this for initialization
        void Start()
        {
            // connects the refernce with the Fader script of that object
            faderScript = this.GetComponent<Fader>();
            // Sets the name of the knob that will be shown in the knob label
            faderScript.setFaderName("Reverb Master");
            // Sets the parameter
            faderScript.setParam();
        }
    }
}
