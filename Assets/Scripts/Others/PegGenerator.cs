using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PegGenerator : MonoBehaviour
{

    #region VariablesAndParameters
    [Header("Peg Generation Parameters")]
    [SerializeField] GameObject pegPrefab = null;
    [SerializeField] [Tooltip("Greater offset means more randomness")] float maximumOffset = 0.5f;
    [SerializeField] [Tooltip("Number Of Pegs From Left To Right")] int pegCountX = 3;
    [SerializeField] [Tooltip("Number Of Pegs From Bottom To Top")] int pegCountY = 7;

    [SerializeField] float pegSpawnerDelay = 1.5f;

    private Vector2 topRightWP;  //Top Right World Point
    private List<Vector2> spawnPoints;

    private Coroutine pegSpawner;

    [SerializeField] float timeSinceLevelLoad;   //For Testing Purposes -> To set peg spawner delay
    #endregion

    private void Start() {
        SpawnInitialPegs();
        pegSpawner = StartCoroutine(PegSpawner());
    }

    #region StartingPegs
    private void SpawnInitialPegs() {
        topRightWP = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float pegDistanceX = (topRightWP.x * 2) / (pegCountX + 1);
        float pegDistanceY = (topRightWP.y * 2) / (pegCountY + 1);

        SetPegSpawnerLocations(pegDistanceX, pegDistanceY);   //Call to set up Coroutine Spawn Locations

        List<Vector2> initialPegs = new List<Vector2>();

        for (int j = 0; j < (pegCountY + 3) / 2; j++) {
            for (int i = 1; i < pegCountX + 1; i++) {
                Vector2 pos = new Vector2(-topRightWP.x + (i * pegDistanceX), -topRightWP.y + (2 * j * pegDistanceY));
                initialPegs.Add(pos);
            }
        }

        pegDistanceX = (topRightWP.x * 2) / pegCountX;

        for (int j = 0; j < (pegCountY + 3) / 2; j++) {
            for (int i = 1; i < pegCountX; i++) {
                Vector2 pos = new Vector2(-topRightWP.x + (i * pegDistanceX), -topRightWP.y + (2 * j * pegDistanceY) + (pegDistanceY));
                initialPegs.Add(pos);
            }
        }

        InitializePegs(initialPegs);
    }

    private void InitializePegs(List<Vector2> initialPegs) {
        foreach (Vector2 pos in initialPegs) {
            SpawnPeg(pos);
        }
    }
    #endregion

    #region IndividualPegInitialization
    private void SpawnPeg(Vector2 position) {
        GameObject peg = Instantiate(pegPrefab, position, Quaternion.identity) as GameObject;
        peg.transform.parent = gameObject.transform;
        OffsetGeneratedPeg(peg);
    }

    private void OffsetGeneratedPeg(GameObject peg) {
        float xOffset = Random.Range(-maximumOffset, maximumOffset);
        float yOffset = Random.Range(-maximumOffset, maximumOffset);
        peg.transform.position = new Vector2(peg.transform.position.x + xOffset, peg.transform.position.y + yOffset);
    }
    #endregion

    #region PegSpawningOverTime
    private void SetPegSpawnerLocations(float pegDistanceX, float pegDistanceY) {
        spawnPoints = new List<Vector2>();

        for (int i = 1; i < pegCountX + 1; i++) {
            Vector2 pos = new Vector2(-topRightWP.x + (i * pegDistanceX), topRightWP.y + pegDistanceY);
            spawnPoints.Add(pos);
        }

        pegDistanceX = (topRightWP.x * 2) / pegCountX;

        for (int i = 1; i < pegCountX; i++) {
            Vector2 pos = new Vector2(-topRightWP.x + (i * pegDistanceX), topRightWP.y + (2 * pegDistanceY));
            spawnPoints.Add(pos);
        }
    }

    private IEnumerator PegSpawner() {
        while (true) {
            SpawnNextPegBatch();
            yield return new WaitForSeconds(pegSpawnerDelay);
        }
    }

    private void SpawnNextPegBatch() {

        float cameraOffset = Camera.main.transform.position.y;

        foreach(Vector2 pos in spawnPoints) {
            SpawnPeg(new Vector2(pos.x, pos.y + cameraOffset));
        }
    }

    public void StopSpawningPegs() {
        StopCoroutine(pegSpawner);
    }
    #endregion

    private void Update() {
        timeSinceLevelLoad = Time.timeSinceLevelLoad;
    }
}
