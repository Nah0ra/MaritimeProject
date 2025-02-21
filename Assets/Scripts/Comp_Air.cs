using UnityEngine;
using Fusion;

public class Comp_Air : NetworkBehaviour
{
    GameObject Air_Comp1, Air_Comp2, Air_Rec_1, Air_Rec_2, Air_Bef_StartVal, Air_Control, Air_Stop, Air_Bef_Me;

    private Game_Manager gameManager;
    private Power_Plant power_Plant;

    [Networked, SerializeField]
    bool AC1 {get; set;} = false;

    [Networked, SerializeField]
    bool AC2 {get; set;} = false;

    void Awake()
    {
        Init();
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void AC1_On_RPC()
    {
        // If the ship has shore power, enable air compressor 1
        if (power_Plant.ShorePower)
        {
            Air_Comp1.GetComponent<Gauge_Script>().Active = true;
            Air_Comp1.GetComponent<Gauge_Script>().Inc = true;
            Air_Rec_1.GetComponent<Gauge_Script>().Active = true;
            Air_Rec_1.GetComponent<Gauge_Script>().Inc = true;
            AC1 = true;
        }
    } 

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void AC1_Off_RPC()
    {
        // Turn off air compressor 1
        Air_Comp1.GetComponent<Gauge_Script>().Active = true;
        Air_Comp1.GetComponent<Gauge_Script>().Inc = false;
        Air_Rec_1.GetComponent<Gauge_Script>().Active = true;
        Air_Rec_1.GetComponent<Gauge_Script>().Inc = false;
        AC1 = false;
    } 


    [Rpc(RpcSources.All, RpcTargets.All)]
    public void AC2_On_RPC()
    {
        // If the ship has shore power, enable air compressor 1
        if (power_Plant.ShorePower)
        {
            Air_Comp2.GetComponent<Gauge_Script>().Active = true;
            Air_Comp2.GetComponent<Gauge_Script>().Inc = true;
            Air_Rec_2.GetComponent<Gauge_Script>().Active = true;
            Air_Rec_2.GetComponent<Gauge_Script>().Inc = true;
            AC2 = true;
        }
    } 

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void AC2_Off_RPC()
    {
        // Turn off air compressor 1
        Air_Comp2.GetComponent<Gauge_Script>().Active = true;
        Air_Comp2.GetComponent<Gauge_Script>().Inc = false;
        Air_Rec_2.GetComponent<Gauge_Script>().Active = true;
        Air_Rec_2.GetComponent<Gauge_Script>().Inc = false;
        AC2 = false;
    }


    void Init()
    {
        // Get a reference to the game manager
        gameManager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        power_Plant = GameObject.Find("Power_Panel").GetComponent<Power_Plant>();

        //Assign the dials
        Air_Comp1 = GameObject.Find("Air_Comp_1");
        Air_Comp2 = GameObject.Find("Air_Comp_2");
        Air_Rec_1 = GameObject.Find("Air_Rec_1");
        Air_Rec_2 = GameObject.Find("Air_Rec_2");
        Air_Bef_StartVal = GameObject.Find("Air_bef_Start");
        Air_Control = GameObject.Find("Air_Control");
        Air_Stop = GameObject.Find("Air_Stop");
        Air_Bef_Me = GameObject.Find("Air_bef_ME");
    }
}
