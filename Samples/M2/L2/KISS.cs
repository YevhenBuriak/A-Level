using System.Text;

namespace L2;

public class Kiss
{
    public string? ProcessName(string? name)
    {
        if (name == null) return name;
        if (name.Length == 0) return name;

        var isEmpty = true;
        foreach (var ch in name)
        {
            if (char.IsLetter(ch))
            {
                isEmpty = false;
                break;
            }
        }

        if (isEmpty) return name;

        var strBuilder = new StringBuilder(name.Length);
        foreach (var ch in name)
        {
            strBuilder.Append(char.ToUpper(ch));
        }

        return strBuilder.ToString();
    }

    public string? ProcessNameSimpler(string? name) => string.IsNullOrEmpty(name)
        ? name
        : name.ToUpper();
}
