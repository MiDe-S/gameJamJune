using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate = 10;
    private float currentFireRate = 0;
    private float projSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireRate > 0) {
            currentFireRate -= 60 * Time.deltaTime;
        }
    }

    public void Shoot(Quaternion rotation, Vector2 velocity) {
        if (currentFireRate <= 0) {
            currentFireRate = fireRate;
            GameObject clone = Instantiate(projectile, transform.position, rotation);

            float normalizer = System.Math.Max(System.Math.Abs(velocity.x), System.Math.Abs(velocity.y));
            float dirX = normalizer != 0 ? velocity.x / normalizer : 0;
            float dirY = normalizer != 0 ? velocity.y / normalizer : 0;

            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(dirX * projSpeed, dirY  * projSpeed);
        }
    }

    public void multiplyFireRate(float multiplier) {
        fireRate = fireRate * multiplier;
    }

    public bool canShoot() {
        return currentFireRate <= 0;
    }

    public void setProj(GameObject newProj) {
        projectile = newProj;
        gameObject.GetComponent<InputController>().projVelocity = 20;
    }
}
