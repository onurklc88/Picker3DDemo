using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerCollisions : MonoBehaviour
{
    [SerializeField] private LayerMask _collectibleLayerMask;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _finishMask;
    private RaycastHit _raycastHit;

    private void ApplyForceToCollectibles()
    {
      if (CheckInSightRange().Length == 0) return;
        
          for (int i = 0; i < CheckInSightRange().Length; i++)
               CheckInSightRange()[i].transform.GetComponent<Rigidbody>().AddForce(transform.forward * 5f, ForceMode.Impulse);
          
    }

    private Collider[] CheckInSightRange()
    {
        return Physics.OverlapSphere(transform.position + transform.forward * 1.3f, 1.5f, _collectibleLayerMask);
    }

    public void CheckGroundLayer()
    {

        if (Physics.Raycast(transform.position + transform.forward * 2f, -transform.up, 2f, _groundMask)) return;
        else
        {
            ApplyForceToCollectibles();
            EventLibrary.OnLevelPhaseChange.Invoke(GameStates.GamePhase.LevelStop);
        }
       
       
    }
    public bool CheckLevelFinishLayer()
    {

        if (Physics.Raycast(transform.position + transform.forward * 2f, -transform.up, 2f, _finishMask))
            return true;
        else
            return false;
   }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * 1.3f, 1.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + transform.forward * 2f, -transform.up);
    }

}
