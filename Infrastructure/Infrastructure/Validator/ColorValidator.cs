using System.Drawing;

namespace Infrastructure.Validator;

public static class ColorValidator
{
    public static bool HexColorValid(string hexColor)
    {
        try
        {
            ColorTranslator.FromHtml(hexColor);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
