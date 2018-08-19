namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEventHelper;

    public class MuteMaster : MonoBehaviour
    {
        // array of Mute scripts in channels
        public Mute[] muteCh;

        // array of materials
        public Material[] material;
        private Renderer rend;
        // boolean that check if a channel is muted
        private bool isMuted;

        // reference of the button events from the VRTK scripts
        private VRTK_Button_UnityEvents buttonEvents;

        // Use this for initialization
        void Start()
        {
            // sets the references of the script
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();

            // checks if button events exist
            if (buttonEvents == null)
            {
                // adds the component to the game object
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }
            // adds listener that checks if button is pushed
            buttonEvents.OnPushed.AddListener(handlePush);

            // sets Renderer component and material
            rend = this.GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = material[0];
            isMuted = true;
        }

        // method that is called when a button is pushed
        private void handlePush(object sender, Control3DEventArgs e)
        {
            // set mute on or off for all channels
            for(int i = 0; i < 5; i++) { 
                muteCh[i].MuteChannel(true, isMuted);
            }

            // changes the material on all mute buttons in channels
            if (isMuted == true)
            {
                rend.sharedMaterial = material[1];
            }
            else
            {
                rend.sharedMaterial = material[0];
            }

            // changes boolean to its opposite
            isMuted = !isMuted;
            
        }

    }
}



