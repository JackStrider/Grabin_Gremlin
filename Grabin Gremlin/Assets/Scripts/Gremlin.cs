using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gremlin : MonoBehaviour
{
    //Current gold owned
    public int gold;

    //Highest level gear unlocked
    public int highestGearLevel;

    public int barterSkill;

    Customer customer;

    //Gold ammount text
    [SerializeField]
    GameObject goldText;

    //Offer ammount text
    [SerializeField]
    GameObject offerText;

    // Start is called before the first frame update
    void Start()
    {
        customer = GameObject.FindGameObjectWithTag("Customer").GetComponent<Customer>();
        updateGoldText();
        updateOfferText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateGoldText()
    {
        goldText.GetComponent<UnityEngine.UI.Text>().text = "Gold: " + gold;
    }

    public void updateOfferText()
    {
        offerText.GetComponent<UnityEngine.UI.Text>().text = "Current offer: " + customer.offer;
    }
}