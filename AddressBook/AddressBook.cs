﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Person
    {
        public string FName;
        public string LName;
        public string Address;
        public long PhoneNumber;

        public string Result()
        {
            return "Name is: " + FName + " " + LName + "\n Address: " + Address + "\n Phone: " + PhoneNumber;
        }
    }

    /// <summary>
    /// Address Book Class
    /// </summary>
    internal class AddressBook
    {
        //Creating List 
        public List<Person> person = new List<Person>();


        //Address Book method
        public AddressBook()
        {
            string json = File.ReadAllText(@"C:\BridgeLabz Assignment\day_27_pratice Problem\AddressBook\Deatils.jeson");
            if (json.Length > 0)
            {
                person = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            else
                person = new List<Person>();
        }

        //Display Method
        public void Display()
        {
            if (person.Count == 0)
            {
                Console.WriteLine("Please add Some Contact list First");
            }
            Console.WriteLine("Welcome to Program");
            foreach (Person per in person)
            {
                Console.WriteLine(per.Result());
            }
        }

        //Adding Contact list method
        public void addPerson(Person p)
        {
            person.Add(p);
            string jsonData = JsonConvert.SerializeObject(person);
            File.WriteAllText(@"C:\BridgeLabz Assignment\day_27_pratice Problem\AddressBook\Deatils.jeson", jsonData);
        }
    }
}

