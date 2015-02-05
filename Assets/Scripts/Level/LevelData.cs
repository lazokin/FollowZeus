using UnityEngine;
using System.Collections;

public class LevelData : MonoBehaviour
{
    public int GridSize = 10;

    public GameObject[] PreyArray { get; set; }
    public GameObject[] PredatorArray { get; set; }
    public GameObject[] SafeZoneArray { get; set; }

    public Graph Graph { get; set; }
    public NodeMap NodeMap { get; set; }
    public bool[,] GoNoGoMatrix { get; set; }

    static public int ammoStrike;
    static public int ammoBolt;
    static public int lostNumberOfPrey;
    static public int savedNumberOfPrey;
    static public int startNumberOfPrey;

    public Texture deadPrey;
    public Texture savedPrey;
    public Texture strike;
    public Texture bolt;
    public Font greekFont;

    void Start()
    {
        SafeZoneArray = GameObject.FindGameObjectsWithTag("SafeZone");
        startNumberOfPrey = GameObject.FindGameObjectsWithTag("Prey").Length;
        ammoStrike = GameObject.FindGameObjectsWithTag("Predator").Length / 2;
        ammoBolt = GameObject.FindGameObjectsWithTag("Predator").Length / 2;
        lostNumberOfPrey = 0;
        savedNumberOfPrey = 0;
    }

    void Update()
    {
        PreyArray = GameObject.FindGameObjectsWithTag("Prey");
        PredatorArray = GameObject.FindGameObjectsWithTag("Predator");
    }

    void OnGUI() {
        GUIStyle style = new GUIStyle();
        style.fontSize = 25;
        style.normal.textColor = Color.white;
        style.font = greekFont;
        //Saved Prey Score
        GUI.Label(new Rect(20, 75, 20, 20), "" + savedNumberOfPrey, style);
        GUI.DrawTexture(new Rect(40, 70, 40, 30), savedPrey, ScaleMode.ScaleToFit, true, 1.0F);
        //Dead Prey Score
        GUI.Label(new Rect(20, 115, 20, 20), "" + lostNumberOfPrey, style);
        GUI.DrawTexture(new Rect(40, 110, 40, 30), deadPrey, ScaleMode.ScaleToFit, true, 1.0F);
        //AmmoStrike left
        GUI.Label(new Rect(20, 203, 20, 20), "" + ammoStrike, style);
        GUI.DrawTexture(new Rect(40, 200, 37, 27), strike, ScaleMode.ScaleToFit, true, 1.0F);
        //AmmoBolt left
        GUI.Label(new Rect(20, 243, 20, 20), "" + ammoBolt, style);
        GUI.DrawTexture(new Rect(40, 240, 40, 30), bolt, ScaleMode.ScaleToFit, true, 1.0F);
    }
}
