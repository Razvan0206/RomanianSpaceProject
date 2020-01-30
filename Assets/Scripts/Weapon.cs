using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    private GameObject spawnedBullet;
    private GameObject[] enemiesInMap;

    [SerializeField] private Transform shotPos;
    private Transform nearestEnemyToScreenCentre;

    private float minDistance;

    private RaycastHit ray;

    private Vector3 direction;

    [SerializeField] private Vector2 aimAssistRect = new Vector2(500, 500);
    private Vector2 screenCentre;
    private Vector2 enemyPointOnScreen;
    public AudioSource BulletAudio;

    private void Start()
    {
        screenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
    }
    public void Shoot()
    {
        BulletAudio.Play();
        enemiesInMap = GameObject.FindGameObjectsWithTag("Enemy");
        minDistance = 9999;
        nearestEnemyToScreenCentre = null;
        foreach (GameObject enemy in enemiesInMap)
        {
            direction = enemy.transform.position - shotPos.transform.position;
            Physics.Raycast(shotPos.transform.position, direction, out ray, 50);
            enemyPointOnScreen = Camera.main.WorldToScreenPoint(ray.point);
            if (ray.point != null) Debug.Log(Camera.main.WorldToScreenPoint(ray.point));
            if (enemyPointOnScreen.x <= screenCentre.x + aimAssistRect.x / 2 &&
                enemyPointOnScreen.x >= screenCentre.x - aimAssistRect.x / 2 &&
                enemyPointOnScreen.y <= screenCentre.y + aimAssistRect.y / 2 &&
                enemyPointOnScreen.y >= screenCentre.y - aimAssistRect.y / 2)
            {
                if (Vector2.Distance(screenCentre, enemyPointOnScreen) < minDistance)
                {
                    minDistance = Vector2.Distance(screenCentre, enemyPointOnScreen);
                    nearestEnemyToScreenCentre = enemy.transform;
                }
            }
        }
        if (nearestEnemyToScreenCentre)
        {
            spawnedBullet = Instantiate(BulletPrefab, shotPos.transform.position, shotPos.transform.rotation);
            spawnedBullet.transform.forward = direction;
            return;
        }
        else spawnedBullet = Instantiate(BulletPrefab, shotPos.transform.position, shotPos.transform.rotation);
    }
}
