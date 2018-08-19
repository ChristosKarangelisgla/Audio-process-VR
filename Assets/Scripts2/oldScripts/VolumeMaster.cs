namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class VolumeMaster : MonoBehaviour
    {
        // A reference of the faderScript
        private Fader faderScript;
        
        // Use this for initialization
        void Start()
        {
            // connects the reference with the fader script of that object
            faderScript = this.GetComponent<Fader>();
            // Sets the name of the fader that will be shown in the knob label
            faderScript.setFaderName("Volume Master");
            //sets param to empty
            faderScript.setParam();
        }
    }
}
