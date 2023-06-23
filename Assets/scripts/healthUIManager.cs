using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthUIManager : MonoBehaviour
{

    [SerializeField] 
    private TMP_Text _health;

    public static healthUIManager control;

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
            Destroy(gameObject);
        }
    }

    public void updateHealth(int health) {
        Debug.Log("manager");
        _health.text = health.ToString();
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
