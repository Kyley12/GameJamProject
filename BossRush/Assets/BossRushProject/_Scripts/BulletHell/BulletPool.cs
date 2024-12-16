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
        bulletPoolInstance = this;
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
}
