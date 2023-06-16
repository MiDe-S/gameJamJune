
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    private string[,] map = new string[,]
    {
        { null, null, null, null, null },
        { "FourSwarmRoom", null, "FourSwarmRoom", null, null },
        { "SpikeRoom", "SpikeRoom", "FourSwarmRoom", null, null },
        { null, null, "SpikeRoom", null, null },
        { null, null, null, null, null }
    };

    // temp measure
    private bool[,] clear_map = new bool[,]
    {
        { false, false, false, false, false},
        { false, false, false, false, false},
        { false, false, true, false, false},
        { false, false, false, false, false},
        { false, false, false, false, false}
    };

    int locX = 2;
    int locY = 2;

    public static gameManager control;

    void Awake()
    {
        //Let the gameobject persist over the scenes
        DontDestroyOnLoad(gameObject);
        //Check if the control instance is null
        if (control == null)
        {
            //This instance becomes the single instance available
            control = this;
        }
        //Otherwise check if the control instance is not this one
        else if (control != this)
        {
            //In case there is a different instance destroy this one.
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        int floorSize = 5; // must be odd number
        generateFloor(floorSize, floorSize);
        logMap();
        SceneManager.LoadScene(map[locY, locX]);
    }

    void logMap() {
        string output = "\n";
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++) {
                if (map[i, j] == null) {
                    output += "x";
                }
                else {
                    //output += map[i, j];
                    output += "o";
                }
            }
            output += "\n";
        }
        Debug.Log(output);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string convertLocToStr(int offsetX = 0, int offsetY = 0) {

        return (locX + offsetX).ToString() + (locY + offsetY).ToString();
    }

    
    private void generateFloor(int w, int h) {
        string[] rooms = new string[] {"FourSwarmRoom", "SpikeRoom"};

        int num_rooms = 1;

        locX = w / 2;
        locY = h / 2;

        map = new string[h,w]; // clear room


        map[locY, locX] = "StartRoom"; // starting room

        Queue<string> queue = new Queue<string>();
        queue.Enqueue(convertLocToStr());

        while (queue.Count > 0 || num_rooms < 3) {
            if (queue.Count != 0) {
                string currentLoc = queue.Dequeue();
                locX = (int)char.GetNumericValue(currentLoc[0]);
                locY = (int)char.GetNumericValue(currentLoc[1]);
            }

            string[] neighbors = new string[] { convertLocToStr(0, -1), convertLocToStr(1, 0), convertLocToStr(0, 1), convertLocToStr(-1, 0) };

            foreach (string n in neighbors) {
                int coinFlip = Random.Range(0,2);
                try {
                    if (coinFlip == 1) { }
                    else if (map[(int)char.GetNumericValue(n[1]), (int)char.GetNumericValue(n[0])] != null) { }
                    else if (getNumNeighbors(locX, locY) >= 2) { }
                    else {
                        int roomIndex = Random.Range(0, rooms.Length);
                        map[(int)char.GetNumericValue(n[1]), (int)char.GetNumericValue(n[0])] = rooms[roomIndex];

                        queue.Enqueue(n);
                        num_rooms += 1;
                    }
                }
                catch (System.IndexOutOfRangeException) {}
            }
        }
        // reset start location
        locX = w / 2;
        locY = h / 2;
    }

    int getNumNeighbors(int x, int y) {
        int neighbor = 0;
        try {
            if (map[locY-1, locX] != null) {
                neighbor += 1;
            }
        }
        catch (System.IndexOutOfRangeException) {}
        try {
            if (map[locY, locX+1] != null) {
                neighbor += 1;
            }
        }
        catch (System.IndexOutOfRangeException) {}
        try {
            if (map[locY+1, locX] != null) {
                neighbor += 1;
            }
        }
        catch (System.IndexOutOfRangeException) {}
        try {
            if (map[locY, locX-1] != null) {
                neighbor += 1;
            }
        }
        catch (System.IndexOutOfRangeException) {}

        return neighbor;
    }

    public void moveRoom(string direction) {
        // this should be changed
        clear_map[locY, locX] = true;
        if (direction == "NORTH") {
            locY -= 1;
        }
        else if (direction == "EAST") {
            locX += 1;
        }
        else if (direction == "SOUTH") {
            locY += 1;
        }
        else if (direction == "WEST") {
            locX -= 1;
        }
        SceneManager.LoadScene(map[locY, locX]);
    }

    public void loadDoorsCallback(GameObject room) {
        try {
            if (map[locY-1, locX] != null) {
                room.GetComponent<managerScript>().loadNorthDoor();
            }
        }
        catch (System.IndexOutOfRangeException) {}
        try {
            if (map[locY, locX+1] != null) {
                room.GetComponent<managerScript>().loadEastDoor();
            }
        }
        catch (System.IndexOutOfRangeException) {}
        try {
            if (map[locY+1, locX] != null) {
                room.GetComponent<managerScript>().loadSouthDoor();
            }
        }
        catch (System.IndexOutOfRangeException) {}
        try {
            if (map[locY, locX-1] != null) {
                room.GetComponent<managerScript>().loadWestDoor();
            }
        }
        catch (System.IndexOutOfRangeException) {}

        if (clear_map[locY, locX]) {
            room.GetComponent<managerScript>().roomCleared();
        }
    }
}
