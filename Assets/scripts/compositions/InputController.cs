using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class InputController : MonoBehaviour
{

    private Movement movement;

    public static InputController control;

    public GameObject swingAttack;
    public float fireRate = 30;
    private float currentFireRate = 0;
    private Animator anim;

    private int moveState = 0; 

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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("HorizontalMove");
        float dirY = Input.GetAxisRaw("VerticalMove");
        movement.Move(dirX, dirY);

        if (dirX == 0 && dirY == 0) {
            anim.SetBool("isRunning", false);
        }
        else {
            anim.SetBool("isRunning", true);
        }

        dirX = Input.GetAxisRaw("HorizontalLook");
        dirY = Input.GetAxisRaw("VerticalLook");


        if (dirX > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            moveState = 1;
        }
        else if (dirY > 0) {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            moveState = 2;
        }
        else if (dirX < 0) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            moveState = 3;
        }
        else if (dirY < 0) {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            moveState = 4;
        }

        if (currentFireRate >= 0) {
            currentFireRate -= 60 * Time.deltaTime;
        }
        else {
            if (Input.GetButtonDown("Fire1") || dirX != 0 || dirY != 0) {
                currentFireRate = fireRate;
                if (moveState == 1) {
                    // Instantiate the projectile at the position and rotation of this transform
                    GameObject clone = Instantiate(swingAttack, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z));
                }
                else if (moveState == 2) {
                    // Instantiate the projectile at the position and rotation of this transform
                    GameObject clone = Instantiate(swingAttack, transform.position, Quaternion.Euler(0, 0, 90));
                }
                else if (moveState == 3) {
                    // Instantiate the projectile at the position and rotation of this transform
                    GameObject clone = Instantiate(swingAttack, transform.position, Quaternion.Euler(0, 180, 0));
                }
                else if (moveState == 4) {
                    // Instantiate the projectile at the position and rotation of this transform
                    GameObject clone = Instantiate(swingAttack, transform.position, Quaternion.Euler(0, 0, 270));
                }
            }
        }
    }
}
