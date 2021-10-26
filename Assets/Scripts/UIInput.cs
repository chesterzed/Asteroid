using UnityEngine;

[RequireComponent(typeof(UIController))]
public class UIInput : MonoBehaviour
{
    private UIController ui;
    public bool ShowMenu = true;

    private void Start()
    {
        ui = GetComponent<UIController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu = !ShowMenu;
            ui.ShowMenu(ShowMenu, true);
        }
    }
}
