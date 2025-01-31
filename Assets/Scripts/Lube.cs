using System.Collections;
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

    // Setting bools
    [Networked]
    bool check {get; set;} = false;

    [Networked]
    bool Lo_Heater_Check {get; set;} = false;

    [Networked]
    bool gauge_Full_Me {get; set;} = false;

    [Networked]
    bool gauge_Full_Dg {get; set;} = false;

    [Networked]
    bool MeLo_Pump_1B {get; set;} = false;

    [Networked]
    bool TurbochargerB {get; set;} = false;

    [SerializeField]
    GameObject LO, ME_lo_Pump_1, Turbocharger;

    public override void Spawned()
    {
        base.Spawned();
        Init();
        StartCoroutine(CheckPump());
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void Me_Lo_Intake_On_RPC()
    {
        if (game_Manager.ShorePower)
        {
            check = true;
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void Me_Lo_Intake_Off_RPC()
    {
        if (game_Manager.ShorePower)
        {
            check = true;
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void Dg_Lo_Intake_On_RPC()
    {
        if (game_Manager.ShorePower)
        {
            check = true;
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void Dg_Lo_Intake_Off_RPC()
    {
        if (game_Manager.ShorePower)
        {
            check = true;
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void Turbo_On_RPC()
    {
        TurbochargerB = true;
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void Turbo_Off_RPC()
    {
        TurbochargerB = false;
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void ME_Lo_Pump_On_RPC()
    {
        MeLo_Pump_1B = true;
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void ME_Lo_Pump_Off_RPC()
    {
        MeLo_Pump_1B = false;
    }

    IEnumerator CheckPump()
    {
        while (true)
        {
            // Check if the diesel generators in the power plant are on
            if (power_Plant.DieselGen1_On && power_Plant.DieselGen2_On && power_Plant.DieselGen3_On)
            {
                // If Me_Le_Pump_1B and Turbocharger are switched on, enable dials
                if (MeLo_Pump_1B && TurbochargerB)
                {
                    ME_lo_Pump_1.GetComponent<Gauge_Script>().Active = true;
                    ME_lo_Pump_1.GetComponent<Gauge_Script>().Inc = true;
                    Turbocharger.GetComponent<Gauge_Script>().Active = true;
                    Turbocharger.GetComponent<Gauge_Script>().Inc = true;
                }
                else
                {
                    ME_lo_Pump_1.GetComponent<Gauge_Script>().Active = true;
                    ME_lo_Pump_1.GetComponent<Gauge_Script>().Inc = false;
                    Turbocharger.GetComponent<Gauge_Script>().Active = true;
                    Turbocharger.GetComponent<Gauge_Script>().Inc = false;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void Init()
    {
        game_Manager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        power_Plant = GameObject.Find("Power_Panel").GetComponent<Power_Plant>();
    }
}
