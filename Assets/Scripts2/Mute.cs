namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEventHelper;

    public class Mute : MonoBehaviour
    {
        // array of Mute scripts in channels
        public Material[] material;
        private Renderer rend;
        [SerializeField]
        private AudioSource audiosource;
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
            audiosource = this.transform.parent.parent.GetComponent<ObjectInfo>().instrument.GetComponent<AudioSource>();
        }

        void Update()
        {
            // changes the material regarding on the mute state
            if (audiosource.mute == false)
            {
                rend.sharedMaterial = material[0];
            }
            else if (audiosource.mute == true)
            {
                rend.sharedMaterial = material[1];
            }
        }

        // method that is called when a button is pushed
        private void handlePush(object sender, Control3DEventArgs e)
        {

            MuteChannel(false, false);


        }

        // mute of unmute a channel
        public void MuteChannel(bool muteAll, bool isMuted)
        {

            if (muteAll == true)
            {
                audiosource.mute = isMuted;
            }
            else
            {
                audiosource.mute = !audiosource.mute;
            }




        }
    }
}