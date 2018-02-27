
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


 public class AIVO:MonoBehaviour
 {
     public float value;
     public NavMeshAgent NV;
     public Animator Ani;
     [Range(0,100)]
     public int CurrentHp;

     public Transform eyes;
     public float lookRange;
     public float LookSphereCastRadius;
     [HideInInspector]public Transform Target;
     public float AttackDistance;
     public List<Transform> WayPointList;
     public int AttackCD;
 }

