using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class InputController : MonoBehaviour
{

    private Movement movement;

    public static InputController control;

    public GameObject swingAttack;

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
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        movement.Move(dirX, dirY);

        if (dirX > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (dirY > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (dirX < 0) {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (dirY < 0) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetButtonDown("Fire1")) {
            // Instantiate the projectile at the position and rotation of this transform
            GameObject clone = Instantiate(swingAttack, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 90));
        }
    }
}
