using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolingScript : MonoBehaviour
{
    private GameManager _gameManager;

    private bool shoreOn;

    // buttons
    public bool SWpump1;
    public bool SWpump2;
    public bool DGFWpump1;
    public bool DGFWpump2;
    public bool SWpumpOn;
    // gauges

    [SerializeField]
    private GameObject SWafterME;

    [SerializeField]
    private GameObject SWbeforeME1;
    [SerializeField]
    private GameObject SWbeforeME2;

    [SerializeField]
    private GameObject DGFW;

    [SerializeField]
    private GameObject FWbef1;

    [SerializeField]
    private GameObject FWbef2;


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager.shore)
        {
           shoreOn = true;
        }
    }

    // if SWpump1 && SWpump1 == true, then SWafterME, SWbeforeME1, SWbeforeME2 gauges are active and forward
    public void seaWaterOn()
    {    
        if (shoreOn)
        {
            if (SWpump1 == true && SWpump2 == true)
            {
                Debug.Log("Sea Water On");
                SWafterME.GetComponent<GaugeScript>().Active = true;
                SWafterME.GetComponent<GaugeScript>().Forward = true;

                SWbeforeME1.GetComponent<GaugeScript>().Active = true;
                SWbeforeME1.GetComponent<GaugeScript>().Forward = true;

                SWbeforeME2.GetComponent<GaugeScript>().Active = true;
                SWbeforeME2.GetComponent<GaugeScript>().Forward = true;
                SWpumpOn = true;
            }
        }

        if ((SWpump1 == false && SWpump2 == false))
        {

            Debug.Log("Sea Water Off");
            SWafterME.GetComponent<GaugeScript>().Active = true;
            SWafterME.GetComponent<GaugeScript>().Forward = false;

            SWbeforeME1.GetComponent<GaugeScript>().Active = true;
            SWbeforeME1.GetComponent<GaugeScript>().Forward = false;

            SWbeforeME2.GetComponent<GaugeScript>().Active = true;
            SWbeforeME2.GetComponent<GaugeScript>().Forward = false;
            SWpumpOn = false;
        }
    }
     public void SWpump1On()
    {
        SWpump1 = true;
        seaWaterOn();
    }
    public void SWpump2On()
    {
        SWpump2 = true;
        seaWaterOn();
    }

    public void SWpump1Off()
    {
        SWpump1 = false;
        seaWaterOn();
    }
    public void SWpump2Off()
    {
        SWpump2 = false;
        seaWaterOn();
    }

}