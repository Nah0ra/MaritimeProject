using Fusion;
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
        DieselGen1_On = true;
        DieselGen2_On = true;
        DieselGen3_On = true;
    }
}

