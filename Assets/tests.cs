/*
  Reading values froma  CSV file using C#.
  Date: 25/03/21
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class tests : MonoBehaviour
{
  //static void Main(string[] args)
  void Start()
  {
    // StreamReader == sstream
    using (var reader = new StreamReader(@"C:\Users\diana\Documents\Unity\Las aventura de Sofía, al rescate del valle Ulu' ha\Assets\testCSV.csv"))
    {
      List<string> listA = new List<string>();
      List<string> listB = new List<string>();
      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        Console.WriteLine(line);
        var values = line.Split(','); // split every once I find a ","

        // example of a CSV with only two columns.
        listA.Add(values[0]);
        listB.Add(values[1]);
        Console.WriteLine(values[0]);
        Console.WriteLine(values[1]);

      }
    }
  }
}
