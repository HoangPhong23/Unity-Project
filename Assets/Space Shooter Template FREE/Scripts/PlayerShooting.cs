using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float shootingInterval = 0.1f;

    // Part 5: sound when shooting
    public AudioClip shootSound;
    private AudioSource audioSource;

    private float lastBulletTime;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastBulletTime > shootingInterval)
            {
                ShootBullet();
                lastBulletTime = Time.time;
            }
        }
    }

    private void ShootBullet()
    {
        if (bulletPrefabs != null)
            Instantiate(bulletPrefabs, transform.position, transform.rotation);

        if (shootSound != null && audioSource != null)
            audioSource.PlayOneShot(shootSound);
    }
}