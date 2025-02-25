using ExitGames.Client.Photon.StructWrapping;
using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class Power_Plant : NetworkBehaviour
{
    Lube _lube;

    Cooling cooling;
    
    Comp_Air comp_Air;

    // Buttons
    public GameObject Dg1, Dg2, Dg3;

    //Bools
    public bool DieselGen1_On = false;

    public bool DieselGen2_On = false;

    public bool DieselGen3_On = false;

    public bool DG1Lube = false;
    public bool DG2Lube = false;
    public bool DG3Lube = false;

    
    public bool ShorePower = false;

    public override void Spawned()
    {
        base.Spawned();
        _lube = GameObject.Find("Lube_Panel").GetComponent<Lube>();
        comp_Air = GameObject.Find("Comp_Panel").GetComponent<Comp_Air>();
        cooling = GameObject.Find("Cool_Panel").GetComponent<Cooling>();
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void toggleShorePowerRpc()
    {

        Image PowerButton = transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>();

        if (ShorePower == false)
        {
            PowerButton.color = Color.green;
            ShorePower = true;
            print(ShorePower);
        }
        else if (ShorePower == true)
        {
            PowerButton.color = Color.red;
            ShorePower = false;
            print(ShorePower);
        }
    }


    [Rpc(RpcSources.All, RpcTargets.All)]
    public void ToggleGen1LubeRpc()
    {
        Image button = GameObject.Find("Sectioning_Pre_lub_pump").transform.GetChild(2).GetChild(1).GetComponent<Image>();

        if (_lube.filledTanks && ShorePower && !DG1Lube)
        {
            DG1Lube = true;
            button.color = Color.green;
        }
        else if (DG1Lube)
        {
            DG1Lube = false;
            button.color = Color.red;
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void ToggleGen2LubeRpc()
    {
        Image button = GameObject.Find("Sectioning_Pre_lub_pump_2").transform.GetChild(2).GetChild(1).GetComponent<Image>();

        if (_lube.filledTanks && ShorePower && !DG2Lube)
        {
            DG2Lube = true;
            button.color = Color.green;
        }
        else if (DG2Lube)
        {
            DG2Lube = false;
            button.color = Color.red;
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void ToggleGen3LubeRpc()
    {
        Image button = GameObject.Find("Sectioning_Pre_lub_pump_3").transform.GetChild(2).GetChild(1).GetComponent<Image>();

        if (_lube.filledTanks && ShorePower && !DG3Lube)
        {
            DG3Lube = true;
            button.color = Color.green;
        }
        else if (DG3Lube)
        {
            DG3Lube = false;
            button.color = Color.red;
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void Gen1OnRpc()
    {
        if (comp_Air.AC1 && comp_Air.AC2 && DG1Lube && DG2Lube && DG3Lube && cooling.Sea_Water_Pump_1 && cooling.Sea_Water_Pump_2)
        {
            Dg1.GetComponent<Gauge_Script>().Active = true;
            Dg1.GetComponent<Gauge_Script>().Inc = true;
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void Gen1OffRpc()
    {
        Dg1.GetComponent<Gauge_Script>().Active = true;
        Dg1.GetComponent<Gauge_Script>().Inc = false;
    }



}

