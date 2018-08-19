namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Audio;

    public class MuteColorObj : MonoBehaviour
    {
        // A reference of the audiosource
        public AudioSource audiosource;
        // list of Materials
        public Material[] material;
        // referenfence to Renderer
        private Renderer rend;
        // Use this for initialization
        void Start()
        {
            // Finds audiosource component in parent object
            audiosource = gameObject.GetComponentInParent(typeof(AudioSource)) as AudioSource;
            // connects Renderer compnonet to rend reference
            rend = this.GetComponent<Renderer>();
            
            rend.enabled = true;
            // sets the material to the first material of the list
            rend.sharedMaterial = material[0];
        }

        // Update is called once per frame
        void Update()
        {
            //if the audiosource is not muted keeps material (color) to defauld
            if (audiosource.mute == false)
            {
                rend.sharedMaterial = material[0];
            }
            //else changes the color
            else if (audiosource.mute == true)
            {
                rend.sharedMaterial = material[1];
            }
        }
    }
}