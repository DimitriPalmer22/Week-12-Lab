using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Make a list of 15 random names
        List<string> names = new List<string>();
        
        for (int i = 0; i < 15; i++)
        {
            // Add a random name to the list of names
            names.Add(Task1.names[Random.Range(0, Task1.names.Length)]);
        }

        // Make hashset of the names
        HashSet<string> uniqueNames = new HashSet<string>();

        foreach (var currentName in names)
        {
            // Check if the name is already in the hashset
            if (!uniqueNames.Add(currentName))
                Debug.Log($"{currentName} is already in the hashset");
        }
        
        // Log the unique names in the hashset
        foreach (string currentName in uniqueNames)
            Debug.Log(currentName);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
