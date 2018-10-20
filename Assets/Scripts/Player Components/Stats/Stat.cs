﻿using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{

    private int currentHealth;
    private int currentMana;
    private int currentDS;

    private int maxHealth;
    private int maxMana;
    private int maxDS;

    [HideInInspector] public int tab;

    [SerializeField] public Image mHealthDisplay;    
    [SerializeField] public Image mManaDisplay;
    [SerializeField] public Image mDSDisplay;
    //private Image mHealthDisplayReflection;

    private void Start()
    {
        //mHealthDisplayReflection = mHealthDisplay.transform.GetChild(0).GetComponent<Image>();

        mMaxHealth = 100;
        mMaxMana = 100;
        mMaxDS = 25;

        mCurrentHealth = mMaxHealth;
        mCurrentMana = mMaxMana;
        mCurrentDS = mMaxDS;
        
    }

    // ACCESSORS AND MUTATORS


    public int mMaxHealth { get { return maxHealth; } set { maxHealth = value; } }

    public int mMaxMana { get { return maxMana; } set { maxMana = value; } }

    public int mMaxDS { get { return maxDS; } set { maxDS = value; } }

    public int mCurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (value <= 0)
            {
                currentHealth = 0;
                // Destroy player
            }
            else if (value >= mMaxHealth)
            {
                currentHealth = mMaxHealth;
            }
            else
            {
                currentHealth = value;
            }

            mHealthDisplay.fillAmount = (float)currentHealth / mMaxHealth;
            // mHealthDisplayReflection.fillAmount = (float) currentHealth / mMaxHealth;            
        }
    }

    public int mCurrentMana
    {
        get
        {
            return currentMana;
        }

        set
        {
            if (value >= 0 && value < mMaxMana)
            {
                currentMana = value;
            }
            else if (value >= mMaxMana)
            {
                currentMana = mMaxMana;
            }

            if (this.gameObject.tag == "Player")
            {
                mManaDisplay.fillAmount = (float)currentMana / mMaxMana;
            }
        }
    }

    public int mCurrentDS
    {
        get
        {
            return currentDS;
        }

        set
        {
            if (value <= 0)
            {
                currentDS = 0;
            }
            else if (value >= mMaxDS)
            {
                currentDS = mMaxDS;
            }
            else
            {
                currentDS = value;
            }

            mDSDisplay.fillAmount = (float)currentDS / mMaxDS;
        }        
    }

    // OTHER INTERFACE METHODS
    public bool isGreaterThanCurrent(int type, int comparator)
    {
        int lCurrentValue = getCurrentOfType(type);

        if (comparator > lCurrentValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isCurrentEqualMax(int type)
    {
        int lCurrentValue = getCurrentOfType(type);
        int lMaxValue = getMaxOfType(type);

        if (lCurrentValue == lMaxValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // SUPPORT METHODS
    private int getCurrentOfType(int type)
    {
        int lCurrentValue = 0;

        switch (type)
        {
            case 0:
                lCurrentValue = mCurrentHealth;
                break;
            case 1:
                lCurrentValue = mCurrentMana;
                break;
            case 2:
                lCurrentValue = mCurrentDS;
                break;
        }

        return lCurrentValue;
    }

    private int getMaxOfType(int type)
    {
        int lMaxValue = 0;

        switch (type)
        {
            case 0:
                lMaxValue = mMaxHealth;
                break;
            case 1:
                lMaxValue = mMaxMana;
                break;
            case 2:
                lMaxValue = mMaxDS;
                break;
        }

        return lMaxValue;
    }

    
}
