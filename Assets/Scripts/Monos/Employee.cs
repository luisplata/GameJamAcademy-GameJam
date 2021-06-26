﻿using System;
using UnityEngine;

public class Employee : MonoBehaviour, IEmployee
{
        [SerializeField] protected string id;
        [SerializeField] private float tolerance; 
        private IMovement _movement;
        private ISkill _skill;
        private ICircumferenceOfEnemy _circumferenceOfEnemy;

        private Rigidbody rb;
        private Vector3 _objective;

        private void Awake()
        {
                rb = GetComponent<Rigidbody>();
                _circumferenceOfEnemy = GetComponent<ICircumferenceOfEnemy>();
                _circumferenceOfEnemy.Configure(this);
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
                _movement.Move();
        }

        public void Move(Vector3 input)
        {
                rb.velocity = input;
                //rb.MovePosition(transform.position + input * Time.deltaTime);
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

        public void SetObjetive(Vector3 objetivePlayer)
        {
                _objective = objetivePlayer;
        }
}