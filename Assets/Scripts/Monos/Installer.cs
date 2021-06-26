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

    private Employee _player;
    // Start is called before the first frame update
    void Start()
    {
        _factory = new EmployeesFactory(Instantiate(configuration));
        //player creating
        var employeeBuilder = _factory.Create(employeeid);
        var mov = new PlayerMovement(speedPlayer);
        _player = employeeBuilder.WithMovement(mov).WithSkillDefault(skillInstantiate).Build();
        _player.transform.position = Vector3.up * 5;

        //TODO lo que necesites del player
        virtualCamera.Follow = _player.transform;
        virtualCamera.LookAt = _player.transform;
    }
}