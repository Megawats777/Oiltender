using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{

    // The ingredient that this dispenser dispenses
    [SerializeField]
    private IngredientTypes dispensedIngredientType;

    // EXTERNAL REFERENCES
    private OrderManager orderManagerRef;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        orderManagerRef = FindObjectOfType<OrderManager>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Dispense ingredient
    public void dispenseIngredient()
    {
        // Increase the amount of ingredients dispensed
        // Based on the ingredient assigned to the dispenser
        orderManagerRef.increaseIngredientDispensed(dispensedIngredientType, 1);
    }


}
