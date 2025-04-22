using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs; // Array de prefabs de comida que se pueden generar
    public float spawnInterval = 1.5f; // Tiempo entre cada aparici�n de comida
    public float xRange = 5f; // Rango horizontal en el que puede aparecer la comida
    public float offsetY = 3f; // Altura adicional para que la comida aparezca m�s arriba y caiga

    private float timer; // Temporizador interno para controlar el intervalo

    void Update()
    {
        // Acumulamos el tiempo que pasa en cada frame
        timer += Time.deltaTime;

        // Si pas� suficiente tiempo, generamos una nueva comida
        if (timer >= spawnInterval)
        {
            SpawnFood(); // Llama a la funci�n que instancia la comida
            timer = 0f;  // Reinicia el temporizador
        }
    }

    void SpawnFood()
    {
        // Elige un prefab aleatorio del array
        int index = Random.Range(0, foodPrefabs.Length);
        GameObject food = Instantiate(foodPrefabs[index]);

        // Calcula una posici�n X aleatoria dentro del rango permitido
        float randomX = Random.Range(-xRange, xRange);

        // Genera la posici�n de aparici�n, con una Y m�s alta para simular la ca�da
        Vector3 spawnPosition = new Vector3(transform.position.x + randomX, transform.position.y + offsetY, transform.position.z);

        // Coloca el objeto instanciado en la posici�n calculada
        food.transform.position = spawnPosition;
    }
}
