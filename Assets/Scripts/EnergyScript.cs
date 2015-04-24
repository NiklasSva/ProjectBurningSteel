using UnityEngine;
using System.Collections;

public class EnergyScript : MonoBehaviour 
{
    public float maxEnergy = 100.0f;
    public float currentEnergy;

    public float boostCostModifier = 1.0f;
    public float boostRechargeModifier = 1.0f;

    void Start()
    {
        currentEnergy = maxEnergy;
    }

    public void BoostCost()
    {
        currentEnergy -= Time.deltaTime * boostCostModifier;
    }

    public void Recharge()
    {
        currentEnergy += Time.deltaTime * boostRechargeModifier;
    }
}
