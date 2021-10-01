using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.PackageManager;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string customerName;
    string [] names;
    public int age;
    public int mood = 100;

    //Getting the material and renderer attached to this object
    //Source: https://www.youtube.com/watch?v=dJB07ZSiW7k
    public Material[] material;
    Renderer rend;

    Animator anim;

    int offer;

    [SerializeField]
    GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        //Generates customer stats
        setMood();
        setAge();
        setName();

        //Setting the renderer and materials
        rend = GetComponentInChildren<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        anim = gameObject.GetComponent<Animator>();
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
    public void decreaseMood()
    {
        mood = mood - UnityEngine.Random.Range(20, 45);
    }

    //Increases the mood of customer 
    public void increaseMood()
    {
        mood = mood + UnityEngine.Random.Range(5, 15);
    }

    //Checks the customers mood to see if it changes or they should should storm out
    public void checkMood()
    {
        if (mood <= 0)
        {
            //Customer storms out
            rend.material = material[4];
            anim.SetTrigger("DoneShopping");
        }

        else if (mood <= 25)
        {
            //Customer angry
            rend.material = material[3];
        }

        else if (mood <= 50)
        {
            //Customer is upset
            rend.material = material[2];
        }

        else if (mood <= 75)
        {
            //Customer alright
            rend.material = material[1];
        }
        else
        {
            //Customer is happy
            rend.material = material[0];
        }
    }
}