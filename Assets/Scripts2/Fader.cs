namespace VRTK.Examples
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.Audio;
    using UnityEngine.UI;


    public class Fader : MonoBehaviour
    {
        public GameObject instrument;
        private ObjectInfo objectInfo;
        public AudioMixerGroup channel;

        // name of the parent name channel
        private string parentChannelName;
        // text in the label canvas
        private Text canvasText;
        // parameter name that will used to change the values of the fader
        public string param;
        // name of the fader object
        private string faderName;
        // the value that will be pass in the parameter
        private float value;

        // reference off the controller reactor from the VRTK scripts
        private ControlReactor controlReactor;


        void Awake()
        {
            // gets the Controler reactor script to the reference
            controlReactor = this.GetComponent<ControlReactor>();

            // finds if the parent is tagged with channel
            if (this.transform.parent.parent.tag == "channel")
            {
                // get the Script component object info
                objectInfo = this.transform.parent.parent.GetComponent<ObjectInfo>();
                // and the name of the parent object
                parentChannelName = this.transform.parent.parent.name;
            } 
            else {
                // get the Script component object info
                objectInfo = GetComponentInParent<ObjectInfo>();
                // and the name of the parent object from the objectinfo script
                parentChannelName = objectInfo.getName();
            }


            // gets the audioChannel from the objectInfo of the specific channel object
            channel = objectInfo.getAudioChannel();
            canvasText = GetComponentInChildren<Text>();

            // gets the intrument from the objectInfo of the specific channel object
            instrument = objectInfo.getInstrument();
            

        }



        void Update()
        {
            // sets the range of the value to fit with the fader values
            value = controlReactor.getValue() - 80;
            // sets the parameter and the value in the audiomixer channel
            channel.audioMixer.SetFloat(param, value);
            // show on the label in canvas the information regarding the name of the knob the value and units 
            canvasText.text = faderName + "\n" + Mathf.Round(value) + " dB";

        }


        // setter for the parameter
        public void setParam()
        {
            // if its the same with the parent channel name then parameter takes only the fader name
            if (faderName == parentChannelName)
            {
                param = faderName;
            }
            // if not the object belong to a channel, the parameter takes the name of the fader as well the channel that is a child of
            else
            {
                param = faderName + parentChannelName;
            }

        }


        //setter for the fader name
        public void setFaderName(string nameString)
        {
            faderName = nameString;
        }

        // getter for the objectInfo script
        public ObjectInfo getobjectInfo()
        {
            return objectInfo;
        }

        // getter for name of parent object
        public string getParentName()
        {
            return parentChannelName;
        }

        // getter for the value
        public float getValue()
        {
            return value;
        }

        // getter for the instrument
        public GameObject getInstrument()
        {
            return instrument;
        }

        public ControlReactor getControlReactor()
        {
            return controlReactor;
        }
    }
}
