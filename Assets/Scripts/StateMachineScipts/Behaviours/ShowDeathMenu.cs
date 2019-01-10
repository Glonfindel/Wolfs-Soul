using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowDeathMenuBehaviour : IBehaviour
{

    private GameObject deathMenu;
    private bool active;
    public IStateMachine Machine { get; set; }

    public ShowDeathMenuBehaviour(bool active)
    {
        deathMenu = GameObject.FindObjectOfType<UIManager>().DeathPanel;
        this.active=active;
    }

    public void Enter()
    {
        deathMenu.SetActive(active);
        EventSystem.current.SetSelectedGameObject(deathMenu.GetComponentInChildren<Selectable>().gameObject);
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
    }
}
