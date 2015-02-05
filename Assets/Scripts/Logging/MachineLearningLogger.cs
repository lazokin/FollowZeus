using UnityEngine;
using System.Collections;

public class MachineLearningLogger
{
    // File for logs
    System.IO.StreamWriter file;

    // Attributes of log data
    PlayerController playerController;

    // Constructor
    public MachineLearningLogger()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Log Bolt attack
    public void LogBolt()
    {
        file = new System.IO.StreamWriter("ML_LogData.txt", true);
        string logString =
            "BOLT," +
            HasBolts() +
            "," +
            HasStrikes() +
            "," +
            HasFollowers() +
            "," +
            overHalfPreySaved() +
            "," +
            overHalfPreyLost() +
            "\n";
        Debug.Log(logString);
        file.WriteLine(logString);
        file.Close();
    }

    // Log Strike attack
    public void LogStrike()
    {
        file = new System.IO.StreamWriter("ML_LogData.txt", true);
        string logString =
            "STRIKE," +
            HasBolts() +
            "," +
            HasStrikes() +
            "," +
            HasFollowers() +
            "," +
            overHalfPreySaved() +
            "," +
            overHalfPreyLost() +
            "\n";
        Debug.Log(logString);
        file.WriteLine(logString);
        file.Close();
    }

    private bool HasBolts()
    {
        return (LevelData.ammoBolt > 0) ? true : false;
    }

    private bool HasStrikes()
    {
        return (LevelData.ammoStrike > 0) ? true : false;
    }

    private bool HasFollowers()
    {
        return (playerController.NumberOfFollowers > 0) ? true : false;
    }

    private bool overHalfPreySaved()
    {
        return (LevelData.savedNumberOfPrey > LevelData.startNumberOfPrey / 2);
    }

    private bool overHalfPreyLost()
    {
        return (LevelData.lostNumberOfPrey > LevelData.startNumberOfPrey / 2);
    }

}
