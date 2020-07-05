using UnityEngine;

public class GameFlow : MonoBehaviour
{

    private GameObject activeScene;
    public GameObject player;
    public GameObject gem;
    private bool isInstantiate = false;
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(1);
    }

    public GameObject GetActiveScene()
    {
        return activeScene;
    }

    public void LoadLevel(int i)
    {
        Destroy(activeScene);

        GameObject scenePrefab = Resources.Load<GameObject>("Level" + i);
        activeScene = GameObject.Instantiate(scenePrefab) as GameObject;
        gem = GameObject.Instantiate(gem) as GameObject;
        gem.SetActive(true);


        loadPlayer();
        player.GetComponent<PlayerJumpMovement>().ResetDoubleJumpPowerUp();
    }

    void loadPlayer()
    {
        if (isInstantiate == false)
        {
            player = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            isInstantiate = true;
        }
        GameObject SpawnPoint = activeScene.transform.Find("SpawnPoint").gameObject;
        Vector3 offset = new Vector3(0, 1, 0);
        player.transform.position = SpawnPoint.transform.position + offset;

    }


}


