using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public GameObject squarePrefab; // The prefab for the square button
    public Transform boardParent;   // The parent transform to hold the squares
    public Color selectedColor = Color.red;
    public int maxSelectableSquares = 5; // Set the maximum number of selectable squares

    private Button[,] squares;      // 2D array to hold the references to the square buttons
    private int selectedSquareCount = 0;

    void Start()
    {
        CreateBoard();
    }

    void CreateBoard()
    {
        squares = new Button[3, 3]; // Initialize the array

        // Loop to create a 3x3 grid of squares
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                // Instantiate a square button
                GameObject square = Instantiate(squarePrefab, boardParent);
                squares[row, col] = square.GetComponent<Button>(); // Store the reference

                // Set the position and name of the square
                square.transform.localPosition = new Vector3(col * 100, -row * 100, 0);
                square.name = "Square_" + row + "_" + col;

                // Attach a listener to handle square selection
                int rowIndex = row;
                int colIndex = col;
                squares[row, col].onClick.AddListener(() => SelectSquare(rowIndex, colIndex));
            }
        }
    }

    void SelectSquare(int row, int col)
    {
        // Check if the maximum number of selectable squares has been reached
        if (selectedSquareCount >= maxSelectableSquares)
        {
            Debug.Log("Maximum number of selectable squares reached.");
            return;
        }

        Debug.Log("Selected Square: " + row + ", " + col);
        // Add your logic for square selection here, e.g., change color
        squares[row, col].image.color = selectedColor;

        // Increment the counter
        selectedSquareCount++;
    }
}