using UnityEngine;

public class ColorLock : MonoBehaviour
{
   // Enum of colors
   public enum ObjectColor
    {
        Default,
        White,
        Black
    }

    // Array of 5 3D objects
    public GameObject[] objects;

    // Stores the current color state of each object
    private ObjectColor[] currentColors;

    // Secret winning pattern
    private ObjectColor[] winningPattern =
    {
        ObjectColor.White,
        ObjectColor.Black,
        ObjectColor.White,
        ObjectColor.Default,
        ObjectColor.Black
    };

    private void Start()
    {
        // Initialize current colors
        currentColors = new ObjectColor[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            currentColors[i] = ObjectColor.Default;
            ApplyColor(i);
        }
    }

    private void Update()
    {
        // Cube
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CycleColor(0);
        }

        // Sphere
        if (Input.GetKeyDown(KeyCode.W))
        {
            CycleColor(1);
        }

        // Capsule
        if (Input.GetKeyDown(KeyCode.E))
        {
            CycleColor(2);
        }

        // Cylinder
        if (Input.GetKeyDown(KeyCode.R))
        {
            CycleColor(3);
        }

        // Pill
        if (Input.GetKeyDown(KeyCode.T))
        {
            CycleColor(4);
        }

        CheckWin();
    }

    void CycleColor(int index)
    {
        //Change enum value
        switch (currentColors[index])
        {
            case ObjectColor.Default:
                currentColors[index] = ObjectColor.White;
                break;
            case ObjectColor.White:
                currentColors[index] = ObjectColor.Black;
                break;
            case ObjectColor.Black:
                currentColors[index] = ObjectColor.Default;
                break;
        }
        ApplyColor(index);
    }

    void ApplyColor(int index)
    {
        Color selectedColor = Color.gray;
        
        // Switch color based on enum
        switch (currentColors[index])
        {
            case ObjectColor.Default:
                selectedColor = Color.gray;
                break;
            case ObjectColor.White:
                selectedColor = Color.white;
                break;
            case ObjectColor.Black:
                selectedColor = Color.black;
                break;
        }

        objects[index].GetComponent<Renderer>().material.color = selectedColor;
    }

    void CheckWin()
    {
        bool win = true;

        for (int i = 0; i < currentColors.Length; i++)
        {
            if (currentColors[i] != winningPattern[i])
            {
                win = false;
                break;
            }
        }

        if (win)
        {
            Debug.Log("Correct Combination. Unlocked Level!");
        }
    }
}
