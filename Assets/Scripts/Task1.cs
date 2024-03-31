using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    public static string[] names =
    {
        "John", "Jane", "Jack",
        "Joe", "Jill", "Jack",
        "Alex", "Bob", "Bill",
        "Brenda", "Bobby", "Bella",
        "Carl", "Cathy", "Chris",
        "Cindy", "Cody", "Carmen",
        "David", "Daisy", "Dylan",
        "Diana", "Dennis", "Dolly",
        "Eddy", "Eva", "Eli",
        "Emily", "Ethan", "Ella",
        "Frank", "Fiona", "Felix",
    };

    public Queue<Player> logInQueue;

    public List<Player> loggedInPlayers;

    public Player PlayerCreator()
    {
        // This function will generate a player with a random first and last name
        string firstName = names[Random.Range(0, names.Length)];
        char lastName = (char) Random.Range('A', 'Z');

        return new Player(firstName, lastName);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TASK 1:");
        
        // Create the log in queue
        logInQueue = new Queue<Player>();

        // Log that the queue has been created
        Debug.Log("Log in queue created");

        // Add players to the queue
        for (int i = 0; i < 5; i++)
            logInQueue.Enqueue(PlayerCreator());

        // Log that the players have been added to the queue
        Debug.Log($"{logInQueue.Count} Players added to the queue");

        // Log the players in the queue
        foreach (Player player in logInQueue)
            Debug.Log($"{player.firstName} {player.lastName} is in the queue");

        // Create the list of logged in players
        loggedInPlayers = new List<Player>();

        // Add each player in the queue to the list of logged in players
        while (logInQueue.Count > 0)
        {
            var currentPerson = logInQueue.Dequeue();

            loggedInPlayers.Add(currentPerson);

            Debug.Log($"{currentPerson.firstName} {currentPerson.lastName} has logged in");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}