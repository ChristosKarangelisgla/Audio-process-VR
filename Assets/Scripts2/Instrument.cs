namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Instrument : MonoBehaviour
    {

    

        // Use this for initialization
        void Awake()
        {
            //Ignores all collsion with objects that belongs to 9th layer
            Physics.IgnoreLayerCollision(9, 9);
           
        }



        // Update is called once per frame
        void Update()
        {
            
            clampValues();

        }

        // Clamps values and sets limits on Instrument gameobject
        public void clampValues()
        {
            //sets limits on rotation, position and scale
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10), transform.position.y, Mathf.Clamp(transform.position.z, 1f, 20));
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 0.5f, 2f), Mathf.Clamp(transform.localScale.y, 0.5f, 2f), Mathf.Clamp(transform.localScale.z, 0.5f, 2f));

            // sets limits on the light range and emission rate on Light and particle systems components
            this.GetComponent<Light>().range = Mathf.Clamp(this.GetComponent<Light>().range, 0, 5);
            this.GetComponent<ParticleSystem>().emissionRate = Mathf.Clamp(this.GetComponent<ParticleSystem>().emissionRate, 0, 100);

        }
 
    }
}
