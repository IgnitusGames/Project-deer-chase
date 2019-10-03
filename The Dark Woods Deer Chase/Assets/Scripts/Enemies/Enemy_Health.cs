using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy_Health : MonoBehaviour
{
    public int enemy_curr_health;
    public int enemy_max_health;
    [SerializeField]
    private UnityEvent onDied;

    private void Start()
    {
        enemy_curr_health = enemy_max_health;
    }


    // Update is called once per frame
    void Update()
    {
       if (gameObject.transform.position.y <-50 || enemy_curr_health <= 0)
        {
            Destroy(gameObject);
        }
        if (enemy_curr_health > enemy_max_health)
        {
            enemy_curr_health = enemy_max_health;
        }


    }

    public UnityEvent DiedEvent
    {
        get { return this.onDied; }
    }
    public void OnDiedEvent()
    {
        var handler = this.onDied;
        if (handler != null)
        {
            handler.Invoke();
        }
    }
    public void EnemyDamage(int enemydmg)
    {
        enemy_curr_health -= enemydmg;
        if (Mathf.Approximately(this.enemy_curr_health, 0f))
        {
            this.OnDiedEvent();
        }
    }
}
