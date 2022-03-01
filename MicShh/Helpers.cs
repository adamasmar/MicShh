namespace MicShh
{
    public class Helpers
    {
        public static string GetCurrentKeyBindString(IEnumerable<string> modifiers, IEnumerable<string> virtualKeyCodes)
        {
            var modifierString = string.Join(", ", modifiers);

            var virtualKeyCodeString = string.Join(",", virtualKeyCodes)
                .Replace("KEY_", string.Empty)
                .Replace("VK_", string.Empty);

            modifierString = modifierString == "0" ? null : modifierString;
            virtualKeyCodeString = virtualKeyCodeString == "0" ? null : virtualKeyCodeString;

            var finalString = modifierString;

            if (!string.IsNullOrEmpty(virtualKeyCodeString))
            {
                finalString +=
                    string.IsNullOrWhiteSpace(finalString) ?
                    virtualKeyCodeString :
                    " + " + virtualKeyCodeString;
            }

            return finalString ?? string.Empty;
        }
    }
}
