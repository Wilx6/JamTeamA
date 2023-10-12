using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeTrap : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] shoes;
    private float cooldownTimer;

    [Header("SFX")]
    [SerializeField] private AudioClip shoesound;

    private void Attack()
    {
        cooldownTimer = 0;

        SoundManager.instance.PlaySound(shoesound);
        shoes[FindShoe()].transform.position = firePoint.position;
        shoes[FindShoe()].GetComponent<EnemyProjectiles>().ActivateProjectile();
    }

    private int FindShoe()
    {
        for (int i = 0; i < shoes.Length; i++)
        {
            if (!shoes[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer > attackCD)
        {
            Attack();
        }
    }
}
