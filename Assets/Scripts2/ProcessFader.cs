namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ProcessFader : MonoBehaviour
    {
        // A reference of the fader script
        private Fader faderScript;
        // A reference of the of the intrument object
        private GameObject instrument;

        private Canvas canvas;

        [SerializeField]
        private string process;

        // Use this for initialization
        void Start()
        {
            // connects the reference with the fader script of that object
            faderScript = this.GetComponent<Fader>();
            // connects the refernce with the instrument that is related with that object
            instrument = faderScript.getInstrument();

            // Sets the name of the knob that will be shown in the knob label
            faderScript.setFaderName(process);
            // Sets param to empty
            faderScript.setParam();


            if (process == "Volume")
            {
                // gets the canvas component in children gameobject
                canvas = GetComponentInChildren<Canvas>();

                // sets the fader gameobject in Instrument script
                //instrument.GetComponent<Instrument>().setFader(this.gameObject);
            }
        }

        private void Update()
        {
            if (process == "Delay")
            {
                // sets the emission Rate from Particle System component of the instrument
                instrument.GetComponent<ParticleSystem>().emissionRate = ((faderScript.getValue() + 80) / 2) - 4;
            }

            if (process == "Reverb")
            {
                // sets the range from Light component of the instrumentv
                instrument.GetComponent<Light>().range = ((faderScript.getValue() + 80) / 40) - 0.2f;
            }

            if (process == "Volume")
            {
                if (canvas.enabled == false)
                {
                    // calls method that changes the position of the fader
                    positionVolumeFader();
                    //instrument.GetComponent<Instrument>().positionVolumeFader();

                }
                else
                {
                    // calculates the position of the instrument relative to the value form faderScript
                    float temp = (faderScript.getValue() * -0.2f) + 4;

                    // Changes the position of the instrument in z axis
                    instrument.transform.position = new Vector3(instrument.transform.position.x, instrument.transform.position.y, temp);

                }
            }
            
        }

        // Method that changes the volume position fader
        public void positionVolumeFader()
        {
            // calculates the vol value from the position of the instrument gameobject in z axis
            float vol = (instrument.transform.position.z / 77.5f) - 0.129f;

            // changes the position of the fader in vol value
            this.transform.localPosition = new Vector3(-vol, this.transform.localPosition.y, this.transform.localPosition.z);



        }

    }
}