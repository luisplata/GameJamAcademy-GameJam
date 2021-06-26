using Cinemachine;
using UnityEngine;

public class Installer : MonoBehaviour
{
    private EmployeesFactory _factory;

    [SerializeField] private EmployeesConfiguration configuration;
    [SerializeField] private float speedPlayer;
    [SerializeField] private GameObject skillInstantiate;
    [SerializeField] private string employeeid;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject objetivePlayer;
    [SerializeField] private SpawnerOpponents spawner;

    private Employee _player;
    // Start is called before the first frame update
    void Start()
    {
        _factory = new EmployeesFactory(Instantiate(configuration));
        
        //player creating
        CreatingPlayer();
        
        ConfigureCamera();

        spawner.Configure(this);
    }

    private void ConfigureCamera()
    {
        virtualCamera.Follow = _player.transform;
        virtualCamera.LookAt = _player.transform;
    }

    private void CreatingPlayer()
    {
        var employeeBuilder = _factory.Create(employeeid);
        var mov = new PlayerMovement(speedPlayer);
        _player = employeeBuilder.WithMovement(mov).WithSkillDefault(skillInstantiate).Build();
        _player.tag = "Player";
        _player.name = "Player";
        Debug.Log($"objetivePlayer.transform.position {objetivePlayer.transform.position}");
        _player.SetObjetive(objetivePlayer.transform.position);
        _player.transform.position = Vector3.up * 5;
    }

    public IEmployee GetPlayer()
    {
        return _player;
    }
}