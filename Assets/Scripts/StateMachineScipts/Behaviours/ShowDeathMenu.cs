using UnityEngine;

public class ShowDeathMenuBehaviour : IBehaviour
{

    private GameObject deathMenu;
    private bool active;
    public IStateMachine Machine { get; set; }

    public ShowDeathMenuBehaviour(bool active)
    {
        deathMenu = GameObject.FindObjectOfType<PauseManager>().DeathPanel;
        this.active=active;
    }

    public void Enter()
    {
        deathMenu.SetActive(active);
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
    }
}
