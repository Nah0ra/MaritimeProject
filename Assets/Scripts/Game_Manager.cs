using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Fusion;
using System.Linq;

public class Game_Manager : NetworkBehaviour
{

    // Panels
    GameObject MainUI, FuelUI, LubeUI, CompUI, PowerUI, SteamUI, CoolUI, MiscUI;
 
    // Buttons
    Button MainButton, FuelButton, LubeButton, CompButton, PowerButton, SteamButton, CoolButton, MiscButton;

    // Dials
    GameObject MainDials, FuelDials, LubeDials, CompDials, PowerDials, SteamDials, CoolDials;

    //Overlay
    GameObject Overlay;

    // Main Engine Speed dial
    GameObject SpeedDial;

    // This is used to keep track of the number of connected players, across all clients
    [Networked]
    public int PlayerNumber {get; set;} = 0;

    public bool IndicatorCocks = false;
    public bool SlowTurn = false;

    public bool PreLubPump = false;

    Power_Plant power_Plant;

    public void Awake()
    {   
        // Initialising the UI
        InitialiseUI();
        power_Plant = GameObject.Find("Power_Panel").GetComponent<Power_Plant>();
    }

    // This is executed once the level loads
    public override void Spawned()
    {
        base.Spawned();
        CheckForPlayersRPC();
    }


    // This is an RPC call executed on all clients to check if the minimum count of clients has been reached (3)
    [Rpc(RpcSources.All, RpcTargets.All)]
    private void CheckForPlayersRPC()
    {
        PlayerNumber = Runner.ActivePlayers.Count();
        if (PlayerNumber == 2)
        {
            // If player count has been reached, disable the overlay and enable the main UI and dials
            Overlay.SetActive(false);
            MainUI.SetActive(true);
            foreach (Transform child in MainDials.transform)
                child.GetComponent<SimpleGaugeMaker>().Hide = false;

            SpeedDial.GetComponent<SimpleGaugeMaker>().Hide = false;
        }
    }

