using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject inputPanel;
    public GameObject profilePanel;

    public Button newGameButton;
    public Button continueButton;
    public Button resetProfileButton; // Hidden from UI

    public FarmerProfileManager profileManager;

    private const string ProfileKey = "FarmerProfile";

    void Start()
    {
        mainMenuPanel.SetActive(true);
        inputPanel.SetActive(false);
        profilePanel.SetActive(true);

        bool hasProfile = PlayerPrefs.HasKey(ProfileKey);

        newGameButton.gameObject.SetActive(!hasProfile);
        continueButton.gameObject.SetActive(hasProfile);

        // ✅ Hide reset button from user
        resetProfileButton.gameObject.SetActive(false);

        if (hasProfile)
        {
            profileManager.LoadProfile();
            profileManager.ShowProfile();
        }

        newGameButton.onClick.AddListener(OnNewGameClicked);
        continueButton.onClick.AddListener(OnContinueClicked);
        resetProfileButton.onClick.AddListener(OnResetProfileClicked); // Still wired up
    }

    public void OnNewGameClicked()
    {
        mainMenuPanel.SetActive(false);
        inputPanel.SetActive(true);
    }

    public void OnContinueClicked()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void OnResetProfileClicked()
    {
        PlayerPrefs.DeleteKey(ProfileKey);
        PlayerPrefs.Save();

        newGameButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        profilePanel.SetActive(false);
        inputPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

        Debug.Log("Profile deleted. Ready for new game.");
    }

 // JUST FOR TESTING 
    void Update()
{
    if (Input.GetKeyDown(KeyCode.R))
    {
        OnResetProfileClicked();
    }
}

}



