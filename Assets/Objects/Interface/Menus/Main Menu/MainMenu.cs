using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float buttonMargin = 50;

    [SerializeField] float buttonWidth = 500;
    [SerializeField] float buttonHeight = 100;

    [SerializeField] Texture FairyFoxyLogo;
    [SerializeField] GUISkin skin;

    string newGameScene = "PrototypeScene";

    enum Menu { main, options_main };
    [SerializeField] Menu currentMenu = Menu.main;

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.DrawTexture(new Rect(10, 5, 400, 300), FairyFoxyLogo);
        GUI.BeginGroup(new Rect(50, 340, buttonWidth, (buttonHeight + buttonMargin) * 3));


        switch (currentMenu)
        {
            case Menu.main:
                if (GUI.Button(new Rect(0, 0, buttonWidth, buttonHeight), "New Game"))
                {
                    SceneManager.LoadScene(newGameScene);
                }
                if (GUI.Button(new Rect(0, buttonHeight + buttonMargin, buttonWidth, buttonHeight), "Options"))
                {
                    currentMenu = Menu.options_main;
                }
                if (GUI.Button(new Rect(0, (buttonHeight + buttonMargin) * 2, buttonWidth, buttonHeight), "Exit"))
                {
                    Application.Quit(); //|Works only in a build.
                }
                break;

            case Menu.options_main:
                if (GUI.Button(new Rect(0, 0, buttonWidth, buttonHeight), "Controls"))
                {

                }

                if (GUI.Button(new Rect(0, buttonHeight + buttonMargin, buttonWidth, buttonHeight), "BACK"))
                {
                    currentMenu = Menu.main;
                }

                break;
        }

        GUI.EndGroup();
    }

    void Start()
    {
        buttonWidth = (buttonWidth * Screen.width) / 1920;
        buttonHeight = (buttonHeight * Screen.height) / 1080;
        buttonMargin = (buttonMargin * Screen.height) / 1080;
    }

}