using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;


public class GameManager : MonoBehaviourPunCallbacks
{
    //Panels
    private GameObject MainOBJ;
    private GameObject FuelOBJ;
    private GameObject LubeOBJ;
    private GameObject CompOBJ;
    private GameObject PowerOBJ;
    private GameObject SteamOBJ;
    private GameObject CoolOBJ;
    private GameObject MiscOBJ;
    private GameObject SaveGUI_OBJ;

    private GameObject ShorePower;

    //UI
    private GameObject MainUI;
    private GameObject FuelUI;
    private GameObject LubeUI;
    private GameObject CompUI;
    private GameObject PowerUI;
    private GameObject SteamUI;
    private GameObject CoolUI;
    private GameObject MiscUI;
    private GameObject SaveGUI;

    //Dials
    private GameObject MainDials;
    private GameObject FuelDials;
    private GameObject LubeDials;
    private GameObject CompDials;
    private GameObject PowerDials;
    private GameObject SteamDials;
    private GameObject CoolDials;
    private GameObject MiscDials;


    //Buttons
    private Button MainButton;
    private Button FuelButton;
    private Button LubeButton;
    private Button CompButton;
    private Button PowerButton;
    private Button SteamButton;
    private Button CoolButton;
    private Button MiscButton;
    private Button SaveGUIButton;
    // private Button SaveButton;
    // private Button LoadButton;

    // private InputField saveInputField;

    GameObject[] dials;

    public bool shore = false;
    PhotonView photonView;

