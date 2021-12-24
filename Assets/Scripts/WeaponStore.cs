using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStore : MonoBehaviour
{

    public GameObject player, weaponMenuUI;
    private PlayerAction playerAction;
    private int userChoice;
    private AudioSource cashIn;

    public Text weaponOnTable;

    // Start is called before the first frame update
    void Start()
    {
        playerAction = player.GetComponent<PlayerAction>();
        cashIn = GetComponent<AudioSource>();
        userChoice = -1; // Start with the option to refill ammo
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponMenuUI.active)
        {
            Weapon[] allWeapons = playerAction.getGunProps();

            if (userChoice > -2 && Input.GetKeyDown(KeyCode.Alpha1))
                userChoice--;
            else if (userChoice < allWeapons.Length - 1 && Input.GetKeyDown(KeyCode.Alpha2))
                userChoice++;


            int price;
            if (userChoice == -2)
            {
                price = 5000;
                weaponOnTable.text = "< Vest: " + price + " >";
            }
            else if (userChoice == -1) // refill ammo
            {
                price = 500;
                weaponOnTable.text = "< Refill Ammo: " + price + " >";
            }
            else
            {
                price = allWeapons[userChoice].getPrice();
                if (!allWeapons[userChoice].getIsOwned())
                    weaponOnTable.text = "< " + allWeapons[userChoice].getName() + ": " + price + " >";
                else
                    weaponOnTable.text = "< " + allWeapons[userChoice].getName() + ": Owned > ";
            }
            // either we pay for ammo or vest, or we pay for unowned weapon.
            if ((Input.GetKeyDown(KeyCode.Return) && (userChoice == -1 || userChoice == -2)) ||
            (Input.GetKeyDown(KeyCode.Return) && !allWeapons[userChoice].getIsOwned()))
                pay(price);

        }
    }
    private bool pay(int price)
    {
        if (playerAction.getCoins() >= price)
        {
            playerAction.setCoins(playerAction.getCoins() - price);
            if (userChoice != -1 && userChoice != -2)
                playerAction.getGunProps()[userChoice].setIsOwned(true);
            else if (userChoice == -1)
                refillAmmo();
            else
                getVest();
            cashIn.Play();
            return true;
        }
        else
        {
            // Not enough money
            return false;
        }
    }
    private void refillAmmo()
    {
        Weapon[] allWeapons = playerAction.getGunProps();
        for (int i = 0; i < allWeapons.Length; i++)
        {
            if (allWeapons[i].getIsOwned())
            {
                allWeapons[i].setAmmoLeft(allWeapons[i].getMaxAmmo());
            }
        }
    }

    private void getVest()
    {
        playerAction.setVest();
    }

    private void OnTriggerStay(Collider other)
    {
        weaponMenuUI.SetActive(true);
        playerAction.buyMode = true;
    }

    private void OnTriggerExit(Collider other)
    {
        weaponMenuUI.SetActive(false);
        playerAction.buyMode = false;
    }

}
