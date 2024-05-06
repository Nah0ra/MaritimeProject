using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public GaugeScript TestDial;
    public bool TestTheDial;
    


    private void Awake() 
    {
        StartCoroutine(CheckStatus());
    }

    public IEnumerator CheckStatus()
    {
        while (GameManager.Instance.ShorePower == false)
        {
            yield return new WaitForSeconds(1f);
        }
        
        Debug.Log("MAIN SCRIPT REPORTS SHORE POWER UP");
    }

}
