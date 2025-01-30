using System.Collections;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;

public class Gauge_Script : NetworkBehaviour
{
    SimpleGaugeMaker gaugemaker;

    [SerializeField]
    float Max_Value, Min_Value, Current_Value;

    [SerializeField, Tooltip("How much the unit should increase by every second")]
    float Rate_Of_Change;

    [Networked]
    public bool Inc {get; set;} = false ;

    [Networked]
    public bool Active {get; set;} = false ;

    public override void Spawned()
    {
        base.Spawned();
        // Assing a reference to the gauge makert and the min, max and current value of the dials
        gaugemaker = gameObject.GetComponent<SimpleGaugeMaker>();
        Current_Value = gaugemaker.gaugeInputs[0].value;
        Min_Value = gaugemaker.gaugeInputs[0].minMaxValue.x;
        Max_Value = gaugemaker.gaugeInputs[0].minMaxValue.y;
        StartCoroutine(Dial());
    }

    private IEnumerator Dial()
    {
        while (true)
        {
            // Activate only if the dial is active
            if (Active)
            {
                if (Inc)
                {
                    // If the dial is set to increment, increment by the rate of change. Clamp the value to ensure it does not exceed Max.
                    // Once max is reached, set active to false
                    Current_Value += Rate_Of_Change;
                    Current_Value = Mathf.Min(Current_Value, Max_Value);
                    gaugemaker.setInputValue("Fuel Pressure", Current_Value);

                    if (Current_Value >= Max_Value)
                    {
                        Active = false;
                    }

                }
                else
                {
                    // If the dial is NOT set to increment, decrement by the rate of change. Clamp the value to ensure it does not exceed Min.
                    // Once min is reached, set active to false
                    Current_Value -= Rate_Of_Change;
                    Current_Value = Mathf.Max(Current_Value, Min_Value);
                    gaugemaker.setInputValue("Fuel Pressure", Current_Value); 

                    if (Current_Value <= Min_Value)
                    {
                        Active = false;
                    }
                }
            }

            // Wait for one second before checking again
            yield return new WaitForSeconds(1f);
        }
    }

}
