using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator anim;
    private Unit unit;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        unit = GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        ChooseAnimation(unit);
    }
    
    private void ChooseAnimation(Unit u)
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsMove", false);
        anim.SetBool("IsAttack", false);
        anim.SetBool("IsBuild", false);
        anim.SetBool("IsWorker", false);
        anim.SetBool("IsDeath", false);

        switch (u.State)
        {
            case UnitState.Idle:
                anim.SetBool("IsIdle", true);
                break;
            case UnitState.Move:
                anim.SetBool("IsMove", true);
                break;
            case UnitState.AttackUnit:
                anim.SetBool("IsAttack", true);
                break;
            case UnitState.MoveToBuild :
                anim.SetBool("IsMove", true);
                break;
            case UnitState.BuildProgress:
                anim.SetBool("IsBuild", true);
                break;
            case UnitState.MoveToResource:
                anim.SetBool("IsMove", true);
                break;
            case UnitState.Gather:
                anim.SetBool("IsWorker", true);
                break;
            case UnitState.DeliverToHQ:
                anim.SetBool("IsMove", true);
                break;
            case UnitState.StoreAtHQ:
                anim.SetBool("IsIdle", true);
                break;
            case UnitState.Die:
                anim.SetBool("IsDeath", true);
                break;
                
        }
    } // เพิ่มเมธอดในการจัดการอนิเมชั่น
}
