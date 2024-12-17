using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField]
    private GameObject pooleBullet;
    private bool notEnoughBulletsInPool = true;

    public List<GameObject> bullets;

    private void Awake()
    {
        if (bulletPoolInstance == null)
        {
            bulletPoolInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetUp();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if(!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if(notEnoughBulletsInPool)
        {
            GameObject bullet = Instantiate(pooleBullet);
            bullet.SetActive(false);
            bullets.Add(bullet);
            return bullet;
        }

        return null;
    }

    private void SetUp()
    {
        bullets = new List<GameObject>();
    }

    public void ClearPool()
    {
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            if (bullets[i] != null && !bullets[i].activeInHierarchy)
            {
                Destroy(bullets[i]); // Destroy inactive bullets
                bullets.RemoveAt(i); // Remove from the list
            }
        }

        Debug.Log("Inactive bullets cleared from the pool.");
    }
}
