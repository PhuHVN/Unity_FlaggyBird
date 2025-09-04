using UnityEngine;

public class PipeSpawnerHaviours : MonoBehaviour
{
    [SerializeField] private GameObject _pipe;
    [SerializeField] private float _timeSpawn = 2f;
    private float _minY = 0.2f;
    private float _maxY = -0.5f;
    private float _timeDes = 5f;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > _timeSpawn)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float randowY = Random.Range(_maxY, _minY);
        Vector3 spawnPos = new Vector3(transform.position.x, randowY, 0);
        GameObject spw = Instantiate(_pipe,spawnPos, Quaternion.identity);

        Destroy(spw, _timeDes);
    }
}
