using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class FarmerProfileManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField idInput;
    public TMP_InputField dayInput;
    public TMP_InputField monthInput;
    public TMP_InputField yearInput;

    public TMP_Text nameText; // inside NameRow
    public TMP_Text ageText;  // inside AgeRow
    public TMP_Text idText;   // inside IDRow
    public GameObject profilePanel;

    private FarmerProfile currentProfile;
    private const string ProfileKey = "FarmerProfile";

    void Start()
    {
        if (PlayerPrefs.HasKey(ProfileKey))
        {
            LoadProfile();

            if (TryParseBirthDate(currentProfile.birthDateCode, out _))
            {
                ShowProfile();
            }
            else
            {
                Debug.LogWarning("Stored birthdate is invalid. Skipping profile display.");
            }
        }
    }

    public void CreateProfile()
    {
        string name = nameInput.text.Trim();
        string id = idInput.text.Trim();

        if (!int.TryParse(dayInput.text.Trim(), out int day) ||
            !int.TryParse(monthInput.text.Trim(), out int month) ||
            !int.TryParse(yearInput.text.Trim(), out int year))
        {
            Debug.LogError("Please enter valid numeric values for day, month, and year.");
            return;
        }

        DateTime birthDate;
        try
        {
            birthDate = new DateTime(year, month, day);
        }
        catch
        {
            Debug.LogError("Invalid date. Please check the day/month/year values.");
            return;
        }

        long birthCode = long.Parse(birthDate.ToString("ddMMyyyy"));

        currentProfile = new FarmerProfile
        {
            farmerName = name,
            farmerId = id,
            birthDateCode = birthCode
        };

        SaveProfile();
        ShowProfile();

        SceneManager.LoadScene("BaseScene");
    }

    void SaveProfile()
    {
        string json = JsonUtility.ToJson(currentProfile);
        PlayerPrefs.SetString(ProfileKey, json);
        PlayerPrefs.Save();
    }

    public void LoadProfile()
    {
        string json = PlayerPrefs.GetString(ProfileKey);
        currentProfile = JsonUtility.FromJson<FarmerProfile>(json);
    }

    public void ShowProfile()
    {
        if (currentProfile == null || !TryParseBirthDate(currentProfile.birthDateCode, out DateTime birthDate))
        {
            Debug.LogWarning("Cannot show profile: missing or invalid birthdate.");
            nameText.text = "Invalid";
            ageText.text = "Invalid";
            idText.text = "Invalid";
            return;
        }

        string name = currentProfile.farmerName;
        string id = currentProfile.farmerId;
        int age = currentProfile.GetCurrentAge();
        bool isBirthday = currentProfile.IsBirthdayToday();

        nameText.text = $"<b>{name}</b>";
        ageText.text = isBirthday ? $"<b>{age}</b> 🎉 Happy Birthday!" : $"<b>{age}</b>";
        idText.text = $"<b>{id}</b>";

        if (profilePanel != null)
        {
            profilePanel.SetActive(true);
        }
    }

    private bool TryParseBirthDate(long birthLong, out DateTime birthDate)
    {
        birthDate = default;

        string raw = birthLong.ToString("D8");
        if (raw.Length != 8) return false;

        if (!int.TryParse(raw.Substring(0, 2), out int day)) return false;
        if (!int.TryParse(raw.Substring(2, 2), out int month)) return false;
        if (!int.TryParse(raw.Substring(4, 4), out int year)) return false;

        try
        {
            birthDate = new DateTime(year, month, day);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
