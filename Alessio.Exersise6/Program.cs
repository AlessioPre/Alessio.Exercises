﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Alessio.Exercises6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string dir = "E:\\";
            string filename = "filename.csv";
            string filePath = Path.Combine(dir, filename);

            List<Person> people = new List<Person>();
            people.Add(new() { Name = "franco", Surname = "Bruno", CF = "BRNFRC65T44F4443" });
            people.Add(new() { Name = "LUCA", Surname = "Bruno", CF = "BRNFRC65T44F4443" });
            people.Add(new() { Name = "MARCO", Surname = "Bruno", CF = "BRNFRC65T44F4443" });
            people.Add(new() { Name = "luisa", Surname = "Bruno", CF = "BRNFRC65T44F4443" });
           
            TextFileGenerator.SaveToFile(people, filePath);
            var newList = TextFileGenerator.LoadFromCSVFile(people[0], filePath);

            if (newList != null)
            {
                foreach (var item in newList)
                {
                    Console.WriteLine($"{item.Name}, {item.Surname}, {item.CF}");
                }
            }
        }

        public static class TextFileGenerator
        {

            //Serialization 
            public static void SaveToFile<T>(List<T> data, string filePath)
            {
                StringBuilder line = new StringBuilder();

                //check
                if (data == null || data.Count == 0) return;

                //retrieve properties
                var cols = data[0].GetType().GetProperties();

                //file not exists create header
                if (!File.Exists(filePath))
                {
                    foreach (var col in cols)
                    {
                        string propName = col.Name;
                        line.Append(propName);

                        if (col != cols.Last())
                        {
                            line.Append(',');
                        }
                        else
                        {
                            line.Append('\n');
                        }
                    }

                    File.AppendAllText(filePath, line.ToString());
                }

                //create rows 
                foreach (var row in data)
                {
                    line = new StringBuilder();

                    foreach (var col in cols)
                    {
                        var value = col.GetValue(row);
                        line.Append(value);

                        if (col != cols.Last())
                        {
                            line.Append(',');
                        }
                        else
                        {
                            line.Append('\n');
                        }
                    }

                    File.AppendAllText(filePath, line.ToString());
                }
            }

            //Deserialization 
            public static List<T> LoadFromCSVFile<T>(T data, string filePath) where T : class, new()
            {
                string[] rows = File.ReadAllLines(filePath);
                var cols = data.GetType().GetProperties();

                //check if header file is contained in T props
                List<string> propsNameList = new List<string>();
                string[] headerWordsAray = rows[0].Split(',');

                foreach (var col in cols)
                {
                    propsNameList.Add(col.Name);
                }

                foreach (var headerWord in headerWordsAray)
                {
                    if (!propsNameList.Contains(headerWord)) return null;
                }

                //new list with T objects
                List<T> list = new List<T>();

                foreach (var row in rows)
                {
                    if (row == rows.First()) continue;

                    T obj = new();
                    string[] rowWords = new string[cols.Length];

                    if (row != rows.First())
                    {
                        rowWords = row.Split(',');
                    }

                    for (int i = 0; i < headerWordsAray.Length; i++)
                    {
                        //maybe rowWords and cols should be sorted to avoid bugs
                        var convertedValue = Convert.ChangeType(rowWords[i], cols[i].PropertyType);
                        obj.GetType().GetProperty(cols[i].Name).SetValue(obj, convertedValue);
                    }

                    list.Add(obj);
                }

                return list;
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string CF { get; set; }
        }
    }
}