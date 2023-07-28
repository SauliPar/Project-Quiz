using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : Singleton<SettingsManager>
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public GameObject GameModeMenu;
    public GameObject RulesMenu;

    private RoundAmountSelection.RoundAmount _selectedRounds;
    
    public void Initialize()
    {
        Debug.Log("Käytiin startissa");
        HideAllMenus();
        
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "MainMenuScene")
        {
            MainMenu.SetActive(true);
        }
    }

    public void SetGameRules(RoundAmountSelection.RoundAmount selectedRounds)
    {
        _selectedRounds = selectedRounds;
        
        GoToGame();
    }

    public int GetSelectedRounds()
     {
    //     var returnValue = 0;
    //     switch (_selectedRounds)
    //     {
    //         case RoundAmountSelection.RoundAmount.Fast:
    //             returnValue = 5;
    //             break;
    //         case RoundAmountSelection.RoundAmount.Medium:
    //             returnValue = 10;
    //             break;
    //         case RoundAmountSelection.RoundAmount.Long:
    //             returnValue = 15;
    //             break;
    //     }
        return (int)_selectedRounds;
    }

    public void PrintSelectedRounds()
    {
        if (_selectedRounds != null)
        {
            Debug.Log("HEI TWITCH CHATTI, SELECTED ROUNDS ON: "+ _selectedRounds);
        }
    }

    public void GoToSettingsMenu()
    {
        HideAllMenus();
        SettingsMenu.SetActive(true);
    }
 
    public void GoToGameModeMenu()
    {
        HideAllMenus();
        GameModeMenu.SetActive(true);
    }
    
    public void GoToRulesMenu()
    {
        HideAllMenus();
        RulesMenu.SetActive(true);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void GoToMainMenu()
    {
        HideAllMenus();
        MainMenu.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();    
    }

    public void HideAllMenus()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        GameModeMenu.SetActive(false);
        RulesMenu.SetActive(false);
    }
}
