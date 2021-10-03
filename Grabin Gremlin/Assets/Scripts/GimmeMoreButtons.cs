using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmeMoreButtons : MonoBehaviour
{
    //Declerations
    Customer customer;
    Gremlin gremlin;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiating
        //Source: https://www.youtube.com/watch?v=ZHr3v8Ewxc0
        customer = GameObject.FindGameObjectWithTag("Customer").GetComponent<Customer>();

        gremlin = GameObject.FindGameObjectWithTag("Gremlin").GetComponent<Gremlin>();
        anim = GameObject.FindGameObjectWithTag("Customer").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gimme()
    {
        gremlin.gold = gremlin.gold + customer.offer;
        customer.destroyItem();
        gremlin.updateGoldText();
        customer.resetOffer();
        anim.SetTrigger("DoneShopping");
    }

    //Calls for the customer's mood to be reduced and changes visual mood in checkMood
    public void more()
    {
        customer.newOffer();
        customer.decreaseMood();
        gremlin.updateOfferText();
        customer.checkMood();
    }
}