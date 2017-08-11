using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    // The look sensitivity
    [SerializeField]
    private float lookSensitivity = 20.0f;

    // The current rotation x and y values
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;


    // SCORE PROPERTIES
    private int currentScore = 0;
    private int highScore = 10;



    // EXTERNAL REFRENCES
    private OrderManager orderManagerRef;
    private GameManager gameManagerRef;

    /*--GETTERS AND SETTERS--*/

    // Get and set the current score
    public int getCurrentScore()
    {
        return currentScore;
    }

    public void setCurrentScore(int currentScore)
    {
        this.currentScore = currentScore;
        print("Current Score:" + getCurrentScore());
    }


    // Get and set the high score
    public int getHighScore()
    {
        return highScore;
    }

    public void setHighScore(int highScore)
    {
        this.highScore = highScore;
    }

    /*--END OF GETTERS AND SETTERS--*/


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        orderManagerRef = FindObjectOfType<OrderManager>();
        gameManagerRef = FindObjectOfType<GameManager>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Control look
        controlLook();

        // Control object interaction
        controlObjectInteraction();

        // Control pausing
        controlPausing();

        // Control game starting
        controlGameStarting();

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Cursor.visible)
            {
                MouseCursorVisiblityManager.hideMouseCursor();
            }
            else
            {
                MouseCursorVisiblityManager.showMouseCursor();
            }
        }
    }

    // Control look
    private void controlLook()
    {
        // If the current game state is active or starting
        if (GameStateCheckers.isGameActive(gameManagerRef.getCurrentGameState()) || GameStateCheckers.isGameStarting(gameManagerRef.getCurrentGameState()))
        {
            // Add to the rotation x and y values
            rotationX += Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
            rotationY += -Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

            // Clamp the rotation values
            rotationX = Mathf.Clamp(rotationX, -90, 90);
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            // Set the rotation of the player
            transform.eulerAngles = new Vector3(rotationY, rotationX, 0.0f);

        }
    }

    // Control object interaction
    private void controlObjectInteraction()
    {
        // If the current game state is active
        if (GameStateCheckers.isGameActive(gameManagerRef.getCurrentGameState()))
        {
            // The hit result of the ray cast
            RaycastHit rayCastHitResult;

            // Fire a ray cast
            bool wasRayCastHit = Physics.Raycast(transform.position, transform.forward, out rayCastHitResult, Mathf.Infinity);

            // If the left mouse button is pressed
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // If the raycast hit something
                if (wasRayCastHit)
                {
                    // If the object hit was a dispenser
                    if (rayCastHitResult.collider.CompareTag("Dispenser"))
                    {
                        Dispenser hitDispenser = rayCastHitResult.collider.GetComponent<Dispenser>();

                        // Tell the hit dispenser to dispenser their ingredient
                        hitDispenser.dispenseIngredient();
                    }

                    // If the object hit was the order check button
                    else if (rayCastHitResult.collider.CompareTag("OrderCheckButton"))
                    {
                        OrderCheckButton hitOrderCheckButton = rayCastHitResult.collider.GetComponent<OrderCheckButton>();

                        // Complete the current order
                        orderManagerRef.completeCurrentOrder();
                    }
                }
            }
        }
    }

    // Control pausing
    private void controlPausing()
    {
        // If the game is active
        if (GameStateCheckers.isGameActive(gameManagerRef.getCurrentGameState()))
        {
            // If the user presses the escape key
            // Pause the game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameManagerRef.pauseGame();
            }
        }
            
        // If the game is paused
        else if (GameStateCheckers.isGamePaused(gameManagerRef.getCurrentGameState()))
        {
            // If the user presses the escape key
            // Resume the game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameManagerRef.resumeGame();
            }
        }

    }

    // Control game starting
    private void controlGameStarting()
    {
        // If the game is starting
        if (GameStateCheckers.isGameStarting(gameManagerRef.getCurrentGameState()))
        {
            // If the user presses the escape key
            // Start the game
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameManagerRef.startGame();
            }
        }
    }

    // Increase the current score
    public void increaseCurrentScore(int increaseAmount)
    {
        setCurrentScore(getCurrentScore() + increaseAmount);
    }

    // Decrease the current score
    public void decreaseCurrentScore(int decreaseAmount)
    {
        setCurrentScore(getCurrentScore() - decreaseAmount);
    }
}
