using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerScript : MonoBehaviour
{
    static readonly Vector2 NORTH_DOOR = new Vector2(0, 5);
    static readonly Vector2 EAST_DOOR = new Vector2(10, 0);
    static readonly Vector2 SOUTH_DOOR = new Vector2(0, -5);
    static readonly Vector2 WEST_DOOR = new Vector2(-10, 0);
    static readonly Vector2 CENTER_DOOR = new Vector2(0, 0);


    public GameObject door;

    private gameManager gameController;

    private int enemyCount = 0;
    private bool isRoomCleared = false;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("GameController") == null) {
            Debug.Log("No GC");
        }
        else {
            gameController = GameObject.FindWithTag("GameController").GetComponent<gameManager>();
            gameController.loadDoorsCallback(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRoomCleared) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0) {
                roomCleared();
            }
        }
    }

    public void loadAllDoors() {
        loadNorthDoor();
        loadEastDoor();
        loadSouthDoor();
        loadWestDoor();
    }

    public void loadNorthDoor(bool isBossDoor = false) {
        GameObject north_door = Instantiate(door, NORTH_DOOR, Quaternion.Euler(0, 0, 0));
        if (isBossDoor) {
            makeBossDoor(north_door);
        }
    }

    public void loadEastDoor(bool isBossDoor = false) {
        GameObject east_door = Instantiate(door, EAST_DOOR, Quaternion.Euler(0, 0, -90));
        if (isBossDoor) {
            makeBossDoor(east_door);
        }
    }

    public void loadSouthDoor(bool isBossDoor = false) {
        GameObject south_door = Instantiate(door, SOUTH_DOOR, Quaternion.Euler(0, 0, 180));
        if (isBossDoor) {
            makeBossDoor(south_door);
        }
    }

    public void loadWestDoor(bool isBossDoor = false) {
        GameObject west_door = Instantiate(door, WEST_DOOR, Quaternion.Euler(0, 0, 90));
        if (isBossDoor) {
            makeBossDoor(west_door);
        }
    }

    public void loadCenterDoor(bool isBossDoor = true) {
        GameObject center_door = Instantiate(door, CENTER_DOOR, Quaternion.Euler(0, 0, 0));
        if (isBossDoor) {
            makeBossDoor(center_door);
        }
    }

    void makeBossDoor(GameObject door) {
        door.GetComponent<SpriteRenderer>().color = new Color(215, 0, 0);
    }

    public void increaseEnemyCount(int x = 1) {
        enemyCount += x;
    }

    public void decreaseEnemyCount(int x = 1) {
        enemyCount -= x;
        if (enemyCount <= 0) {
            roomCleared();
        }
    }

    public void roomCleared() {
        isRoomCleared = true;
        Debug.Log("Room Cleared");
        GameObject[] exits = GameObject.FindGameObjectsWithTag("Exit");
        for (int i = 0; i < exits.Length; i++) {
            exits[i].GetComponent<doorLogicScript>().openExit();
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++) {
            Destroy(enemies[i]);
        }
    }

    public void exitEntered(Vector2 exit_position) {
        GameObject player = GameObject.FindWithTag("Player");
        if (exit_position == NORTH_DOOR) {
            gameController.moveRoom("NORTH");
            player.transform.position = (SOUTH_DOOR + new Vector2(0, 1));
        }
        else if (exit_position == EAST_DOOR) {
            gameController.moveRoom("EAST");
            player.transform.position = (WEST_DOOR + new Vector2(1, 0));
        }
        else if (exit_position == SOUTH_DOOR) {
            gameController.moveRoom("SOUTH");
            player.transform.position = (NORTH_DOOR + new Vector2(0, -1));
        }
        else if (exit_position == WEST_DOOR) {
            gameController.moveRoom("WEST");
            player.transform.position = (EAST_DOOR + new Vector2(-1, 0));
        }
        else if (exit_position == CENTER_DOOR) {
            gameController.Restart();
            player.transform.position = (CENTER_DOOR);
        }

    }
}
