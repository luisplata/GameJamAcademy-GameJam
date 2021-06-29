using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EmployeeId
{
        artist,
        technicalArtist
}
public class Employee : MonoBehaviour, IEmployee
{ 
        [SerializeField] public EmployeeScriptable id;
        [SerializeField] private float tolerance; 
        [SerializeField]private List<Employee> _listOfOpponents;
        [SerializeField] private GameObject book;
        [SerializeField] private float forceToLaunch;
        [SerializeField] private Transform positionToSpawnBook;
        [SerializeField] private InteractToTheAmbient interactToTheAmbient;
        [SerializeField] private EmployeeMono employeeMono;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator anim;
        [SerializeField] private Transform pointToSpawnSkill;
        [SerializeField] private Transform pointForTheCamera;
        private float timeToColdDownToUseSkill;
        private float detaTimeLocal;
        private IMovement _movement;
        private ISkill _skill;
        private ICircumferenceOfEnemy _circumferenceOfEnemy;
        private IActionToPlayer _actionToPlayer;
        private Vector3 _objective;
        
        
        private float totalDistance, variantDistance;
        private int parts = 5;
        private float partToDistance;

        public bool IsEnemy { get; private set; }


        private void Awake()
        {
                _circumferenceOfEnemy = GetComponent<ICircumferenceOfEnemy>();
                _circumferenceOfEnemy.Configure(this);
                _listOfOpponents = new List<Employee>();
                interactToTheAmbient.Configure(this);
                _actionToPlayer = new ActionToPlayer(this);
                employeeMono.Config(this);
                timeToColdDownToUseSkill = 10;
                _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void PartDistance()
        {
                partToDistance = totalDistance / parts;
        }

        public void TotalLayersInMusic()
        {
                var totalLayers = CalculateTotalLayers();

                ServiceLocator.Instance.GetService<IMusic>().MusicForLayers(totalLayers);
        }

        private int CalculateTotalLayers()
        {
                var distance = (int) (totalDistance / partToDistance);
                var calculateDistance = (int) (CalculateDistance() / partToDistance);
                var totalLayers = distance - calculateDistance;
                if (totalLayers <= 0)
                {
                        totalLayers = 1;
                }
                return totalLayers;
        }

        private float CalculateDistance()
        {
                return (_objective - transform.position).sqrMagnitude;
        }

        public string Id => id.Value;

        public void SetComponents(IMovement mov, ISkill sk)
        {
                _movement = mov;
                _skill = sk;
                _skill.Configure(this);
                _movement.Configure(this);
                IsEnemy = _movement.IsEnemy();
        }

        public ISkill GetSkill()
        {
                return _skill;
        }
        public void StartToSkill()
        {
                Destroy(gameObject,10);
        }

        public void SetPointToGo(Vector3 tranformToGoOpponent)
        {
                _navMeshAgent.destination = tranformToGoOpponent;
                var velocityNav = _navMeshAgent.velocity;
                Rotating(velocityNav.x, velocityNav.z);
        }

        public void SetSkill(ISkill s)
        {
                _skill = s;
        }

        private float deltaTimeLocalToSkill;
        private float timeToSpawn = 10;
        private void FixedUpdate()
        {
                if (_actionToPlayer.CanInteractive() && _skill.HasPushSkill() && isThePlayer)
                {
                        _actionToPlayer.InteractiveToTheObject();
                        return;
                }
                if (_skill.HasPushSkill() && isThePlayer)
                {
                        _skill.ActionSkill();
                }

                if (!isThePlayer)
                {
                        deltaTimeLocalToSkill += Time.deltaTime;
                        if (deltaTimeLocalToSkill >= timeToSpawn)
                        {
                                deltaTimeLocalToSkill = 0;
                                _skill.ActionSkill();
                                timeToSpawn = Random.Range(timeToSpawn, timeToSpawn + 10);
                                if (!IsEnemy)
                                {
                                        ServiceLocator.Instance.GetService<ISoundToCrash>().SoundToSupport();
                                }
                        }
                }

                _circumferenceOfEnemy.Rotate();
        }

        private void Update()
        {
                if (IsEnemy)
                {
                        anim.SetFloat("speed", rb.velocity.magnitude);               
                }
                else if(isThePlayer)
                {
                        TotalLayersInMusic();
                }
                _movement.Move();
                //transform.position = rb.gameObject.transform.position;
        }

        public void ConvertAli(GameObject ali)
        {
                var aliance = ali.GetComponent<Employee>();
                var findWithTag = GameObject.FindWithTag("Opponent");
                var skillForTheAli = new SkillForTheAli(aliance.GetSkill());
                aliance.SetComponents(new AliMovementHelp(_movement.GetSpeed(),findWithTag), skillForTheAli);
        }

        public List<Employee> ListOfOpponents => _listOfOpponents;
        public string GetId()
        {
                return id.Value;
        }

        private GameObject targetForFind;
        public GameObject GetTargetForFind()
        {
                return targetForFind;
        }

        private void Rotating (float horizontal, float vertical)
        {
                Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, 100 * Time.deltaTime);
                rb.MoveRotation(newRotation);
        }

