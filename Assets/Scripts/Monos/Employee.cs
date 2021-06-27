using System.Collections.Generic;
using UnityEngine;

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
        
        public void SetSkill(ISkill s)
        {
                _skill = s;
        }

        private void FixedUpdate()
        {
                if (_skill.HasPushSkill())
                {
                        _skill.ActionSkill();
                }

                _circumferenceOfEnemy.Rotate();
        }

        private void Update()
        {
                if (_actionToPlayer.CanInteractive() && _skill.HasPushSkill())
                {
                        _actionToPlayer.InteractiveToTheObject();
                        return;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                        LaunchTheBook();
                }
                _movement.Move();
                transform.position = rb.gameObject.transform.position;
        }

        public void ConvertAli(GameObject ali)
        {
                var aliance = ali.GetComponent<Employee>();
                aliance.SetComponents(new AliMovementHelp(_movement.GetSpeed()), aliance.GetSkill());
                Debug.Log("Convert to Ali");
        }

        public List<Employee> ListOfOpponents => _listOfOpponents;
        public string GetId()
        {
                return id.Value;
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
                instantiate.GetComponent<Rigidbody>().AddForce(Vector3.forward * force,ForceMode.Impulse);
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
                Debug.Log("Terminaste");
        }

        public void LaunchTheBook()
        {
                var bookInstantiate = Instantiate(book);
                bookInstantiate.transform.position = positionToSpawnBook.position;
                bookInstantiate.GetComponent<Rigidbody>().AddForce(Vector3.up * forceToLaunch);
        }

        public Transform GetPointForTheCamera()
        {
                return pointForTheCamera;
        }
}