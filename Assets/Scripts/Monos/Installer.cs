using Cinemachine;
using UnityEngine;
using UnityEngine.Assertions;

public class Installer : MonoBehaviour
{
    private EmployeesFactory _factory;

    [SerializeField] private EmployeesConfiguration configuration;
    [SerializeField] private float speedPlayer;
    [SerializeField] private GameObject skillInstantiate;
    [SerializeField] private EmployeeScriptable employeeid, artist, technicalArtist;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject objetivePlayer;
    [SerializeField] private SpawnerOpponents spawner;
    [SerializeField] private GeometricsFigureForTheGraphicConfiguration graphicConfiguration, tecnicalArtis;
    [SerializeField] private GameObject prefabToBellseboss;
    [SerializeField] private float force;

    private Employee _player;
    private GameObject _bellsebossInstantiate;

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
        virtualCamera.Follow = _player.GetPointForTheCamera();
        virtualCamera.LookAt = _player.GetPointForTheCamera();
    }

    private void CreatingPlayer()
    {
        if (PlayerPrefs.GetInt("character") == 1)
        {
            employeeid = artist;
        }
        else if(PlayerPrefs.GetInt("character") == 0)
        {
            employeeid = technicalArtist;
        }
        var employeeBuilder = _factory.Create(employeeid);
        var mov = new PlayerMovement(speedPlayer);
        Skill skillEpecific = null;
        if (employeeid == artist)
        {
            skillEpecific = new SkillForGraphic(Instantiate(graphicConfiguration), force);
        }else if (employeeid == technicalArtist)
        {
            skillEpecific = new SkillEpecificTechnicalArtist(Instantiate(tecnicalArtis));
        }
        Assert.IsNotNull(skillEpecific, "el objecto de skill no debe de ir nulo");
        _player = employeeBuilder.WithMovement(mov).WithSkill(skillEpecific).Build();
        skillEpecific.Configure(_player);
        _player.SetSkill(skillEpecific);
        _player.tag = "Player";
        _player.name = "Player";
        //Debug.Log($"objetivePlayer.transform.position {objetivePlayer.transform.position}");
        _player.SetObjetive(objetivePlayer.transform.position);
        _player.transform.position = transform.position;
        _player.IsThePlayer();
    }

    public IEmployee GetPlayer()
    {
        return _player;
    }

    public EmployeeScriptable GetArtistId()
    {
        return artist;
    }

    public EmployeeScriptable GetTechnicalArtistId()
    {
        return technicalArtist;
    }

    public GeometricsFigureForTheGraphicConfiguration GetGraphicConfiguration()
    {
        return graphicConfiguration;
    }

    public float GetForce()
    {
        return force;
    }

    public GeometricsFigureForTheGraphicConfiguration GetTechnicalArtisConfig()
    {
        return tecnicalArtis;
    }
}