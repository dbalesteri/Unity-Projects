using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr, affectDef;

    [Header("Weapon/Armor Details")]
    public int weaponStrength;

    public int armorStrength;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use (int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (isItem)
        {
            if (affectHP)
            {
                selectedChar.currentHP += amountToChange;

                if (selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP;
                }
            }

            if (affectMP)
            {
                selectedChar.currentMP += amountToChange;

                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP;
                }
            }

            if (affectStr)
            {
                selectedChar.strength += amountToChange;
            }

            if (affectDef)
            {
                selectedChar.defense += amountToChange;
            }
        }

        if (isWeapon)
        {
            if(selectedChar.equippedWeapon != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWeapon);
            }

            selectedChar.equippedWeapon = itemName;
            selectedChar.weaponPower = weaponStrength;
        }

        if (isArmor)
        {
            if(selectedChar.equippedArmor != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmor);
            }

            selectedChar.equippedArmor = itemName;
            selectedChar.armorPower = armorStrength;
        }

        GameManager.instance.RemoveItem(itemName);
    }

    public void BattleUse(string charToUseOn)
    {
        for (int i = 0; i < BattleManager.instance.activeBattlers.Count; i++)
        {
            if (charToUseOn == BattleManager.instance.activeBattlers[i].charName)
            {
                if (isItem)
                {
                    if (affectHP)
                    {
                        BattleManager.instance.activeBattlers[i].currentHP += amountToChange;

                        if (BattleManager.instance.activeBattlers[i].currentHP > BattleManager.instance.activeBattlers[i].maxHP)
                        {
                            BattleManager.instance.activeBattlers[i].currentHP = BattleManager.instance.activeBattlers[i].maxHP;
                        }
                    }

                    if (affectMP)
                    {
                        BattleManager.instance.activeBattlers[i].currentMP += amountToChange;

                        if (BattleManager.instance.activeBattlers[i].currentMP > BattleManager.instance.activeBattlers[i].maxMP)
                        {
                            BattleManager.instance.activeBattlers[i].currentMP = BattleManager.instance.activeBattlers[i].maxMP;
                        }
                    }

                    if (affectStr)
                    {
                        BattleManager.instance.activeBattlers[i].strength += amountToChange;
                    }

                    if (affectDef)
                    {
                        BattleManager.instance.activeBattlers[i].defense += amountToChange;
                    }
                }
                /*
                if (isWeapon)
                {
                    if (BattleManager.instance.activeBattlers[i].equippedWeapon != "")
                    {
                        GameManager.instance.AddItem(BattleManager.instance.activeBattlers[i].equippedWeapon);
                    }

                    selectedChar.equippedWeapon = itemName;
                    selectedChar.weaponPower = weaponStrength;
                }

                if (isArmor)
                {
                    if (selectedChar.equippedArmor != "")
                    {
                        GameManager.instance.AddItem(selectedChar.equippedArmor);
                    }

                    selectedChar.equippedArmor = itemName;
                    selectedChar.armorPower = armorStrength;
                }
                */

                GameManager.instance.RemoveItem(itemName);
            }
        }

    }


}