    private void Awake()
    {
        Initialise();
        dials = GameObject.FindGameObjectsWithTag("Dial");
        photonView = PhotonView.Get(this);
        ShorePower.SetActive(false);

        Connect();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        PhotonNetwork.JoinOrCreateRoom("Default", roomOptions:default, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        StartCoroutine(WaitForClients());
    }

    private IEnumerator WaitForClients()
    {
        while (PhotonNetwork.PlayerList.Length != 2)
        {
            Debug.Log("Waiting for clients");
            yield return new WaitForSeconds(1f);
        }
    }
    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void onButtonPress()
    {
        shore = true;
        Debug.Log("Shore on");
    }

    private void LoadPanel()
    {
        //Determine the tag of the currently selected button
        string currentTag = EventSystem.current.currentSelectedGameObject.tag;
        switch (currentTag)
        {
            case "MainButton":
                MainUI.SetActive(true);
                FuelUI.SetActive(false);
                LubeUI.SetActive(false);
                CoolUI.SetActive(false);
                CompUI.SetActive(false);
                PowerUI.SetActive(false);
                SteamUI.SetActive(false);
                MiscUI.SetActive(false);
                SaveGUI.SetActive(false);
                ShorePower.SetActive(false);

                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;

                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in MiscDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                break;

            case "FuelButton":
                MainUI.SetActive(false);
                FuelUI.SetActive(true);
                LubeUI.SetActive(false);
                CoolUI.SetActive(false);
                CompUI.SetActive(false);
                PowerUI.SetActive(false);
                SteamUI.SetActive(false);
                MiscUI.SetActive(false);
                SaveGUI.SetActive(false);
                ShorePower.SetActive(false);

                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;

                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in MiscDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                break;

            case "LubeButton":
                MainUI.SetActive(false);
                FuelUI.SetActive(false);
                LubeUI.SetActive(true);
                CoolUI.SetActive(false);
                CompUI.SetActive(false);
                PowerUI.SetActive(false);
                SteamUI.SetActive(false);
                MiscUI.SetActive(false);
                SaveGUI.SetActive(false);
                ShorePower.SetActive(false);

                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;

                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in MiscDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                break;


            case "CoolButton":
                MainUI.SetActive(false);
                FuelUI.SetActive(false);
                LubeUI.SetActive(false);
                CoolUI.SetActive(true);
                CompUI.SetActive(false);
                PowerUI.SetActive(false);
                SteamUI.SetActive(false);
                MiscUI.SetActive(false);
                SaveGUI.SetActive(false);
                ShorePower.SetActive(false);

                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;

                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in MiscDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                break;

            case "CompButton":
                MainUI.SetActive(false);
                FuelUI.SetActive(false);
                LubeUI.SetActive(false);
                CoolUI.SetActive(false);
                CompUI.SetActive(true);
                PowerUI.SetActive(false);
                SteamUI.SetActive(false);
                MiscUI.SetActive(false);
                SaveGUI.SetActive(false);
                ShorePower.SetActive(false);

                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;

                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in MiscDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                break;

            case "PowerButton":
                MainUI.SetActive(false);
                FuelUI.SetActive(false);
                LubeUI.SetActive(false);
                CoolUI.SetActive(false);
                CompUI.SetActive(false);
                PowerUI.SetActive(true);
                SteamUI.SetActive(false);
                MiscUI.SetActive(false);
                SaveGUI.SetActive(false);
                ShorePower.SetActive(true);

                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;

                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in MiscDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                break;

            case "SteamButton":
                MainUI.SetActive(false);
                FuelUI.SetActive(false);
                LubeUI.SetActive(false);
                CoolUI.SetActive(false);
                CompUI.SetActive(false);
                PowerUI.SetActive(false);
                SteamUI.SetActive(true);
                MiscUI.SetActive(false);
                SaveGUI.SetActive(false);
                ShorePower.SetActive(false);

                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;

                foreach (Transform child in MiscDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                break;

            case "MiscButton":
                MainUI.SetActive(false);
                FuelUI.SetActive(false);
                LubeUI.SetActive(false);
                CoolUI.SetActive(false);
                CompUI.SetActive(false);
                PowerUI.SetActive(false);
                SteamUI.SetActive(false);
                MiscUI.SetActive(true);
                SaveGUI.SetActive(false);
                ShorePower.SetActive(false);

                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in MiscDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = false;

                break;
            case "SaveGUIButton":
                MainUI.SetActive(false);
                FuelUI.SetActive(false);
                LubeUI.SetActive(false);
                CoolUI.SetActive(false);
                CompUI.SetActive(false);
                PowerUI.SetActive(false);
                SteamUI.SetActive(false);
                MiscUI.SetActive(false);
                SaveGUI.SetActive(true);
                ShorePower.SetActive(false);

                GameObject.FindGameObjectWithTag("SaveButton").GetComponent<Button>().onClick.AddListener(CheckInputField);
                GameObject.FindGameObjectWithTag("LoadButton").GetComponent<Button>().onClick.AddListener(CheckInputField);


                foreach (Transform child in MainDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in FuelDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in LubeDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CoolDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in CompDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in PowerDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in SteamDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                foreach (Transform child in MiscDials.transform)
                    child.GetComponent<SimpleGaugeMaker>().Hide = true;

                break;

            default:
                Debug.Log("Button Unassigned");
                break;
        }



    }

    //Initialise the scene and load the appropriate dials
    private void Initialise()
    {
        //Assigning panels
        MainOBJ = GameObject.Find("Main_OBJ");
        FuelOBJ = GameObject.Find("Fuel_OBJ");
        LubeOBJ = GameObject.Find("Lubricating_OBJ");
        CoolOBJ = GameObject.Find("Cooling_OBJ");
        CompOBJ = GameObject.Find("Compressed_OBJ");
        PowerOBJ = GameObject.Find("Power_Plant_OBJ");
        SteamOBJ = GameObject.Find("Steam_OBJ");
        MiscOBJ = GameObject.Find("Miscellaneous_OBJ");
        SaveGUI_OBJ = GameObject.Find("SaveGUI_OBJ");
        ShorePower = GameObject.Find("Shore Power");

        //Assigning UI
        MainUI = MainOBJ.transform.GetChild(0).gameObject;
        FuelUI = FuelOBJ.transform.GetChild(0).gameObject;
        LubeUI = LubeOBJ.transform.GetChild(0).gameObject;
        CoolUI = CoolOBJ.transform.GetChild(0).gameObject;
        CompUI = CompOBJ.transform.GetChild(0).gameObject;
        PowerUI = PowerOBJ.transform.GetChild(0).gameObject;
        SteamUI = SteamOBJ.transform.GetChild(0).gameObject;
        MiscUI = MiscOBJ.transform.GetChild(0).gameObject;
        SaveGUI = SaveGUI_OBJ.transform.GetChild(0).gameObject;
        FuelUI.SetActive(false);
        LubeUI.SetActive(false);
        CoolUI.SetActive(false);
        CompUI.SetActive(false);
        PowerUI.SetActive(false);
        SteamUI.SetActive(false);
        MiscUI.SetActive(false);
        SaveGUI.SetActive(false);

        //Assigning Dials
        MainDials = MainOBJ.transform.GetChild(1).gameObject;
        FuelDials = FuelOBJ.transform.GetChild(1).gameObject;
        LubeDials = LubeOBJ.transform.GetChild(1).gameObject;
        CoolDials = CoolOBJ.transform.GetChild(1).gameObject;
        CompDials = CompOBJ.transform.GetChild(1).gameObject;
        PowerDials = PowerOBJ.transform.GetChild(1).gameObject;
        SteamDials = SteamOBJ.transform.GetChild(1).gameObject;
        MiscDials = MiscOBJ.transform.GetChild(1).gameObject;

        foreach (Transform child in FuelDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in LubeDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in CoolDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in CompDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in PowerDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in SteamDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;

        foreach (Transform child in MiscDials.transform)
            child.GetComponent<SimpleGaugeMaker>().Hide = true;


        //Assinging Buttons
        MainButton = GameObject.FindGameObjectWithTag("MainButton").GetComponent<Button>();
        FuelButton = GameObject.FindGameObjectWithTag("FuelButton").GetComponent<Button>();
        LubeButton = GameObject.FindGameObjectWithTag("LubeButton").GetComponent<Button>();
        CompButton = GameObject.FindGameObjectWithTag("CompButton").GetComponent<Button>();
        PowerButton = GameObject.FindGameObjectWithTag("PowerButton").GetComponent<Button>();
        SteamButton = GameObject.FindGameObjectWithTag("SteamButton").GetComponent<Button>();
        CoolButton = GameObject.FindGameObjectWithTag("CoolButton").GetComponent<Button>();
        MiscButton = GameObject.FindGameObjectWithTag("MiscButton").GetComponent<Button>();
        SaveGUIButton = GameObject.FindGameObjectWithTag("SaveGUIButton").GetComponent<Button>();
        // SaveButton = GameObject.FindGameObjectWithTag("SaveButton").GetComponent<Button>();
        // LoadButton = GameObject.FindGameObjectWithTag("LoadButton").GetComponent<Button>();

        //Adding event listeners to buttons
        MainButton.onClick.AddListener(LoadPanel);
        FuelButton.onClick.AddListener(LoadPanel);
        LubeButton.onClick.AddListener(LoadPanel);
        CompButton.onClick.AddListener(LoadPanel);
        PowerButton.onClick.AddListener(LoadPanel);
        SteamButton.onClick.AddListener(LoadPanel);
        CoolButton.onClick.AddListener(LoadPanel);
        MiscButton.onClick.AddListener(LoadPanel);
        SaveGUIButton.onClick.AddListener(LoadPanel);
        // SaveButton.onClick.AddListener(CheckInputField);
        // LoadButton.onClick.AddListener(CheckInputField);
    }

    private void CheckInputField()
    {
        Debug.Log("fjisjfies");
        // InputField saveInputField = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputField>().text;
        string inputValue = GameObject.FindGameObjectWithTag("InputField").GetComponent<TMP_InputField>().text;
        string currentTag = EventSystem.current.currentSelectedGameObject.tag;

        if (string.IsNullOrEmpty(inputValue))
        {
            Debug.Log("Error: Input field cannot be empty!");
            // errorMessageText.text = "Error: Input field cannot be empty!";
        }
        else
        {
            // errorMessageText.text = "";
            Debug.Log("InputField Value: " + inputValue);
            switch (currentTag)
            {
                case "SaveButton":
                    break;
                case "LoadButton":
                    break;
            }
        }
    }
        
}
