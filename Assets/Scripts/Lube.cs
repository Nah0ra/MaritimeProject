using System;
using System.Collections;
using System.Threading;
using Fusion;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Lube : NetworkBehaviour
{
    // Getting references to other scripts
    Game_Manager game_Manager;

    Power_Plant power_Plant; 

    // Sliders
    [SerializeField]
    Slider Me_Lo_Slider, Dg_Lo_Slider;


    // Bools
    bool openTanks = false;

    [Networked]
    bool filledTanks {get; set;} = false;


    //Dials
    [SerializeField]
    GameObject Co_Storage_Tank_Level, Lo_After_Trans_1, Lo_After_Pistons, Lo_Before_Shaft, Lo_Before_ME;
    
    //Librication tanks
    [SerializeField]
    GameObject LubeTanks;

    public override void Spawned()
    {
        base.Spawned();
        Init();
    }




    public void toggleTanks()
    {
        GameObject dials = GameObject.Find("Lube_Dials");
        
        if (openTanks == false)
        {
            LubeTanks.SetActive(true);

            foreach (Transform child in dials.transform)
                child.GetComponent<SimpleGaugeMaker>().Hide = true;

            openTanks = true;
        }
        else if (openTanks == true)
        {
            LubeTanks.SetActive(false);

            foreach (Transform child in dials.transform)
                child.GetComponent<SimpleGaugeMaker>().Hide = false;

            openTanks = false;
        }
        
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void FillTankOnRpc()
    {
        StartCoroutine(FillTanks());
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void DrainTankOnRpc()
    {
        StartCoroutine(DrainTanks());
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void StopTanksRpc()
    {
        StopAllCoroutines();
    }


    public IEnumerator FillTanks()
    {
        while (true)
        {

            if (Me_Lo_Slider.value == Me_Lo_Slider.maxValue && Dg_Lo_Slider.value == Dg_Lo_Slider.maxValue)
            {
                filledTanks = true;
                print(filledTanks);
                break;
            }

            print("Triggered");

            if (Me_Lo_Slider.value != Me_Lo_Slider.maxValue)
            {
                Me_Lo_Slider.value += 0.1f;
            }

            if (Dg_Lo_Slider.value != Dg_Lo_Slider.maxValue)
            {
                Dg_Lo_Slider.value += 0.1f;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator DrainTanks()
    {
        filledTanks = false;

        while (true)
        {

            if (Me_Lo_Slider.value == Me_Lo_Slider.minValue && Dg_Lo_Slider.value == Dg_Lo_Slider.minValue)
            {
                print(filledTanks);
                break;
            }

            print("Triggered");

            if (Me_Lo_Slider.value != Me_Lo_Slider.minValue)
            {
                Me_Lo_Slider.value -= 0.1f;
            }

            if (Dg_Lo_Slider.value != Dg_Lo_Slider.minValue)
            {
                Dg_Lo_Slider.value -= 0.1f;
            }
            yield return new WaitForSeconds(1f);
        }
    }



    void Init()
    {
        game_Manager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        power_Plant = GameObject.Find("Power_Panel").GetComponent<Power_Plant>();

        LubeTanks.SetActive(false);
    }
}
