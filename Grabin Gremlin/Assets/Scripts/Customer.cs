using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.PackageManager;
using UnityEngine;

public class Customer : MonoBehaviour
{
    string customerName;
    public int age;
    public int mood = 100;

    string [] names;

    // Start is called before the first frame update
    void Start()
    {
        setMood();
        setAge();
        setName();
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    //Sets name of customer from list in function
    void setName()
    {
        names = new string[6];

        names[0] = "Torman Bringston";
        names[1] = "Mando Calrizian";
        names[2] = "Sleepy Sing";
        names[3] = "Randy Roler";
        names[4] = "Forton Sheeeeeeee";
        names[5] = "Mz";

        customerName = names[UnityEngine.Random.Range(1,6)];
    }

    //Sets starting mood of customer
    void setMood()
    {
        mood = mood - UnityEngine.Random.Range(0, 25);
    }

    //Sets age of customer
    void setAge()
    {
        age = UnityEngine.Random.Range(15, 100);
    }

    //Reduces the mood of customer 
    void reduceMood()
    {
        mood = mood - UnityEngine.Random.Range(20, 45);
    }

    //Increases the mood of customer 
    void increaseMood()
    {
        mood = mood + UnityEngine.Random.Range(5, 15);
    }

    //Checks the customers mood to see if they should storm off
    void checkMood()
    {
        if (mood <= 0)
        {
            //Customer storms out
        }
    }
}