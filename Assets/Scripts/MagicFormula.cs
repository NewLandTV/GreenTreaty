using System.Collections.Generic;

public enum Element
{
    Gramen = 1,
    Ignis = 2,
    Aqua = 3,
    Ventus = 4,
    Lightning = 5,
    Glacies = 6,
    Saxum = 7,
    Lux = 8,
    Tenebris = 9
}

public static class MagicFormula
{
    public static readonly string[] molecules = new string[12]
    {
        "Gr©ü",
        "I©ü",
        "A©ü",
        "V©ü",
        "Ln©ü",
        "Gl©ü",
        "S",
        "Lu",
        "T",
        "GrI©ü",
        "LuT",
        "V©üLn"
    };

    public static Dictionary<string, int> GetMoleculesWithFormula(string formula)
    {
        string[] molecules = formula.Split('+');
        Dictionary<string, int> result = new Dictionary<string, int>();

        for (int i = 0; i < molecules.Length; i++)
        {
            for (int j = 0; j < MagicFormula.molecules.Length; j++)
            {
                string target = MagicFormula.molecules[j];

                if (!molecules[i].Contains(target))
                {
                    continue;
                }

                string[] data = molecules[i].Split(target);

                if (!int.TryParse(data[0], out int coefficient))
                {
                    coefficient = 1;
                }

                result.Add(target, coefficient);
            }
        }

        return result;
    }

    public static string React(Dictionary<string, int> data)
    {
        string target = null;
        bool combustion = data.ContainsKey(molecules[0]) && data.ContainsKey(molecules[1]);
        bool offset = data.ContainsKey(molecules[7]) && data.ContainsKey(molecules[8]);

        if (combustion)
        {
            target = molecules[9];
        }
        if (offset)
        {
            if (target != null)
            {
                target = $"{target}+{molecules[10]}";
            }
            else
            {
                target = molecules[10];
            }
        }

        return target;
    }
}
