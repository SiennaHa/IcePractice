using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed;
    Rigidbody2D rb;

    [SerializeField] List<Enemy> enemy = new List<Enemy>();

    [SerializeField] int damageAmount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = enemy.Count - 1; i >= 0; i--)
            {
                enemy[i].TakeDamage(damageAmount, i, this);
            }
        }
    }

    public void RemoveEnemy(int id)
    {
        enemy.RemoveAt(id);
    }

    public void AddEnemy(Enemy e)
    {
        enemy.Add(e);
    }


    // Update is called once per frame
    void FixedUpdate()   {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveDirection = (Vector2.right * horizontal) + (Vector2.up * vertical);
        moveDirection *= speed * Time.deltaTime;
        
        rb.linearVelocity = moveDirection;
    }
}
