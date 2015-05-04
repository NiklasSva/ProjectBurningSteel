using UnityEngine;
using System.Collections;

public class EnergyScript : MonoBehaviour 
{
    public float maxEnergy = 100.0f;
    public float currentEnergy;

    public float boostCostModifier = 1.0f;
    public float boostRechargeModifier = 1.0f;
    public float attritionModifier = 1.0f;

    void Start()
    {
        currentEnergy = maxEnergy;
    }

    void Update()
    {
        if (currentEnergy > 0.0f)
        {
            EnergyDeath();
        }
    }

    public void BoostCost()
    {
        currentEnergy -= Time.deltaTime * boostCostModifier;
    }

    public void Recharge()
    {
        currentEnergy += Time.deltaTime * boostRechargeModifier;
    }

    public void AttritionDamage()
    {
        currentEnergy -= Time.deltaTime * attritionModifier;
    }

    void EnergyDeath()
    {
        // death goes here
    }
}
