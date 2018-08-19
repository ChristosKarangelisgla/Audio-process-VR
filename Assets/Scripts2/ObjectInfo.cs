namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;

    // this script will be used so all scripts in every channel can take the common information needed
    public class ObjectInfo : MonoBehaviour
    {

        public GameObject instrument;
        public AudioMixerGroup audioChannel;


        // Getter for intrument gameObject
        public GameObject getInstrument()
        {
            return instrument;
        }

        // Getter for audiochannel component
        public AudioMixerGroup getAudioChannel()
        {
            return audioChannel;
        }

        // Getter for the name of the parent channel object
        public string getName()
        {
            return this.name;
        }
    }
}