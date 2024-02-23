using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private bool useFirstHandle = true;
    [SerializeField] private bool useSecondHandle = true;
    [SerializeField] private bool locked = false;
    [SerializeField] private UnityEvent OnOpen;
    [SerializeField] private UnityEvent OnClose;
    [SerializeField] private UnityEvent OnLocked;

    private Animator animator;
    private bool isLocked = true;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (!useFirstHandle)
        {
            Transform handle1 = transform.Find("Door Handle 1");
            if (handle1)
            {
                handle1.gameObject.SetActive(false);
            }
        }
        if (!useSecondHandle)
        {
            Transform handle2 = transform.Find("Door Handle 2");
            if (handle2)
            {
                handle2.gameObject.SetActive(false);
            }
        }
    }

    public void Open()
    {
        if (locked && isLocked)
        {
            return;
        }
        OnOpen.Invoke();
        animator.SetBool("IsOpen", true);
    }

    public void Close()
    {
        OnClose.Invoke();
        animator.SetBool("IsOpen", false);
    }

    public void Lock()
    {
        isLocked = true;
    }

    public void Unlock()
    {
        isLocked = false;
    }

    public void toggle()
    {
        if (locked && isLocked && !animator.GetBool("IsOpen"))
        {
            return;
        }
        animator.SetBool("IsOpen", !animator.GetBool("IsOpen"));
    }

    public void TryToOpen()
    {
        if ((locked && !isLocked) || !locked)
        {
            Open();
            return;
        }

        ABILITY_Inventory inventory = GameObject.Find("EtraAbilityManager").GetComponent<ABILITY_Inventory>();
        UsableItem key = inventory.HasItem(UsableItem.UsableItemType.Key);

        if (key != null)
        {
            Unlock();
            Open();
            inventory.RemoveItem(key);
        }
        else
        {
            OnLocked.Invoke();
        }
    }

    public void TryToToggle()
    {
        if ((locked && !isLocked) || !locked)
        {
            toggle();
            return;
        }

        ABILITY_Inventory inventory = GameObject.Find("EtraAbilityManager").GetComponent<ABILITY_Inventory>();
        UsableItem key = inventory.HasItem(UsableItem.UsableItemType.Key);

        if (key != null)
        {
            Unlock();
            toggle();
            inventory.RemoveItem(key);
        }
        else
        {
            OnLocked.Invoke();
        }
    }

    public void enableCollider()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    public void disableCollider()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
}
