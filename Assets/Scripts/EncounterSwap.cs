using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterSwap : MonoBehaviour
{
    [SerializeField] private GameObject endcounterOne;
    [SerializeField] private GameObject endcounterTwo;
    [SerializeField] private GameObject endcounterTwoDotTwo;
    [SerializeField] private GameObject endcounterThree;
    [SerializeField] private GameObject endcounterThreeDotThree;
    [SerializeField] private GameObject endcounterBoss;

    public int mapNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (mapNumber)
        {
            case 1:
                endcounterOne.SetActive(true);
                endcounterTwo.SetActive(false);
                endcounterTwoDotTwo.SetActive(false);
                endcounterThree.SetActive(false);
                endcounterThreeDotThree.SetActive(false);
                endcounterBoss.SetActive(false);
                break;
            case 2:
                endcounterOne.SetActive(false);
                endcounterTwo.SetActive(true);
                endcounterTwoDotTwo.SetActive(false);
                endcounterThree.SetActive(false);
                endcounterThreeDotThree.SetActive(false);
                endcounterBoss.SetActive(false);
                break;
            case 3:
                endcounterOne.SetActive(false);
                endcounterTwo.SetActive(false);
                endcounterTwoDotTwo.SetActive(true);
                endcounterThree.SetActive(false);
                endcounterThreeDotThree.SetActive(false);
                endcounterBoss.SetActive(false);
                break;
            case 4:
                endcounterOne.SetActive(false);
                endcounterTwo.SetActive(false);
                endcounterTwoDotTwo.SetActive(false);
                endcounterThree.SetActive(true);
                endcounterThreeDotThree.SetActive(false);
                endcounterBoss.SetActive(false);
                break;
            case 5:
                endcounterOne.SetActive(false);
                endcounterTwo.SetActive(false);
                endcounterTwoDotTwo.SetActive(false);
                endcounterThree.SetActive(false);
                endcounterThreeDotThree.SetActive(true);
                endcounterBoss.SetActive(false);
                break;
            case 6:
                endcounterOne.SetActive(false);
                endcounterTwo.SetActive(false);
                endcounterTwoDotTwo.SetActive(false);
                endcounterThree.SetActive(false);
                endcounterThreeDotThree.SetActive(false);
                endcounterBoss.SetActive(true);
                break;
                
        }
    }
}
