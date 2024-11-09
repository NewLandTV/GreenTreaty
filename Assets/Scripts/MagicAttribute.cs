using UnityEngine;

public class MagicAttribute : MonoBehaviour
{
    [SerializeField]
    private string molecularFormula;
    public string MolecularFormula => molecularFormula;
    public bool Active { get; private set; } = true;

    public void Add(MagicAttribute attribute)
    {
        molecularFormula = $"{molecularFormula}+{attribute.molecularFormula}";
    }

    public void ToggleActive()
    {
        Active = !Active;
    }
}
