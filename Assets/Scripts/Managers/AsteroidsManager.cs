using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    // Possible types of asteroids
    public enum AsteroidType
    {
        Normal,
        Super
    }

    // Margin distances for spawning asteroids
    private const float SpawnMargin_X = 2f;
    private const float SpawnMargin_Y = 1f;
    private const float SpawnMargin_Z = 2f;

    // Maximum positive force applied to asteroids created after
    // splitting a super asteroid
    private const float MaxForce = 30f;

    // Asteroids parent gameobject
    private GameObject asteroidsParent;

    // Asteroids spawn limits
    private float spawnPosMin_X;
    private float spawnPosMax_X;
    private float spawnPos_Y;
    private float spawnPosMin_Z;
    private float spawnPosMax_Z;

    // Asteroids prefabs
    [Header("Game Asteroids")]
    public GameObject[] gameAsteroids;

    // Asteroids explosions
    [Header("Asteroids Explosions")]
    public GameObject[] asteroidsExplosions = new GameObject[System.Enum.GetNames(typeof(AsteroidType)).Length];

    // Waiting time before spawning a new asteroid
    [Header("Asteroids Spawn")]
    public float spawnTime = 1f;
    public float superAsteroidProb = 0.2f;

    #region Singleton
    public static AsteroidsManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

	void Start()
    {
        // Checking available game asteroids
        if (gameAsteroids.Length == 0)
        {
            Debug.LogWarning("No game asteroids available!");
            return;
        }

        // Asteroids parent gameobject
        asteroidsParent = GameObject.FindWithTag(Tags.Asteroids);

        // Asteroids spawn limits
        Camera mainCamera  = Camera.main;
        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth  = cameraHeight * mainCamera.aspect;
        
        spawnPosMax_X = cameraWidth / 2 - SpawnMargin_X;
        spawnPosMin_X = -spawnPosMax_X;

        spawnPos_Y = cameraHeight / 2 + SpawnMargin_Y;

        GameObject screenLimit = GameObject.FindWithTag(Tags.ScreenLimit);
        spawnPosMax_Z = screenLimit.transform.localScale.z / 2 - SpawnMargin_Z;
        spawnPosMin_Z = -spawnPosMax_Z;

        StartCoroutine(GenerateAsteroids());
	}

    /**
     * Asteroids generation coroutine.
     */
    IEnumerator GenerateAsteroids()
    {
        while (!GameManager.instance.GameOver)
        {
            // Wait...
            yield return new WaitForSeconds(spawnTime);

            // ...and generate the next asteroid
            GenerateAsteroid();
        }
    }

    /**
     * Generate one asteroid.
     */
    private GameObject GenerateAsteroid()
    {
        // Asteroid type
        AsteroidType type = GetRandomAsteroidType();

        // Spawn position
        float spawnPos_X = GetRandomPosition_X();
        float spawnPos_Z = GetRandomPosition_Z();
        Vector3 spawnPosition = new Vector3(spawnPos_X, spawnPos_Y, spawnPos_Z);

        return GenerateAsteroid(type, spawnPosition);
    }

    private GameObject GenerateAsteroid(AsteroidType astType, Vector3 astPosition)
    {
        // Asteroid prefab
        GameObject asteroid = GetRandomAsteroid();

        return InstantiateAsteroid(asteroid, astType, astPosition);
    }
    
    /**
     * Instantiate one asteroid according to the given parameters.
     */
    private GameObject InstantiateAsteroid(GameObject astPrefab, AsteroidType astType, Vector3 astPosition)
    {
        // GameObject instance
        GameObject asteroidInstance = (GameObject)Instantiate(astPrefab, astPosition, Quaternion.identity);
        asteroidInstance.transform.parent = asteroidsParent.transform;

        // Additional components
        switch (astType)
        {
            case AsteroidType.Normal:
                asteroidInstance.AddComponent<AsteroidScale>();
                asteroidInstance.AddComponent<ClickForDestroy>();
                break;
            case AsteroidType.Super:
                asteroidInstance.AddComponent<AsteroidScaleLarge>();
                asteroidInstance.AddComponent<ClickForSplit>();
                break;
        }

        return asteroidInstance;
    }

    /**
     * Return the explosion gameobject for an asteroid type.
     */
    public GameObject GetAsteroidExplosion(AsteroidType astType)
    {
        return asteroidsExplosions[(int)astType];
    }

    /**
     * Return a random asteroid prefab.
     */
    private GameObject GetRandomAsteroid()
    {
        int numGameAsteroids = gameAsteroids.Length;
        int randomAsteroid = Random.Range(0, numGameAsteroids);

        return gameAsteroids[randomAsteroid];
    }

    /**
     * Return a random asteroid type.
     */
    private AsteroidType GetRandomAsteroidType()
    {
        AsteroidType type = (Random.value < superAsteroidProb) ? AsteroidType.Super : AsteroidType.Normal;
        return type;
    }

    /**
     * Return a random position for the X axis.
     */
    private float GetRandomPosition_X()
    {
        return Random.Range(spawnPosMin_X, spawnPosMax_X);
    }

    /**
     * Return a random position for the Z axis.
     */
    private float GetRandomPosition_Z()
    {
        return Random.Range(spawnPosMin_Z, spawnPosMax_Z);
    }

    /**
     * Asteroid distroyed by the player.
     */
    public void AsteroidDistroyed()
    {
        // Increase game score
        GameManager.instance.IncreaseScore();
    }

    /**
     * Asteroid split into pieces by the player.
     */
    public void AsteroidSplit(Vector3 astPosition, int pieces = 2)
    {
        // Generate new asteroids
        for (int i = 0; i < pieces; ++i)
        {
            GameObject asteroid = GenerateAsteroid(AsteroidType.Normal, astPosition);

            float forceToAdd = Random.Range(-MaxForce, MaxForce);
            asteroid.GetComponent<Rigidbody>().AddForce(forceToAdd, 0f, 0f);
        }
    }

}
