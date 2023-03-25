using UnityEngine;

public class NotesMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    public void OnBackClick()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}