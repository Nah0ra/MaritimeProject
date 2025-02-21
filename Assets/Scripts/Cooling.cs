using System.Collections;
using Fusion;
using UnityEngine;

public class Cooling : NetworkBehaviour
{

   Game_Manager game_manager;

   [SerializeField]
   Power_Plant power_plant;

   [Networked]
   public bool Sea_Water_Pump_1 {get; set;} = false;

   [Networked]
   public bool Sea_Water_Pump_2 {get; set;} = false;

   [Networked]
   public bool Sea_Water_Fill {get; set;} = false;

   [Networked]
   public bool DG_FW_Pump1 {get; set;} = false;

   [Networked]
   public bool DG_FW_Pump2 {get; set;} = false;

    // Dials
   GameObject Sea_Water_After_Me, Sea_Water_Before_Me, Sea_Water_Before_Me_2, DG_FW_Bef_Clr, FW_Bef_Clr, FW_Bef_Clr_2;

   void Awake()
   {
        // Assign game manager and a reference to the power plant script.
        game_manager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        power_plant = GameObject.Find("Power_Panel").GetComponent<Power_Plant>();
        Init();
   }

   [Rpc(RpcSources.All, RpcTargets.All)]
   public void Sea_Water_RPC()
   {
        // If shore power is on
        if (power_plant.ShorePower)
        {
            // If both sea water pumps are on
            if(Sea_Water_Pump_1 && Sea_Water_Pump_2)
            {   
                // Enable all three dials and set Sea_Water_On to true to show that seawater is being filled
                Sea_Water_After_Me.GetComponent<Gauge_Script>().Active = true;
                Sea_Water_After_Me.GetComponent<Gauge_Script>().Inc = true;

                Sea_Water_Before_Me.GetComponent<Gauge_Script>().Active = true;
                Sea_Water_Before_Me.GetComponent<Gauge_Script>().Inc = true;

                Sea_Water_Before_Me_2.GetComponent<Gauge_Script>().Active = true;
                Sea_Water_Before_Me_2.GetComponent<Gauge_Script>().Inc = true;

                Sea_Water_Fill = true;
            }
            else
            {
                // Disable all three dials and set Sea_Water_On to true to show that seawater is being filled
                Sea_Water_After_Me.GetComponent<Gauge_Script>().Active = true;
                Sea_Water_After_Me.GetComponent<Gauge_Script>().Inc = false;

                Sea_Water_Before_Me.GetComponent<Gauge_Script>().Active = true;
                Sea_Water_Before_Me.GetComponent<Gauge_Script>().Inc = false;

                Sea_Water_Before_Me_2.GetComponent<Gauge_Script>().Active = true;
                Sea_Water_Before_Me_2.GetComponent<Gauge_Script>().Inc = false;

                Sea_Water_Fill = false;
            }
        }

        if (power_plant.DieselGen1_On && power_plant.DieselGen2_On && power_plant.DieselGen3_On)
        {
            if (DG_FW_Pump1 && DG_FW_Pump2)
            {
                // Enable Diesel Generator Fresh Water Pumps
                DG_FW_Bef_Clr.GetComponent<Gauge_Script>().Active = true;
                DG_FW_Bef_Clr.GetComponent<Gauge_Script>().Inc = true;

                FW_Bef_Clr.GetComponent<Gauge_Script>().Active = true;
                FW_Bef_Clr.GetComponent<Gauge_Script>().Inc = true;

                FW_Bef_Clr_2.GetComponent<Gauge_Script>().Active = true;
                FW_Bef_Clr_2.GetComponent<Gauge_Script>().Inc = true;
            }
            else
            {
                // Disable Diesel Generator Fresh Water Pumps
                DG_FW_Bef_Clr.GetComponent<Gauge_Script>().Active = true;
                DG_FW_Bef_Clr.GetComponent<Gauge_Script>().Inc = false;

                FW_Bef_Clr.GetComponent<Gauge_Script>().Active = true;
                FW_Bef_Clr.GetComponent<Gauge_Script>().Inc = false;

                FW_Bef_Clr_2.GetComponent<Gauge_Script>().Active = true;
                FW_Bef_Clr_2.GetComponent<Gauge_Script>().Inc = false;
            }
        }
   }
 
   [Rpc(RpcSources.All, RpcTargets.All)]
   public void Pump_On_RPC(string pump)
   {
        // Switch case with the pump name to turn on respective pump
        switch (pump)
        {
            case "SW_1":
                Sea_Water_Pump_1 = true;
                break;

            case "SW_2":
                Sea_Water_Pump_2 = true;
                break;

            case "DG_1":
                DG_FW_Pump1 = true;
                break;

            case "DG_2":
                DG_FW_Pump2 = true;
                break;
        }
   }

   [Rpc(RpcSources.All, RpcTargets.All)]
   public void Pump_Off_RPC(string pump)
   {
        // Switch case with pump name to switch respective pump off
        switch (pump)
        {
            case "SW_1":
                Sea_Water_Pump_1 = false;
                break;

            case "SW_2":
                Sea_Water_Pump_2 = false;
                break;

            case "DG_1":
                DG_FW_Pump1 = false;
                break;

            case "DG_2":
                DG_FW_Pump2 = false;
                break;
        }
   }

   IEnumerator CheckPumps()
   {
        while (true)
        {
            Sea_Water_RPC();
            yield return new WaitForSeconds(1f);
        }
   }

    public override void Spawned()
    {
        base.Spawned();
        StartCoroutine(CheckPumps());
    }

    void Init()
   {
     Sea_Water_After_Me = GameObject.Find("SW_Aft_ME");
     Sea_Water_Before_Me = GameObject.Find("SW_Bef_ME");
     Sea_Water_Before_Me_2 = GameObject.Find("SW_Bef_ME2");
     DG_FW_Bef_Clr = GameObject.Find("DG_FW_Bef_Clr");
     FW_Bef_Clr = GameObject.Find("FW_Bef_Clr");
     FW_Bef_Clr_2 = GameObject.Find("FW_Bef_Clr2");

   }
}
