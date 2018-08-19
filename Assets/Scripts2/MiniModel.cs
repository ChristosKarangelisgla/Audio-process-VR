using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniModel : MonoBehaviour
{

    public GameObject instrument;

    private Canvas canvas;

    // Use this for initialization
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        this.transform.localPosition = new Vector3(instrument.transform.position.x / 20, this.transform.localPosition.y, instrument.transform.position.z / 20);
    }

    // Update is called once per frame
    void Update()
    {
        clampValues();
        moveModel();
    }

    // Clamps values and sets limits on Instrument gameobject
    public void clampValues()
    {

        transform.eulerAngles = new Vector3(0, 0, 0);
        this.transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -0.5f, 0.5f), Mathf.Clamp(transform.localPosition.y, 0.05f, 0.5f), Mathf.Clamp(transform.localPosition.z, 0.03f, 0.9f));

    }

    public void moveModel()
    {
        
        if (canvas.enabled == false)
        {
            //moves the mini model relative to the position of the Instrument model
            this.transform.localPosition = new Vector3(instrument.transform.position.x / 20, this.transform.localPosition.y, instrument.transform.position.z / 20);

        }
        else
        {
            //moves the Instrument model relative to the position of the mini model
            instrument.transform.position = new Vector3(transform.localPosition.x * 20, instrument.transform.position.y, transform.localPosition.z * 20);

        }
    }

}