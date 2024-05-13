using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alarms : MonoBehaviour
{
    [SerializeField]
    public Image image; 

    private bool alarm = false;
    private Color color1 = new Color(0.925f, 0.412f, 0.412f); // #EC6969
    private Color color2 = Color.red; // #FF0000

    void Start()
    {
        // Ensure the image component is correctly assigned
        if (image == null)
        {
            image = GetComponent<Image>();
            if (image == null)
            {
                Debug.LogError("Error: No Image component found on the GameObject.");
                return;
            }
        }

        alarm = true;

        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
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
        //StartCoroutine(ChangeColor(Image img));
    }
}
