namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DelayMaster : MonoBehaviour
    {
        // Reference of the faderScript
        private Fader faderScript;
        [SerializeField]
        
     
        // Use this for initialization
        void Start()
        {
            // connects the reference with the fader script of that object
            faderScript = this.GetComponent<Fader>();
            // Sets the name of the knob that will be shown in the knob label
            faderScript.setFaderName("Delay Master");
            // Sets the param in fader Script
            faderScript.setParam();
        }
    }
}