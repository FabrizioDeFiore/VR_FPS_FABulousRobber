using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CopStateId{
    ChasePlayer,
    Death,
    Idle,
    AttackPlayer
}
public interface CopsState {
    CopStateId GetId();
    void Enter(CopsAgent cop);
    void Update(CopsAgent cop);
    void Exit(CopsAgent cop);

} 
