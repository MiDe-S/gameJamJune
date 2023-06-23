using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(ProjectileShoot))]
public class InputController : MonoBehaviour
{

    private Movement movement;

    public static InputController control;

    private Animator anim;

    private int moveState = 0;

    public int projVelocity = 0;

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
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
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


        if (Input.GetButtonDown("Fire1") || dirX != 0 || dirY != 0) {
            if (moveState == 1) {
                gameObject.GetComponent<ProjectileShoot>().Shoot(Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z), new Vector2(dirX * projVelocity, dirY * projVelocity));
            }
            else if (moveState == 2) {
                gameObject.GetComponent<ProjectileShoot>().Shoot(Quaternion.Euler(0, 0, 90), new Vector2(dirX * projVelocity, dirY * projVelocity));
            }
            else if (moveState == 3) {
                gameObject.GetComponent<ProjectileShoot>().Shoot(Quaternion.Euler(0, 180, 0), new Vector2(dirX * projVelocity, dirY * projVelocity));
            }
            else if (moveState == 4) {
                gameObject.GetComponent<ProjectileShoot>().Shoot(Quaternion.Euler(0, 0, 270), new Vector2(dirX * projVelocity, dirY * projVelocity));
            }
        }
    }

    public void addProjSpeed(int speed) {
        projVelocity += speed;
    }
}
