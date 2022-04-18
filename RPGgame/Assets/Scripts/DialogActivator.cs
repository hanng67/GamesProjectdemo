using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    [SerializeField]
    private string[] _newLines;

    [SerializeField]
    private bool _isPerson = true;

    private bool _canActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_canActive && Input.GetButtonDown("Fire1") && !DialogManager.instance.GetActiveDialogBox())
        {
            DialogManager.instance.ShowDialog(_newLines, _isPerson);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canActive = false;
        }
    }
}
