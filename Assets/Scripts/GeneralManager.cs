using System.Collections;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public GaugeScript TestDial;
    public bool TestTheDial;

    private GameManager gameManager;

    private void Awake() 
    {
        gameManager = transform.parent.transform.GetComponent<GameManager>();
        StartCoroutine(CheckStatus()); 
    }

    public IEnumerator CheckStatus()
    {
        while (gameManager.shore == false)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("MASTER WAITING FOR SHORE");
        }
        
        Debug.Log("MAIN SCRIPT REPORTS SHORE POWER UP");
    }

}
