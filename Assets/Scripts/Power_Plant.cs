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
    [Networked]
    public bool DieselGen1_On {get; set;} = true;

    [Networked]
    public bool DieselGen2_On {get; set;} = true;

    [Networked]
    public bool DieselGen3_On {get; set;} = true;

    [Networked]
    public bool Generator {get; set;} = false;

    [Networked]
    public bool Reset {get; set;} = false;

    public override void Spawned()
    {
        base.Spawned();
        game_Manager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        DieselGen1_On = true;
        DieselGen2_On = true;
        DieselGen3_On = true;
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void toggleShorePowerRpc()
    {
        print("Test");
        print(game_Manager);

        if (game_Manager.ShorePower == false)
        {
            game_Manager.ShorePower = true;
        }
        else
        {
            game_Manager.ShorePower = false;
        }
    }

}

