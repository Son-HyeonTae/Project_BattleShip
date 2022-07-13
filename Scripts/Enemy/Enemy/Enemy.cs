using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int scorePoint = 100;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private GameObject[] itemPrefabs;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);

            OnDie();
        }
    }

    public void OnDie()
    {
        playerController.Score += scorePoint;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        SpawnItem();

        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        int spawnItem = Random.Range(0, 100);
        if (spawnItem <= 1)
        {
            Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        }
        else if (spawnItem <= 2)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
        else if (spawnItem <= 3)
        {
            Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
        }
    }
}