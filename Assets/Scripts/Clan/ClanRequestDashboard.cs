using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClanRequestDashboard : MonoBehaviour
{
    [SerializeField] private ClanJoinRequestTemplate _requestTemplatePrebaf;
    [SerializeField] private Transform _requestListTransform;
    private List<Character> _requestList = new List<Character>(100);

    public void UpdateRequestList()
    {
        ClearRequestList();
        foreach(Character request in _requestList)
        {
            Instantiate(_requestTemplatePrebaf, _requestListTransform).SetTemplate(request);
        }
    }

    public void ClearRequestList()
    {
        foreach(Transform request in _requestListTransform)
        {
            Destroy(request.gameObject);
        }
    }

}
