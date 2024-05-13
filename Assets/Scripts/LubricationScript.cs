using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LubricationScript : MonoBehaviour
{
    private GameManager _gameManager;
    private bool shoreOn;
    public Slider MeLoSlider;
    public Slider DgLoSlider;
    private bool check;
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

    public void MeLoIntakeButtonPressOn()
    {
        if (shoreOn)
        {
            check = true;
            Debug.Log("Lub Tank ON");
            StopCoroutine(MeLoTankOff());
            StartCoroutine(MeLoTankOn());
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
            }
        }
    }    
    public IEnumerator DgLoTankOn()
    {
        while (check)
        {
            DgLoSlider.value += 0.1f;
            yield return new WaitForSeconds(1f);
            if (DgLoSlider.value == DgLoSlider.maxValue)
            {
                check = false;
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
            }
        }
    }
}
