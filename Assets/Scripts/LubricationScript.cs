using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LubricationScript : MonoBehaviour
{
    private GameManager _gameManager;
    private bool shoreOn;
    [SerializeField]
    private Button LoHeater;
    public Slider MeLoSlider;
    public Slider DgLoSlider;
    bool DgLoSliderOn;
    private bool check;
    private bool LoHeaterCheck;
    public bool gaugeFullMe;
    public bool gaugeFullDg;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.shore)
        {
            shoreOn = true;
        }
    }

    public void changeColour()
    {
        if(shoreOn) 
        {
            LoHeater.GetComponent<Image>().color = Color.green;
            LoHeaterCheck = true;
        }
    }
    public void MeLoIntakeButtonPressOn()
    {
        if (shoreOn)
        {
            check = true;
            Debug.Log("Lub Tank ON");
            StopCoroutine(MeLoTankOff());
            StartCoroutine(MeLoTankOn());
            DgLoSliderOn = true;
        }
    }

    public void MeLoIntakeButtonPressOff()
    {
        if (shoreOn)
        {
            check = false;
            Debug.Log("Lub Tank OFF");
            StopCoroutine(MeLoTankOn());
            StartCoroutine(MeLoTankOff());
            DgLoSliderOn = false;
        }
    }

    public void DgLoButtonPressOn()
    {
        if (shoreOn)
        {
            check = true;
            Debug.Log("DgLo Tank ON");
            StopCoroutine(DgLoTankOff());
            StartCoroutine(DgLoTankOn());
            DgLoSliderOn=true;
        }
    }

    public void DgLoButtonPressOff()
    {
        if (shoreOn)
        {
            check= false;
            Debug.Log("Lub Tank OFF");
            StopCoroutine(DgLoTankOn());
            StartCoroutine(DgLoTankOff());
            DgLoSliderOn=false;
        }
    }

    public IEnumerator MeLoTankOn()
    {
        while (check)
        {
            MeLoSlider.value+=0.1f;
            yield return new WaitForSeconds(1f);
            if(MeLoSlider.value == MeLoSlider.maxValue)
            {
                check = false;
                gaugeFullMe = true;
            }
        }
    }    
    public IEnumerator DgLoTankOn()
    {
        while (check)
        {
            DgLoSlider.value+=0.1f;
            yield return new WaitForSeconds(1f);
            if (DgLoSlider.value == DgLoSlider.maxValue)
            {
                check = false;
                gaugeFullDg = true;
            }
        }
    }    
    public IEnumerator MeLoTankOff()
    {
        while (check == false)
        {
            MeLoSlider.value -= 0.1f;
            yield return new WaitForSeconds(1f);
            if (MeLoSlider.value == MeLoSlider.minValue)
            {
                check = true;
                gaugeFullMe = false;
            }
        }
    }    
    public IEnumerator DgLoTankOff()
    {
        while (check == false)
        {
            DgLoSlider.value -= 0.1f;
            yield return new WaitForSeconds(1f);
            if (DgLoSlider.value == DgLoSlider.minValue)
            {
                check = true;
                gaugeFullDg = false;
            }
        }
    }
}
