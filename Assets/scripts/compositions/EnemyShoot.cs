using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileShoot))]
public class EnemyShoot : MonoBehaviour
{
    private GameObject player;
    private ProjectileShoot shooter;
    public Quaternion rotation = Quaternion.Euler(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        shooter = gameObject.GetComponent<ProjectileShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooter.canShoot() && player != null) {
            shooter.Shoot(rotation, new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y));
        }
    }
}
