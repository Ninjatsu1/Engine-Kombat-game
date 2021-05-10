using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage = 10;
    private void Start()
    {
        Invoke("DestroyProjectile", bulletLifeTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<CharacterStats>().TakeDamage(damage);
        }
        else if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.GetComponent<CharacterStats>().TakeDamage(damage);
        }
        DestroyProjectile();
    }
    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
 
}
