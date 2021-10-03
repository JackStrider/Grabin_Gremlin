using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.PackageManager;
using UnityEngine;
using Random = UnityEngine.Random;

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

    Gremlin gremlin;

    //The current price in haggle
    public int offer;

    //Possible items
    [SerializeField]
    GameObject [] possibleItems;

    //Chosen item
    [SerializeField]
    GameObject chosenItem;

    //Item quality
    //1.Damaged
    //2.Normal
    //3.Rare
    //4.Prestine
    //5.Epic
    [SerializeField]
    int quality;

    //Item location on counter
    [SerializeField]
    GameObject itemSpawnLocation;
    GameObject chosenItemInScene;

    // Start is called before the first frame update
    void Start()
    {
        gremlin = GameObject.FindGameObjectWithTag("Gremlin").GetComponent<Gremlin>();

        //Generates customer stats
        setMood();
        setAge();
        setName();

        //Chose the item Customer wants
        chosenItem = possibleItems[Random.Range(0,2)];

        //Generate item quality
        quality = Random.Range(0, gremlin.highestGearLevel);

        //Generate offer
        offer = Random.Range(10,21) * (quality + 1);

        //Setting the renderer and materials
        rend = GetComponentInChildren<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        //Declaring animator
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
        //Customer storms out
        if (mood <= 0)
        {
            rend.material = material[4];
            destroyItem();
            anim.SetTrigger("DoneShopping");
            resetOffer();
        }

        //Customer angry
        else if (mood <= 25)
        {
            rend.material = material[3];
        }

        //Customer is upset
        else if (mood <= 50)
        {
            rend.material = material[2];
        }

        //Customer alright
        else if (mood <= 75)
        {
            rend.material = material[1];
        }

        //Customer is happy
        else
        {
            rend.material = material[0];
        }
    }

    //Generates new offer More button press
    public void newOffer()
    {
        offer = offer + (Random.Range(5, 16) * (gremlin.barterSkill + 1));
    }

    //Resets the offer to 0
    public void resetOffer()
    {
        offer = 0;
        gremlin.updateOfferText();
    }

    //Places chosen item on counter
    //Triggered from animation event
    public void placeItem()
    {
        Instantiate(chosenItem, itemSpawnLocation.transform);
        chosenItemInScene = GameObject.FindGameObjectWithTag("Item");
    }

    //Destroy chosen item, customer "takes it with them" or not if storming out
    public void destroyItem()
    {
        Destroy(chosenItemInScene);
    }
}