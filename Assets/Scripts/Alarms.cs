using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Alarms : MonoBehaviour
{
    private bool alarm = false;
    private Color color1 = new Color(0.925f, 0.412f, 0.412f); // #EC6969
    private Color color2 = Color.red; // #FF0000
    

    IEnumerator ChangeColor(Image image)
    {
        while (true)
        {
            image = GetComponent<Image>();
            if (alarm)
            {
                image.color = image.color == color1 ? color2 : color1;
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                image.color = color1;
                yield return new WaitForSeconds(0.5f); // Added to ensure the loop does not spin out of control
            }
        }
    }

    public void ToggleAlarm(Image img)
    {
        alarm = !alarm;
        
        StartCoroutine(ChangeColor(img));
    }
}
