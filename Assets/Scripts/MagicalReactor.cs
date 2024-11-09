using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A component required for the object (magic substance) that will react when elements of different attributes meet.
/// </summary>
public class MagicalReactor : MonoBehaviour
{
    private MagicAttribute attribute;

    private void Awake()
    {
        attribute = GetComponent<MagicAttribute>();
    }

    // TEST: magic react test.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dictionary<string, int> data = MagicFormula.GetMoleculesWithFormula(attribute.MolecularFormula);

            foreach (var item in data)
            {
                Debug.Log(item);
            }

            string target = MagicFormula.React(data);
            Debug.Log(target);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool success = collision.TryGetComponent(out MagicAttribute otherAttribute);

        if (!success || !otherAttribute.Active)
        {
            return;
        }

        attribute.Add(otherAttribute);
        otherAttribute.ToggleActive();
    }
}
