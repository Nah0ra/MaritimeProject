using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PowerPlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager _gameManager;
    private LubricationScript _lubricationScript;
    private bool shoreOn;
    public Button Dg1;
    public Button Dg2;
    public Button Dg3;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _lubricationScript=GameObject.Find("LubricationManager").GetComponent<LubricationScript>();
        Dg1.interactable = false;
        Dg2.interactable = false;
        Dg3.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_lubricationScript.gaugeFullMe && _lubricationScript.gaugeFullDg && _gameManager.shore)
        {
            Dg1.interactable = true;
            Dg2.interactable = true;
            Dg3.interactable = true;
        }
    }
    public void changeColour(string buttonName)
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
}
