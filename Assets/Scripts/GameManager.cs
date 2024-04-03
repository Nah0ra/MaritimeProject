using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
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

    DatabaseReference reference;
    GameObject[] dials;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Initialise();
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        dials = GameObject.FindGameObjectsWithTag("Dial");
        reference.Child("Default").ValueChanged += StateChanged;
        StartCoroutine(SyncData());

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        StartCoroutine(SaveDataPeriodically("Default", 1f));
    }

    private void StateChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        // Update UI based on the changed data
        UpdateValues(args.Snapshot);

    }

    private void UpdateValues(DataSnapshot snapshot)
    {
        foreach (var dialSnapshot in snapshot.Children)
        {
            string dialName = dialSnapshot.Key;
            float dialValue = float.Parse(dialSnapshot.Child("Value").Value.ToString());
            bool dialDirection = bool.Parse(dialSnapshot.Child("Direction").Value.ToString());
            float dialRoC = float.Parse(dialSnapshot.Child("Rate of Change").Value.ToString());

            // Find the corresponding UI element and update its values
            GameObject dialObject = GameObject.Find(dialName);
            if (dialObject != null)
            {
                dialObject.GetComponent<GaugeScript>().Value = dialValue;
            }
        }

    }

    IEnumerator SyncData()
    {
        while (true)
        {
            SaveData("Default");
            yield return new WaitForSeconds(0.1f);
            Debug.Log("Data Synced!");
        }
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
                    SaveData(inputValue);
                    break;
                case "LoadButton":
                    LoadData(inputValue);
                    break;
            }
        }
    }

    private IEnumerator SaveDataPeriodically(string saveSlotName, float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            SaveData(saveSlotName);
        }
    }

    //Saves the current dial values to Firebase, using the saveslot names as an input
    public void SaveData(string saveSlotName)
    {
        foreach (GameObject dial in dials)
        {
            DatabaseReference dialRef = reference.Child(saveSlotName).Child(dial.name);

            dialRef.RunTransaction(transaction =>
            {
                // Get the current data at this location
                var currentData = transaction.Value as Dictionary<string, object>;

                // If data doesn't exist or is null, initialize it
                if (currentData == null)
                {
                    currentData = new Dictionary<string, object>();
                    transaction.Value = currentData;
                }

                // Update the values
                currentData["Value"] = dial.GetComponent<GaugeScript>().Value;
                currentData["Direction"] = dial.GetComponent<GaugeScript>().Forward;
                currentData["RateOfChange"] = dial.GetComponent<GaugeScript>().RateOfChange;

                // Set the updated data
                transaction.Value = currentData;

                // Return the updated transaction
                return TransactionResult.Success(transaction);
            });
        }
    }




    //Loads the current dial values from Firebase, using the saveslot names as an input
    public void LoadData(string SaveSlotName)
    {
        reference.Child(SaveSlotName).ValueChanged += HandleDataChanged;
    }

    private void HandleDataChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        if (args.Snapshot != null && args.Snapshot.Exists)
        {
            foreach (var dialSnapshot in args.Snapshot.Children)
            {
                string dialName = dialSnapshot.Key;
                float dialValue = float.Parse(dialSnapshot.Child("Value").Value.ToString());
                bool dialDirection = bool.Parse(dialSnapshot.Child("Direction").Value.ToString());
                float dialRateOfChange = float.Parse(dialSnapshot.Child("Rate of Change").Value.ToString());

                // Update the corresponding dial object in your scene
                GameObject dialObject = GameObject.Find(dialName);
                if (dialObject != null)
                {
                    dialObject.GetComponent<GaugeScript>().Value = dialValue;
                    dialObject.GetComponent<GaugeScript>().Forward = dialDirection;
                    dialObject.GetComponent<GaugeScript>().RateOfChange = dialRateOfChange;
                }
            }
        }
    }

}
