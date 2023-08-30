using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClanAllianceDashboard : MonoBehaviour
{
    [SerializeField] private ClanAllianceTemplate _allianceTemplatePrebaf;
    [SerializeField] private ClanAllianceRequestTemplate _allianceRequestTEmplatePrebaf;
    [SerializeField] private Transform _allianceListTransform;
    [SerializeField] private Transform _allianceRequestListTransform;

    public void UpdateAllianceList()
    {
        ClearAllianceList();
        // foreach(Character request in _requestList)
        // {
        //     Instantiate(_allianceTemplatePrebaf, _allianceListTransform);
        // }
    }

    public void ClearAllianceList()
    {
        foreach(Transform request in _allianceListTransform)
        {
            Destroy(request.gameObject);
        }
    }

    public void UpdateAllianceRequestList()
    {
        ClearAllianceList();
        // foreach(Character request in _requestList)
        // {
        //     Instantiate(_allianceTemplatePrebaf, _allianceListTransform);
        // }
    }

    public void ClearAllianceRequestList()
    {
        foreach(Transform request in _allianceRequestListTransform)
        {
            Destroy(request.gameObject);
        }
    }

}
