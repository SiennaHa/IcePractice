using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int hp;
    [SerializeField] Animator anim;

    public void TakeDamage(int damageAmount, int id, Player player)
    {
        hp -= damageAmount;
        anim.SetTrigger("Hit");

        if (hp <= 0)
        {
            player.RemoveEnemy(id);
            Destroy(transform.parent.gameObject);
        }
    }

}