        private Vector3 lastInput;
        public void Move(Vector3 input)
        {
                if (input.sqrMagnitude != 0)
                {
                        lastInput = input;
                }
                Rotating(lastInput.x, lastInput.z);
                input.y = rb.velocity.y;
                rb.velocity = input * Time.deltaTime;
                anim.SetFloat("speed", input.magnitude);
        }

        public float GetHorizontal()
        {
                return Input.GetAxis("Horizontal");
        }

        public float GetVertical()
        {
                return Input.GetAxis("Vertical");
        }

        public bool GetInputSkill()
        {
                if (!IsEnemy) return Input.GetKeyDown(KeyCode.Space);
                detaTimeLocal += Time.deltaTime;
                if (!(detaTimeLocal >= timeToColdDownToUseSkill)) return false;
                detaTimeLocal = 0;
                return true;
        }

        public Vector3 GetPosition()
        {
                return gameObject.transform.position;
        }

        public Vector3 GetObjective()
        {
                return _objective;
        }

        public Vector3 GetTargetToOpponents()
        {
                return _circumferenceOfEnemy.GetPointToOpponents();
        }

        public List<Employee> GetListToOtherOpponents()
        {
                return _listOfOpponents;
        }

        private GameObject figure;
        private float force;
        private bool isThePlayer;
        private NavMeshAgent _navMeshAgent;

        public void CreateObject(GameObject figure, float force)
        {
                this.figure = figure;
                this.force = force;
                anim.SetTrigger("power");
        }

        private void CreateObjectFinishAnimation()
        {
                var instantiate = Instantiate(figure);
                instantiate.transform.position = pointToSpawnSkill.position;
                instantiate.GetComponent<Rigidbody>().AddForce(transform.forward * force,ForceMode.Impulse);
                if (IsEnemy)
                {
                        instantiate.gameObject.AddComponent<InteractiveToDestroyed>();
                }
                else
                {
                        instantiate.AddComponent<CollisionToDestroyedOtherElements>();
                }
        }

        public void CreateObject(GameObject figuree)
        {
                this.figure = figuree;
                anim.SetTrigger("power");
        }

        public void TechnicalArtistCreatedFigureToFinishAnimation()
        {
                var instantiate = Instantiate(figure);
                instantiate.transform.position = pointToSpawnSkill.transform.position;
                if (IsEnemy)
                {
                        instantiate.AddComponent<InteractiveToDestroyed>();
                }
                else
                {
                        instantiate.AddComponent<CollisionToDestroyedOtherElements>();
                }
        }

        public void CanInteractive(GameObject otherGameObject)
        {
                _actionToPlayer.CanInteractive(otherGameObject);
        }

        public void CantInteractive()
        {
                _actionToPlayer.CantInteractive();
        }

        public void SetObjetive(Vector3 objetivePlayer)
        {
                _objective = objetivePlayer;
        }

        public Vector3 GetPositionToSpawn()
        {
                return GetPosition() + Vector3.forward;
        }

        public void DeliveryToBook()
        {
                anim.SetTrigger("give");
                ServiceLocator.Instance.GetService<ITriggerSoundEffect>().PlayShortSoundOnce("Music_Win_bpm162_4-4");
                ServiceLocator.Instance.GetService<IMusic>().StopMusicForLayers();

        }

        public void FinishAnimationToFinishGame()
        {
                ServiceLocator.Instance.GetService<ITriggerSoundEffect>().StopSFX();
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }

        public void LaunchTheBook()
        {
                //var bookInstantiate = Instantiate(book);
                //bookInstantiate.transform.position = positionToSpawnBook.position;
                //bookInstantiate.GetComponent<Rigidbody>().AddForce(Vector3.up * forceToLaunch);
        }

        public Transform GetPointForTheCamera()
        {
                return pointForTheCamera;
        }

        public void IsThePlayer()
        {
                isThePlayer = true;
                _navMeshAgent.enabled = false;
        }

        public void CalculatingDistanceForLayers(Transform pointMoreFar)
        {
                totalDistance = (_objective - pointMoreFar.position).sqrMagnitude;
                PartDistance();
                ServiceLocator.Instance.GetService<IMusic>().StartMusicForLayers(5);
                TotalLayersInMusic();
        }
}