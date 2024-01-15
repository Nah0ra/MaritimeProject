using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GaugeScript : MonoBehaviour
{

    private SimpleGaugeMaker _simplegaugemaker;
    private float _MaxValue;
    private float _MinValue;
    public bool Forward;
    public float Value;
    public bool Active;

    [Tooltip("Input rate of change in seconds, i.e the time it takes for the liquid to heat by one degree")]
    public float RateOfChange;

    private void Start()
    {
        _simplegaugemaker = gameObject.GetComponent<SimpleGaugeMaker>();
        _MaxValue = _simplegaugemaker.gaugeInputs[0].minMaxValue.y;
        _MinValue = _simplegaugemaker.gaugeInputs[0].minMaxValue.x;
        StartCoroutine(GaugeManager(RateOfChange, _MinValue, _MaxValue));
    }


    IEnumerator GaugeManager(float Rate, float Min, float Max)
    {
        while (true)
        {
                //While the dial is increasing its value, increase the value
                while (Forward)
                {
                    float count = _simplegaugemaker.gaugeInputs[0].value;
                    while (count < Max + 1)
                    {
                        if (!Forward || !Active)
                        {
                            break;
                        }
                        else
                        {
                            Value = count;
                            _simplegaugemaker.setInputValue("Fuel Pressure", count);
                            count++;
                            yield return new WaitForSeconds(Rate);

                        }

                    }
                 yield return new WaitForEndOfFrame();
                }

                while (!Forward)
                {
                    float count = _simplegaugemaker.gaugeInputs[0].value;
                    while (count > Min - 1)
                    {
                        if (Forward || !Active)
                        {
                            break;
                        }
                        else
                        {
                            Value = count;
                            _simplegaugemaker.setInputValue("Fuel Pressure", count);
                            count--;
                            yield return new WaitForSeconds(Rate);
                        }
                    }
                yield return new WaitForEndOfFrame();
            }
          yield return new WaitForEndOfFrame();
        }  
    }

    //Toggles the dial function on or off
    public void ToggleOn()
    {
        if (Active)
        {
            Active = false;
        }
        else
        {
            Active = true;
        }
    }

    //Changes the direction of the dial
    public void ToggleDirection()
    {
        if (Forward)
        {
            Forward = false;
        }
        else
        {
            Forward = true;
        }
    }
}
