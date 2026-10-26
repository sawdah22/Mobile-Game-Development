using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject characterPreviewPanel;
    public Image characterPreviewImage;
    public TMP_Text characterPreviewName;

    public Sprite mushroomBuddySprite;
    public Sprite hoodedAdventurerSprite;
    public Sprite forestSpiritSprite;

    private int selectedCharacter = 0;

    public void SelectMushroomBuddy()
    {
        selectedCharacter = 0;
        characterPreviewImage.sprite = mushroomBuddySprite;
        characterPreviewName.text = "MUSHROOM BUDDY";
        characterPreviewPanel.SetActive(true);
    }

    public void SelectHoodedAdventurer()
    {
        selectedCharacter = 1;
        characterPreviewImage.sprite = hoodedAdventurerSprite;
        characterPreviewName.text = "HOODED ADVENTURER";
        characterPreviewPanel.SetActive(true);
    }
    public void SelectForestSpirit()
    {
        selectedCharacter = 2;
        characterPreviewImage.sprite = forestSpiritSprite;
        characterPreviewName.text = "FOREST SPIRIT";
        characterPreviewPanel.SetActive(true);
    }

    public void BackToCharacterSelection()
    {
        characterPreviewPanel.SetActive(false);
    }

    public void ConfirmCharacterSelection()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Level01");
    }
}