    void InitialiseUI()
    {

        //Assign the overlay
        Overlay = GameObject.Find("Overlay");

        //Assign the speed dial
        SpeedDial = GameObject.Find("Main Engine Speed");

        // Assign the panels
        MainUI = GameObject.Find("Main_UI");
        FuelUI = GameObject.Find("Fuel_UI");
        LubeUI = GameObject.Find("Lube_UI");
        CompUI = GameObject.Find("Comp_UI");
        PowerUI = GameObject.Find("Power_UI");
        SteamUI = GameObject.Find("Steam_UI");
        CoolUI = GameObject.Find("Cool_UI");
        MiscUI = GameObject.Find("Misc_UI");

        // Assign the main engine speed dial
        SpeedDial = GameObject.Find("Main Engine Speed");

        // Assign the panel buttons
        MainButton = GameObject.Find("Main_Panel_Btn").GetComponent<Button>();
        FuelButton = GameObject.Find("Fuel_Panel_Btn").GetComponent<Button>();
        LubeButton = GameObject.Find("Lube_Panel_Btn").GetComponent<Button>();
        CompButton = GameObject.Find("Comp_Panel_Btn").GetComponent<Button>();
        PowerButton = GameObject.Find("Power_Panel_Btn").GetComponent<Button>();
        SteamButton = GameObject.Find("Steam_Panel_Btn").GetComponent<Button>();
        CoolButton = GameObject.Find("Cool_Panel_Btn").GetComponent<Button>();
        MiscButton = GameObject.Find("Misc_Panel_Btn").GetComponent<Button>();

        //Assign the dials
        MainDials = GameObject.Find("Main_Dials");
        FuelDials = GameObject.Find("Fuel_Dials");
        LubeDials = GameObject.Find("Lube_Dials");
        CompDials = GameObject.Find("Comp_Dials");
        PowerDials = GameObject.Find("Power_Dials");
        SteamDials = GameObject.Find("Steam_Dials");
        CoolDials = GameObject.Find("Cool_Dials");
        
        // Add event listeners to the panel buttons
        MainButton.onClick.AddListener(LoadPanel);
        FuelButton.onClick.AddListener(LoadPanel);
        LubeButton.onClick.AddListener(LoadPanel);
        CompButton.onClick.AddListener(LoadPanel);
        PowerButton.onClick.AddListener(LoadPanel);
        SteamButton.onClick.AddListener(LoadPanel);
        CoolButton.onClick.AddListener(LoadPanel);
        MiscButton.onClick.AddListener(LoadPanel);

        // Hide all UI
        MainUI.SetActive(false);
        FuelUI.SetActive(false);
        LubeUI.SetActive(false);
        CompUI.SetActive(false);
        PowerUI.SetActive(false);
        SteamUI.SetActive(false);
        CoolUI.SetActive(false);
        MiscUI.SetActive(false);

        // Hide all dials at the beginning and enable as needed
        foreach (Transform child in MainDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;
        
        foreach (Transform child in FuelDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;
        
        foreach (Transform child in LubeDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in CompDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;
        
        foreach (Transform child in PowerDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in SteamDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in CoolDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        SpeedDial.GetComponent<SimpleGaugeMaker>().Hide = true;
    }


    [Rpc(RpcSources.All, RpcTargets.All)]
    public void CocksOpenRpc()
    {
        if (power_Plant.Dg1 && power_Plant.Dg2 && power_Plant.Dg3 && !power_Plant.ShorePower)
        {
            IndicatorCocks = true;
        }
    }

     [Rpc(RpcSources.All, RpcTargets.All)]
    public void CocksClosedRpc()
    {
        IndicatorCocks = false;
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void SlowTurnOnRpc()
    {
        if (power_Plant.Dg1 && power_Plant.Dg2 && power_Plant.Dg3 && !power_Plant.ShorePower)
        {
            SlowTurn = true;
        }
    }


    [Rpc(RpcSources.All, RpcTargets.All)]
    public void SlowTurnOffRpc()
    {
        SlowTurn = false;
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void PreLubOnRpc()
    {
        if (power_Plant.Dg1 && power_Plant.Dg2 && power_Plant.Dg3 && !power_Plant.ShorePower)
        {
            PreLubPump = true;
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void PreLubOffRpc()
    {
        PreLubPump = false;
    }




    public void LoadPanel()
    {
        // Store a reference to the name of currently selected panel button
        string SelectedPanel = EventSystem.current.currentSelectedGameObject.gameObject.name;

        //  Disable all panels at the beginning and enable as needed
        MainUI.SetActive(false);
        FuelUI.SetActive(false);
        LubeUI.SetActive(false);
        CompUI.SetActive(false);
        PowerUI.SetActive(false);
        SteamUI.SetActive(false);
        CoolUI.SetActive(false);
        MiscUI.SetActive(false);

        // Hide all dials at the beginning and enable as needed
        foreach (Transform child in MainDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;
        
        foreach (Transform child in FuelDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;
        
        foreach (Transform child in LubeDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in CompDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;
        
        foreach (Transform child in PowerDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in SteamDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

         foreach (Transform child in CoolDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        
        // Switch case for the selected panels and respective dials
        switch (SelectedPanel)
        {
            case "Main_Panel_Btn":
                MainUI.SetActive(true);
                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;
                    Debug.Log(Runner.ActivePlayers.Count());
                break;
            
            case "Fuel_Panel_Btn":
                FuelUI.SetActive(true);
                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;
                break;
            
            case "Lube_Panel_Btn":
                LubeUI.SetActive(true);
                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;
                break;

            case "Comp_Panel_Btn":
                CompUI.SetActive(true);
                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;
                break;

            case "Power_Panel_Btn":
                PowerUI.SetActive(true);
                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;
                break;

            case "Steam_Panel_Btn":
                SteamUI.SetActive(true);
                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;
                break;

            case "Cool_Panel_Btn":
                CoolUI.SetActive(true);
                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;
                break;

             case "Misc_Panel_Btn":
                MiscUI.SetActive(true);
                break;

            default:
                break;
        }

    }

    public void Quit()
    {
        Application.Quit();
    }
}
