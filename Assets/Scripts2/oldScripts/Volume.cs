namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class Volume : MonoBehaviour
    {

        public Fader faderScript;
        public GameObject instrument;
        private Canvas canvas;
        // Use this for initialization


        void Start()
        {

            //set the referemce to the fade script
            faderScript = this.GetComponent<Fader>();
            // set the refernces to the instrument gameobject
            instrument = faderScript.getInstrument();

            // Sets the name of the fader that will be shown in the fader label
            faderScript.setFaderName("Volume");
            // Sets the parameter
            faderScript.setParam();

            // gets the canvas component in children gameobject
            canvas = GetComponentInChildren<Canvas>();

            // sets the fader gameobject in Instrument script
            // ---> instrument.GetComponent<Instrument>().setFader(this.gameObject);
        }

       

        private void Update()
        {

            if (canvas.enabled == false)
            {
                // calls method that changes the position of the fader
                // ---> instrument.GetComponent<Instrument>().positionVolumeFader();

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
}
