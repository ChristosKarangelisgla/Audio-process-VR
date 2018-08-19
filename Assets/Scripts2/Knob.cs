namespace VRTK.Examples
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.Audio;
    using UnityEngine.UI;

    public class Knob : MonoBehaviour
    {
        private ObjectInfo objectInfo;
        private AudioMixerGroup channel;

        // name of the parent name channel
        private string parentChannelName;
        // text in the label canvas
        private Text canvasText;
        // parameter name that will used to change the values of the fader
        private string param;
        // name of the knob object
        private string knobName;
        // the value that will be pass in the parameter
        private float value;
        // the units of the fader value
        private string unit;

        // Use this for initialization
        void Awake()
        {
            // sets the initial rotation of knob
            transform.rotation = Quaternion.Euler(0, 50f, 0);

            // get the Script component object info from parent
            objectInfo = GetComponentInParent<ObjectInfo>();
            // and the name of the parent object
            parentChannelName = objectInfo.getName();
            // gets the audioChannel from the objectInfo of the specific channel object
            channel = objectInfo.getAudioChannel();
            // gets the Text component in canvas in child object
            canvasText = GetComponentInChildren<Text>();


        }

        // Update is called once per frame
        void Update()
        {
            
            if (!param.Contains("DontSet"))
            {
                // sets the parameter and the value in the audiomixer channel
                channel.audioMixer.SetFloat(param, value);
                
            }
            // show on the label in canvas the information regarding the name of the knob the value and units 
            canvasText.text = knobName + "\n" + Mathf.Round(value) + " " + unit;
           
                // limits the rotation of knob
                transform.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.eulerAngles.y, 50f, 300f), 0);
        }


        // Setter of the value and units
        public void setValue(float _value, string _unit)
        {
            this.value = _value;
            this.unit = _unit;
        }

        // setter of the parameter
        public void setParam(string _param)
        {
            this.param = _param + parentChannelName;
        }

        // setter of the fader name
        public void setFaderName(string nameString)
        {
            knobName = nameString;
        }

        // Delegate method for object info
        public ObjectInfo getObjectComps()
        {
            return objectInfo;
        }

        // Getter for value
        public float getValue()
        {
            return value;
        }

    }

}