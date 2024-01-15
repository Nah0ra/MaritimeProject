using ClosedXML.Excel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExcelHelper
{

    public static float min;
    public static float max;
    public static float rate;

    //Static function that returns values from the excel according to the field that contains the min, the max and the rate of change
    public static void ValueGetter(string MinField, string MaxField, string RateField)
    {
        

        XLWorkbook wb = new XLWorkbook(Application.dataPath + "/ValuesAndParameters.xlsx");
        var ws = wb.Worksheet("Gauge_Values");

        string minString = ws.Cell(MinField).Value.ToString();
        min = float.Parse(minString);

        string maxString = ws.Cell(MaxField).Value.ToString();
        max = float.Parse(maxString);

        string rateString = ws.Cell(RateField).Value.ToString();
        rate = float.Parse(rateString);

        
    }

}
