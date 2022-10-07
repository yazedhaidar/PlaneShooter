using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetController : MonoBehaviour
{
    public GameObject[] weaponSets;

    // Start is called before the first frame update
    void Start()
    {
        deactivateAllWeapons();
        activeWeaponSets(0);
        weaponUpgradeCheck();
    }

    private void deactivateAllWeapons()
    {
        foreach(GameObject go in weaponSets)
        {
            go.SetActive(false);
        }
    }

    public void activeWeaponSets(int upgradeLevel)
    {
        for (int i = 0; i < weaponSets.Length; i++)
        {
            if (i == upgradeLevel) 
            {
                weaponSets[i].SetActive(true);
            }
            else
            {
                weaponSets[i].SetActive(false);
            }
        }
    }

    public void  weaponUpgradeCheck()
    {
        int upgradeLevel = GetComponents<WeaponUpgrade>().Length;
        if (upgradeLevel >= weaponSets.Length) 
        {
            upgradeLevel = weaponSets.Length - 1;
        }
        activeWeaponSets(upgradeLevel);
        fireRateUpdate();
    }

    private void fireRateUpdate()
    {
        foreach (Weapon w in GetComponentsInChildren<Weapon>())
        {
            w.clearModifier();
            foreach(FireRateModifier f in GetComponents<FireRateModifier>())
            {
                w.addFireRateModifier(f.modifier);
            }
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
