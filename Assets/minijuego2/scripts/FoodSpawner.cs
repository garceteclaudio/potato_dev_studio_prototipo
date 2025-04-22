using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs; // Prefabs de comida para lanzar
    public float spawnInterval = 1.5f; // intervalo del respawn
    public float xRange = 5f; //rango en X

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnFood();
            timer = 0f;
        }
    }

    void SpawnFood()
    {
        // Elige una comida aleatoria
        int index = Random.Range(0, foodPrefabs.Length);
        GameObject food = Instantiate(foodPrefabs[index]);

        // posiciona la comida en una cordenada aleatoria en X
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);

        food.transform.position = spawnPosition;
    }
}
