using ExitGames.Client.Photon.StructWrapping;
using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class Power_Plant : NetworkBehaviour
{
    Game_Manager game_Manager;

    Lube lube;
    
    Cooling cooling;
    
    Comp_Air comp_Air;

    // Buttons
    Button Dg1, DG2, Dg3;

    //Bools
    public bool DieselGen1_On = false;

    public bool DieselGen2_On = false;

    public bool DieselGen3_On = false;


    public bool Generator = false ;

    public bool Reset = false;

   

    
    public bool ShorePower = false;

    public override void Spawned()
    {
        base.Spawned();
        game_Manager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
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

    

}

