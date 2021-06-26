using System;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour, IEmployee
{
        [SerializeField] protected string id;
        [SerializeField] private float tolerance; 
        [SerializeField]private List<Employee> _listOfOponents;
        [SerializeField] private GameObject book;
        [SerializeField] private float forceToLaunch;
        [SerializeField] private Transform positionToSpawnBook;
        [SerializeField] private InteractToTheAmbient interactToTheAmbient;
        private IMovement _movement;
        private ISkill _skill;
        private ICircumferenceOfEnemy _circumferenceOfEnemy;
        private IActionToPlayer _actionToPlayer;
        private Rigidbody rb;
        private Vector3 _objective;

        private void Awake()
        {
                rb = GetComponent<Rigidbody>();
                _circumferenceOfEnemy = GetComponent<ICircumferenceOfEnemy>();
                _circumferenceOfEnemy.Configure(this);
                _listOfOponents = new List<Employee>();
                interactToTheAmbient.Configure(this);
                _actionToPlayer = new ActionToPlayer(this);
        }

        public string Id => id;

        public void SetComponents(IMovement mov, ISkill sk)
        {
                _movement = mov;
                _skill = sk;
                _skill.Configure(this);
                _movement.Configure(this);
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
        }

        public void ConvertAli()
        {
                throw new NotImplementedException();
        }

        public void Move(Vector3 input)
        {
                rb.velocity = input;
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
                return Input.GetKeyDown(KeyCode.Space);
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
                return _listOfOponents;
        }

        public void CreateObject(GameObject figure, float force)
        {
                var instantiate = Instantiate(figure);
                instantiate.transform.position = GetPosition() + Vector3.forward;
                instantiate.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * force);
        }

        public void CreateObject(GameObject figure, Vector3 positionToSpawnVFX)
        {
                var instantiate = Instantiate(figure);
                instantiate.transform.position = positionToSpawnVFX;
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

        private void OnTriggerEnter(Collider other)
        {
                if (other.gameObject.CompareTag("Opponent"))
                {
                        _listOfOponents.Add(other.gameObject.GetComponent<Employee>());
                }
        }

        private void OnTriggerExit(Collider other)
        {
                if (other.gameObject.CompareTag("Opponent"))
                {
                        _listOfOponents.Remove(other.gameObject.GetComponent<Employee>());
                }
        }

        public Vector3 GetPositionToSpawn()
        {
                return GetPosition() + Vector3.forward;
        }

        private void OnCollisionEnter(Collision other)
        {
                if (other.gameObject.CompareTag("Bullet"))
                {
                        LaunchTheBook();
                }

                if (other.gameObject.CompareTag("Book"))
                {
                        Destroy(other.gameObject);
                }
        }

        public void DeliveryToBook()
        {
                throw new NotImplementedException();
        }

        private void LaunchTheBook()
        {
                var bookInstantiate = Instantiate(book);
                bookInstantiate.transform.position = positionToSpawnBook.position;
                bookInstantiate.GetComponent<Rigidbody>().AddForce(Vector3.up * forceToLaunch);
        }
}