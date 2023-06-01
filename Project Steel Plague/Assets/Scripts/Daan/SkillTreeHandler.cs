using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum UpgradeState
{
    Locked,
    Purchasable,
    Purchased
}
public class SkillTreeHandler : MonoBehaviour
{
    
    [SerializeField] SkillUpgrade[] upgrades;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            switch (upgrades[i].upgradeState)
            {
                case UpgradeState.Locked: 
                    upgrades[i].button.interactable = false;
                    return;
                case UpgradeState.Purchasable:
                    upgrades[i].button.interactable = true;
                    return;
                case UpgradeState.Purchased:
                    upgrades[i].button.Select();
                    return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class SkillUpgrade
{
    public UpgradeState upgradeState;
    public Button button;
}
