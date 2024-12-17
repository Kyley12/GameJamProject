using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    None,
    Bullet,
    Laser,
    Blaster,
    BlasterAndBullet,
    Special,
    SpeicalAndBullet
}

public class BulletTypeChanger : MonoBehaviour
{
    public static BulletType currentType = BulletType.Bullet;

    private void Update()
    {
        if(currentType == BulletType.None)
        {
            gameObject.GetComponent<FireBullet>().enabled = false;
            gameObject.GetComponent<DoubleSprial>().enabled = false;
        }
        else if(currentType == BulletType.Bullet)
        {
            gameObject.GetComponent<FireBullet>().enabled = true;
            gameObject.GetComponent<DoubleSprial>().enabled = false;
        }
        else if(currentType == BulletType.Laser)
        {
            Debug.Log("Changed type to laser."); 
        }
        else if(currentType == BulletType.Special)
        {
            gameObject.GetComponent<FireBullet>().enabled = false;
            gameObject.GetComponent<DoubleSprial>().enabled = true;
        }
    }
}
