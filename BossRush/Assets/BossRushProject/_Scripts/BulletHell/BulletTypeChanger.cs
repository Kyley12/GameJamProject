using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Bullet,
    Laser,
    Blaster,
    BlasterAndBullet
}

public class BulletTypeChanger : MonoBehaviour
{
    public static BulletType currentType = BulletType.Bullet;

    private void Update()
    {
        if(currentType == BulletType.Bullet)
        {
            gameObject.GetComponent<FireBullet>().enabled = true;
        }
        else if(currentType == BulletType.Laser)
        {
            Debug.Log("Changed type to laser."); 
        }
    }
}
