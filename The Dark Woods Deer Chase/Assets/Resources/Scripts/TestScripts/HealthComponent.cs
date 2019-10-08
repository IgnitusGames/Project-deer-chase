using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// HealthComponent.cs
// Attach this to any character that has health and can die
// (be it player or enemy or a destructible chest)
public sealed class HealthComponent : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onDied;
    public bool take_damage;

    private float health;
    private float maximumHealth;
    public float enemy_curr_health;
    public float enemy_max_health;
    public float take_dmg_time;
    private void Start()
    {
        enemy_curr_health = enemy_max_health;
    }
    //public float InitialHealth
    //{
    //    get { return this.initialHealth; }
    //    set { this.initialHealth = Mathf.Max(0f, value); }
    //}

    //public float InitialMaximumHealth
    //{
    //    get { return this.initialMaximumHealth; }
    //    set { this.initialMaximumHealth = Mathf.Max(0f, value); }
    //}

    //public float Health
    //{
    //    get { return this.health; }
    //    set { this.health = Mathf.Clamp(value, 0f, this.MaximumHealth); }
    //}

    //public float MaximumHealth
    //{
    //    get { return this.maximumHealth; }
    //    set { this.maximumHealth = Mathf.Max(0f, value); }
    //}


    public UnityEvent DiedEvent
    {
        get { return this.onDied; }
    }
   public void Die()
    {
        Destroy(gameObject);
    }

    //private void OnEnable()
    //{
    //    this.Health = this.InitialHealth;
    //    this.MaximumHealth = this.InitialMaximumHealth;
    //}

    private void OnDiedEvent()
    {
        var handler = this.onDied;
        if (handler != null)
        {
            handler.Invoke();
        }
    }


    public void TakeDamage(float damage)
    {
        enemy_curr_health -= damage;
        if(damage > 0)
        {
            take_damage = true;

           
        }
       
        // Has the player just died?
        if (enemy_curr_health <= 0)
        {
            this.OnDiedEvent();
            print("dood");
            Destroy(gameObject);
        }
   
    }
}