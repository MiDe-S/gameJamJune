using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int max_health = 100;

    private int current_health;

    public float invuln_period = 30;
    private float invuln_time = 0;

    private SpriteRenderer mySprite;

    public List<HealthEffect> effects;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invuln_time > 0) {
            invuln_time -= 60 * Time.deltaTime;
        }

        animationUpdate();
        
    }

    public void takeDamage(int damage) {
        if (invuln_time <= 0) {
            current_health -= damage;
            invuln_time = invuln_period;

            for (int i = 0; i < effects.Count; i++) {
                effects[i].onHealthChange(current_health);
            }

            if (current_health <= 0) {
                Destroy(gameObject);
            }
        }
    }

    private void animationUpdate() {
        if (invuln_time > 0) {
            mySprite.color = new Color(255, 0, 0);
        }
        else {
            mySprite.color = new Color(255, 255, 255);
        }
    }

    public int getHealth() {
        return current_health * 100 / max_health;
    }
}
