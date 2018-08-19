namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;
    using UnityEngine.UI;
    using System;

    public class AudioTime : MonoBehaviour
    {

        public AudioSource[] audiosource;
        // reference of the pointer
        public GameObject point;

        // reference of the button
        public string buttonName;

        // text that will show in the label
        public Text timerText;
        // reference of the button events from the VRTK scripts
        private VRTK_Button_UnityEvents buttonEvents;

        private void Start()
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

        }

        private void handlePush(object sender, Control3DEventArgs e)
        {
            // calls right method depending which button has pressed
            if (buttonName == "backward")
            {
                backwardMusic();
            }
            else if (buttonName == "forward")
            {
                forwardMusic();
            }
            
        }

        public void forwardMusic()
        {
            // loops to the audiosource array and adds 5 seconds to every audiosource
            if (audiosource[0].time + 5 < audiosource[0].clip.length)
            {
                for (int i = 0; i < audiosource.Length; i++)
                {
                    audiosource[i].time += 5;
                }
            }
        }

        public void backwardMusic()
        {
            // loops to the audiosource array and removes 5 seconds from every audiosource
            if (audiosource[0].time - 5 > 0)
            {
                for (int i = 0; i < audiosource.Length; i++)
                {
                    audiosource[i].time -= 5;
                }

            }
            else
            {
                // start the song from the begginging it is running less than 5 seconds
                for (int i = 0; i < audiosource.Length; i++)
                {
                    audiosource[i].time = 0;
                }
            }
        }

        void Update()
        {
            // Sets the text to the lable
            timerText.text = "Time\n"+ Math.Round(audiosource[0].time, 2).ToString() + " sec";
            // Updates the position of the pointer
            point.transform.localPosition = new Vector3(((audiosource[0].time / audiosource[0].clip.length) * 10) - 0.15f, transform.localPosition.y, transform.localPosition.z);

        }
    }
  }