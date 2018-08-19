namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEventHelper;

    public class PlayButton : MonoBehaviour
    {
        // array of materials
        public Material[] material;
        private Renderer rend;
        // array of audiosources
        public AudioSource[] audioSource;

        // boolean that indicates in music is playing or is paused
        private bool playing;
        
        // reference of the button events from the VRTK scripts
        private VRTK_Button_UnityEvents buttonEvents;

        // Use this for initialization
        void Start()
        {
            // sets the references of the script
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();

            playing = false;

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
        }

        // method that is called when a button is pushed
        private void handlePush(object sender, Control3DEventArgs e)
        {
            // if music is not playing, starts all audioSources and changes the green material
            if (playing == false)
            {
                for (int i = 0; i < audioSource.Length; i++)
                {
                    if (audioSource[i] != null)
                    {
                        audioSource[i].Play();
                    }
                }
                playing = true;
                rend.sharedMaterial = material[1];
            }
            // else pause all the audioSources and change the orange material
            else
            {
                for (int i = 0; i < audioSource.Length; i++)
                {

                    audioSource[i].Pause();

                }
                playing = false;
                rend.sharedMaterial = material[0];
            }

        }


    }
}