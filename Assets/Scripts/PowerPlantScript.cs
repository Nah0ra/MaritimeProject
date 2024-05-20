using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PowerPlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager _gameManager;
    private LubricationScript _lubricationScript;
    private CoolingScript _coolingScript;
    private CompressedAirScript _compressedAirScript;
    private bool shoreOn;
    public Button Dg1;
    public Button Dg2;
    public Button Dg3;

    public bool generator;
    public bool DG1;
    public bool DG2;
    public bool DG3;
    public bool Reset;
    
    [SerializeField] private GameObject DG1_Dial;
    [SerializeField] private GameObject DG2_Dial;
    [SerializeField] private GameObject DG3_Dial;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _lubricationScript=GameObject.Find("LubricationManager").GetComponent<LubricationScript>();
        _coolingScript= GameObject.Find("CoolingManager").GetComponent<CoolingScript>();
        _compressedAirScript = GameObject.Find("CompressedAirManager").GetComponent<CompressedAirScript>();
        Dg1.interactable = false;
        Dg2.interactable = false;
        Dg3.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((_lubricationScript.gaugeFullMe && _lubricationScript.gaugeFullDg && _gameManager.shore && _lubricationScript.LoHeaterCheck && _coolingScript.SWpumpOn && _compressedAirScript.AC1 && _compressedAirScript.AC2))
        {
            Dg1.interactable = true;
            Dg2.interactable = true;
            Dg3.interactable = true;

            generator = true;
            //Debug.Log("Power On");
        }
        else if((!_lubricationScript.gaugeFullMe || !_lubricationScript.gaugeFullDg || !_gameManager.shore || !_lubricationScript.LoHeaterCheck || !_coolingScript.SWpumpOn || !_compressedAirScript.AC1 || !_compressedAirScript.AC2))
        {
            Dg1.interactable = false;
            Dg2.interactable = false;
            Dg3.interactable = false;
            
            generator = false;
            changeColourRed();
        }

        if (!generator)
        {
            DG1 = false;
            DG1_Dial.GetComponent<GaugeScript>().Active = true;
            DG1_Dial.GetComponent<GaugeScript>().Forward = false;
            DG1_Dial.GetComponent<GaugeScript>().Value = 0;

            DG2 = false;
            DG2_Dial.GetComponent<GaugeScript>().Active = true;
            DG2_Dial.GetComponent<GaugeScript>().Forward = false;
            DG2_Dial.GetComponent<GaugeScript>().Value = 0;

            DG3 = false;
            DG3_Dial.GetComponent<GaugeScript>().Active = true;
            DG3_Dial.GetComponent<GaugeScript>().Forward = false;
            DG3_Dial.GetComponent<GaugeScript>().Value = 0;
        }

        if (!generator && !DG1 && !DG2 && !DG3 && !_gameManager.shore)
        {
            //Lubrication
            _lubricationScript.LO.GetComponent<GaugeScript>().Forward = false;
            _lubricationScript.LoHeater.GetComponent<Image>().color = Color.red;
            _lubricationScript.check = false;

            _lubricationScript.MeLoIntakeButtonPressOff();
            _lubricationScript.DgLoButtonPressOff();


            //Cooling
            _coolingScript.SWpump1Off();
            _coolingScript.SWpump2Off();


            //Compressed Air
            _compressedAirScript.onAir2ButtonPressOff();
            _compressedAirScript.onAir1ButtonPressOff();

            //GameManager
            _gameManager.ShorePower.SetActive(true);
        }

        if(!_gameManager.shore) 
        {
            _gameManager.shore = false;
            _gameManager.ShoreButton.GetComponent<Image>().color = Color.red;
            Debug.Log("Shore off");
        }
    }
    public void changeColourGreen(string buttonName)
    {
        switch (buttonName)
        {
            case "Button1":
                Dg1.GetComponent<Image>().color = Color.green;
                break;

            case "Button2":
                Dg2.GetComponent<Image>().color = Color.green;
                break;

            case "Button3":      
                Dg3.GetComponent<Image>().color = Color.green;
                break;
        }
    }

    public void changeColourRed()
    {
       Dg1.GetComponent<Image>().color = Color.red;
       Dg2.GetComponent<Image>().color = Color.red;
       Dg3.GetComponent<Image>().color = Color.red;     
    }
    
    public void onDG1BTNOn()
    {
        if (generator)
        {
            DG1 = true;
            DG1_Dial.GetComponent<GaugeScript>().Active = true;
            DG1_Dial.GetComponent<GaugeScript>().Forward = true;
            _gameManager.ShorePower.SetActive(false);

        }
    }
    
    public void onDG1BTNOff()
    {
        if (generator)
        {
            DG1 = false;
            DG1_Dial.GetComponent<GaugeScript>().Active = true;
            DG1_Dial.GetComponent<GaugeScript>().Forward = false;
            DG1_Dial.GetComponent<GaugeScript>().Value = 0;
            _gameManager.shore = false;
        }
    }
    
    public void onDG2BTNOn()
    {
        if (generator)
        {
            DG2 = true;
            DG2_Dial.GetComponent<GaugeScript>().Active = true;
            DG2_Dial.GetComponent<GaugeScript>().Forward = true;
            _gameManager.ShorePower.SetActive(false);
        }
    }
    
    public void onDG2BTNOff()
    {
        if (generator)
        {
            DG2 = false;
            DG2_Dial.GetComponent<GaugeScript>().Active = true;
            DG2_Dial.GetComponent<GaugeScript>().Forward = false;
            DG2_Dial.GetComponent<GaugeScript>().Value = 0;
            _gameManager.shore = false;
        }
    }
    
    public void onDG3BTNOn()
    {
        if (generator)
        {
            DG3 = true;
            DG3_Dial.GetComponent<GaugeScript>().Active = true;
            DG3_Dial.GetComponent<GaugeScript>().Forward = true;
            _gameManager.ShorePower.SetActive(false);
        }
    }
    
    public void onDG3BTNOff()
    {
        if (generator)
        {
            DG3 = false;
            DG3_Dial.GetComponent<GaugeScript>().Active = true;
            DG3_Dial.GetComponent<GaugeScript>().Forward = false;
            DG3_Dial.GetComponent<GaugeScript>().Value = 0;
            _gameManager.shore = false;
        }
    }
}
