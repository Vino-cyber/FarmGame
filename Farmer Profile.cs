using UnityEngine;
using System;

[System.Serializable]
public class FarmerProfile
{
    public string farmerName;
    public string farmerId;
    public long birthDateCode; // Format: ddMMyyyy as long (e.g., 17091995)

    /// <summary>
    /// Calculates the current age based on the birthDateCode.
    /// Returns -1 if the code is malformed or invalid.
    /// </summary>
    public int GetCurrentAge()
    {
        if (!TryParseBirthDate(out DateTime birth))
        {
            Debug.LogWarning($"Invalid birthDateCode: '{birthDateCode}'. Expected format is ddMMyyyy.");
            return -1;
        }

        DateTime today = DateTime.Today;
        int age = today.Year - birth.Year;

        if (today.Month < birth.Month || (today.Month == birth.Month && today.Day < birth.Day))
            age--;

        return age;
    }

    /// <summary>
    /// Checks if today matches the birth day and month.
    /// Returns false if the birthDateCode is invalid.
    /// </summary>
    public bool IsBirthdayToday()
    {
        if (!TryParseBirthDate(out DateTime birth))
            return false;

        DateTime today = DateTime.Today;
        return birth.Day == today.Day && birth.Month == today.Month;
    }

    /// <summary>
    /// Converts the birthDateCode into a DateTime object.
    /// </summary>
    private bool TryParseBirthDate(out DateTime birthDate)
    {
        birthDate = default;

        string raw = birthDateCode.ToString("D8"); // Ensure 8 digits
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

    /// <summary>
    /// Returns the formatted birthdate string (dd-MM-yyyy) or "Invalid" if parsing fails.
    /// </summary>
    public string GetFormattedBirthDate()
    {
        return TryParseBirthDate(out DateTime birth)
            ? birth.ToString("dd-MM-yyyy")
            : "Invalid";
    }
}
