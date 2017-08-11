using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    // The number of dispensed ingredients
    private int dispensedBlueDiamond = 0;
    private int dispensedMagicGrape = 0;
    private int dispensedRedSugar = 0;


    // The current order requirements for ingredients
    private int requiredBlueDiamond = 0;
    private int requiredMagicGrape = 0;
    private int requiredRedSugar = 0;


    // The minimum and maximum range for ingredient order requirements
    [SerializeField]
    private int minimumRequiredIngredientAmount = 0;
    [SerializeField]
    private int maximumRequiredIngredientAmount = 10;

    // The score value of an order
    [SerializeField]
    private int orderScoreValue = 10;

	// The health value of an order
	[SerializeField]
	private int orderHealthValue = 10;

    // Is a new order being generated
    private bool isNewOrderBeingGenerated = false;

    // The delay between orders
    [SerializeField]
    private float delayBetweenOrders = 0.2f;

    // EXTERNAL REFERENCES
    private PlayerCharacter playerRef;
	private Robot robotRef;

    /*--GETTERS AND SETTERS--*/

    // Get and the number of dispensed ingredients
    public int getDispensedBlueDiamond()
    {
        return dispensedBlueDiamond;
    }

    public void setDispensedBlueDiamond(int dispensedBlueDiamond)
    {
        this.dispensedBlueDiamond = dispensedBlueDiamond;
    }


    public int getDispensedMagicGrape()
    {
        return dispensedMagicGrape;
    }

    public void setDispensedMagicGrape(int dispensedMagicGrape)
    {
        this.dispensedMagicGrape = dispensedMagicGrape;
    }


    public int getDispensedRedSugar()
    {
        return dispensedRedSugar;
    }

    public void setDispensedRedSugar(int dispensedRedSugar)
    {
        this.dispensedRedSugar = dispensedRedSugar;
    }



    // Get and set the required ingredient values
    public int getRequiredBlueDiamond()
    {
        return requiredBlueDiamond;
    }

    public void setRequiredBlueDiamond(int requiredBlueDiamond)
    {
        this.requiredBlueDiamond = requiredBlueDiamond;
    }


    public int getRequiredMagicGrape()
    {
        return requiredMagicGrape;
    }

    public void setRequiredMagicGrape(int requiredMagicGrape)
    {
        this.requiredMagicGrape = requiredMagicGrape;
    }


    public int getRequiredRedSugar()
    {
        return requiredRedSugar;
    }

    public void setRequiredRedSugar(int requiredRedSugar)
    {
        this.requiredRedSugar = requiredRedSugar;
    }


    // Get and set if a new order is being generated
    public bool getIsNewOrderBeingGenerated()
    {
        return isNewOrderBeingGenerated;
    }
    
    public void setIsNewOrderBeingGenerated(bool isNewOrderBeingGenerated)
    {
        this.isNewOrderBeingGenerated = isNewOrderBeingGenerated;
    }

    /*--END OF GETTERS AND SETTERS--*/


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        playerRef = FindObjectOfType<PlayerCharacter>();
		robotRef = FindObjectOfType<Robot>();
    }

    // Use this for initialization
    void Start()
    {
        generateOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Increase the number of an ingredient dispensed
    public void increaseIngredientDispensed(IngredientTypes dispensedIngredient, int increaseAmount)
    {
        // Depending on the dispensed ingredient chosen
        // Increase the amount of that ingredient that is dispensed
        if (dispensedIngredient == IngredientTypes.BlueDiamond)
        {
            setDispensedBlueDiamond(getDispensedBlueDiamond() + increaseAmount);
            print(dispensedIngredient.ToString() + " : " + getDispensedBlueDiamond());
        }

        else if (dispensedIngredient == IngredientTypes.MagicGrape)
        {
            setDispensedMagicGrape(getDispensedMagicGrape() + increaseAmount);
            print(dispensedIngredient.ToString() + " : " + getDispensedMagicGrape());
        }

        else if (dispensedIngredient == IngredientTypes.RedSugar)
        {
            setDispensedRedSugar(getDispensedRedSugar() + increaseAmount);
            print(dispensedIngredient.ToString() + " : " + getDispensedRedSugar());
        }
    }

    // Complete the current order
    public void completeCurrentOrder()
    {
        // If the number of ingredients dispensed matches the required values of the order
        if (getDispensedBlueDiamond() == getRequiredBlueDiamond() && getDispensedMagicGrape() == getRequiredMagicGrape()
            && getDispensedRedSugar() == getRequiredRedSugar())
        {
            // Add to the player's score
			// Increase the health of the robot
            // Generate a new order with a delay
            playerRef.increaseCurrentScore(orderScoreValue);
			robotRef.increaseHealth(orderHealthValue);
            StartCoroutine(generateOrderWithDelay());
            //print("Order Successful");
        }

        // Otherwise reduce the player's score
        else
        {
            // Decrease the player's score
            // Generate a new order with a delay
            playerRef.decreaseCurrentScore(orderScoreValue);
            StartCoroutine(generateOrderWithDelay());
            //print("Order Failed");
        }
    }

    // Generate a new order with a delay
    public IEnumerator generateOrderWithDelay()
    {
        setIsNewOrderBeingGenerated(true);

        // Stop the robot from losing health
        robotRef.stopDrainingHealth();

        yield return new WaitForSeconds(delayBetweenOrders);

        setIsNewOrderBeingGenerated(false);

        // Have the robot start losing health again
        robotRef.startDrainingHealth(delayBetweenOrders);

        // Generate a new order
        generateOrder();
    }


    // Generate order
    public void generateOrder()
    {
        // Reset dispensed ingredient amounts
        resetDispensedIngredientAmounts();

        // Set the required ingredient amounts
        setRequiredBlueDiamond(generateAndGetRequiredIngredientAmounts());
        setRequiredMagicGrape(generateAndGetRequiredIngredientAmounts());
        setRequiredRedSugar(generateAndGetRequiredIngredientAmounts());

        
		print("Required Blue Diamond: " + getRequiredBlueDiamond());
		print("Required Magic Grape: " + getRequiredMagicGrape());
		print("Required Red Sugar: " + getRequiredRedSugar());
		
    }

    // Generate and get required ingredient amounts
    private int generateAndGetRequiredIngredientAmounts()
    {
        return (int)Random.Range(minimumRequiredIngredientAmount, maximumRequiredIngredientAmount);
    }

    // Reset dispensed ingredient amounts
    private void resetDispensedIngredientAmounts()
    {
        setDispensedBlueDiamond(0);
        setDispensedMagicGrape(0);
        setDispensedRedSugar(0);
    }
}
