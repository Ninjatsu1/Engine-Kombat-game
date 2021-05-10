using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement settings")]
    public float speed; //Movement speed
    public float stoppingDistance; //Distance to stop
    public float retreatDistance; //When enemy should back away
    public bool isMovingEnemy;
    public Transform player;
    [Header("Projectile settings")]
    public GameObject projectile;
    public float projectileForce = 20f;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public Transform shotPoint;
    public float distanceBetweenPlayer = 5f;
    [Header("Rotation settings")]
    public bool hasRotation;
    //public GameObject objectToRotate;
    public float rotationSpeed;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        //Check how far player is
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) //Move towards if stopping distance is greater
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        }
        if (Vector2.Distance(transform.position, player.position) < distanceBetweenPlayer)
        {
            if (timeBetweenShots <= 0)
            {
                GameObject bullet = Instantiate(projectile, shotPoint.transform.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(shotPoint.transform.up * projectileForce, ForceMode2D.Impulse);
                timeBetweenShots = startTimeBetweenShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
      
        RotateTower();
    }
    private void RotateTower()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
