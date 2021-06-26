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
    [SerializeField] private GeometricsFigureForTheGraphicConfiguration graphicConfiguration, tecnicalArtis;
    [SerializeField] private float force;

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
        var skillEpecificTechnicalArtist = new SkillEpecificTechnicalArtist(Instantiate(tecnicalArtis));
        _player = employeeBuilder.WithMovement(mov).WithSkill(skillEpecificTechnicalArtist).Build();
        skillEpecificTechnicalArtist.SetPositionToSpawnVFX(_player.GetPositionToSpawn());
        _player.SetSkill(skillEpecificTechnicalArtist);
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