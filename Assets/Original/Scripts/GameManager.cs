using ClosedXML.Excel;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    //UI
    private GameObject MainUI;
    private GameObject FuelUI;
    private GameObject LubeUI;
    private GameObject CompUI;
    private GameObject PowerUI;
    private GameObject SteamUI;
    private GameObject CoolUI;
    private GameObject MiscUI;

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

    private void Awake()
    {
        Initialise();
        StartCoroutine(SaveData());
    }

    private void LoadPanel()
    {
        //Determine the tag of the currently selected button
        string currentTag = EventSystem.current.currentSelectedGameObject.tag;
        XLWorkbook wb = new XLWorkbook(Application.dataPath + "/ValuesAndParameters.xlsx");
        var ws = wb.Worksheet("Saved_Data");

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

            default:
                Debug.Log("Button Unassigned");
                break;
        }



    }

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

        //Assigning UI
        MainUI = MainOBJ.transform.GetChild(0).gameObject;
        FuelUI = FuelOBJ.transform.GetChild(0).gameObject;
        LubeUI = LubeOBJ.transform.GetChild(0).gameObject;
        CoolUI = CoolOBJ.transform.GetChild(0).gameObject;
        CompUI = CompOBJ.transform.GetChild(0).gameObject;
        PowerUI = PowerOBJ.transform.GetChild(0).gameObject;
        SteamUI = SteamOBJ.transform.GetChild(0).gameObject;
        MiscUI = MiscOBJ.transform.GetChild(0).gameObject;
        FuelUI.SetActive(false);
        LubeUI.SetActive(false);
        CoolUI.SetActive(false);
        CompUI.SetActive(false);
        PowerUI.SetActive(false);
        SteamUI.SetActive(false);
        MiscUI.SetActive(false);

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

        //Adding event listeners to buttons
        MainButton.onClick.AddListener(LoadPanel);
        FuelButton.onClick.AddListener(LoadPanel);
        LubeButton.onClick.AddListener(LoadPanel);
        CompButton.onClick.AddListener(LoadPanel);
        PowerButton.onClick.AddListener(LoadPanel);
        SteamButton.onClick.AddListener(LoadPanel);
        CoolButton.onClick.AddListener(LoadPanel);
        MiscButton.onClick.AddListener(LoadPanel);
    }

    private IEnumerator SaveData()
    {

        XLWorkbook wb = new XLWorkbook(Application.dataPath + "/ValuesAndParameters.xlsx");
        var ws = wb.Worksheet("Saved_Data");

        while (true)
        {
            yield return new WaitForSeconds(1);
            GameObject[] dials = GameObject.FindGameObjectsWithTag("Dial");

            int Count = 2;

            foreach (GameObject dial in dials)
            {
                string DialName = dial.name;
                float DialValue = dial.GetComponent<GaugeScript>().Value;

                ws.Cell("A" + Count).Value = DialName;
                ws.Cell("B" + Count).Value = DialValue;
                Count++;
            }
            wb.Save();
            Count = 2;
        }
        
    }


}
