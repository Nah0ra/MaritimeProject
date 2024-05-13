using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LubricationScript : MonoBehaviour
{
    private GameManager _gameManager;
    private bool shoreOn;
    [SerializeField]
    private GameObject MeLo;
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

    public void onLubIntakeButtonPressOn()
    {
        if (shoreOn)
        {
            Debug.Log("Lub Tank ON");
            
        }
    }
}
