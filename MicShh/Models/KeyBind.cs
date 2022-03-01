using GlobalHotKeys.Native.Types;

namespace MicShh.Models
{
    public class KeyBind
    {
        private VirtualKeyCode[] _keys = null!;
        public VirtualKeyCode[] Keys 
        { 
            get => _keys; 
            set => _keys = value ?? throw new ArgumentNullException("Cannot be null");
        }

        private Modifiers[] _modifiers = null!;
        public Modifiers[] Modifiers
        {
            get => _modifiers;
            set => _modifiers = value ?? throw new ArgumentNullException("Cannot be null");
        }
    }
}
