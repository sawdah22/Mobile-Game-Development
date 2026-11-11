using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject mushroomBuddyPrefab;
    public GameObject hoodedAdventurerPrefab;
    public GameObject forestSpiritPrefab;

    void Start()
    {
        int selectedChartacter = PlayerPrefs.GetInt("SelectedCharacter", 0);

        GameObject choosenPrefab;

        switch (selectedChartacter)
        {
            case 0:
                choosenPrefab = mushroomBuddyPrefab;
                break;
            case 1:
                choosenPrefab = hoodedAdventurerPrefab;
                break;
            case 2:
                choosenPrefab = forestSpiritPrefab;
                break;
            default:
                choosenPrefab = mushroomBuddyPrefab;
                break;
        }

        Instantiate(choosenPrefab, transform.position, Quaternion.identity);
    }
}
