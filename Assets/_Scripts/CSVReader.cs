using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class CSVReader : MonoBehaviour
{
   
    void Start()
    {
        ReadCSV();
    }
    void ReadCSV(){
        StreamReader strReader = new StreamReader("C:\\Users\\Ame\\TietovisaRaakile\\Assets\\questions.csv");
        bool endOfFile = false;
        while (!endOfFile){
            string data_String = strReader.ReadLine();
            if (data_String == null){
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(';');
            for (int o = 0; o < data_values.Length; o++){
                Debug.Log("Value:"+ o.ToString() + " " + data_values[o].ToString());
            }

        }
    }
}
