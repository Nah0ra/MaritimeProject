using Fusion;
using UnityEngine;

public class Power_Plant : NetworkBehaviour
{
    
    [Networked]
    public bool DieselGen1_On {get; set;} = true;

    [Networked]
    public bool DieselGen2_On {get; set;} = true;

    [Networked]
    public bool DieselGen3_On {get; set;} = true;

    public override void Spawned()
    {
        base.Spawned();
        DieselGen1_On = true;
        DieselGen2_On = true;
        DieselGen3_On = true;
    }
}

