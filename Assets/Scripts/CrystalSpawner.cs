using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public static CrystalSpawner Instance;

    [Header("Crystal")]
    public GameObject crystalPrefab;

    private GameObject currentCrystal;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnCrystal();
    }

    void SpawnCrystal()
    {
        // Safety check
        if (currentCrystal != null)
            return;

        Vector3 spawnPos = new Vector3(
            Random.Range(-20f, 20f),
            0.5f,
            Random.Range(-20f, 20f));

        currentCrystal = Instantiate(crystalPrefab, spawnPos, Quaternion.identity);
    }

    public void CollectCrystal(GameObject crystal)
    {
        // Ignore invalid calls
        if (currentCrystal == null || crystal != currentCrystal)
            return;

        // Store reference and clear current crystal immediately
        GameObject oldCrystal = currentCrystal;
        currentCrystal = null;

        // Destroy old crystal
        Destroy(oldCrystal);

        // Increase score
        if (GameManager.Instance != null)
            GameManager.Instance.AddScore();

        // Spawn next crystal
        SpawnCrystal();
    }
}