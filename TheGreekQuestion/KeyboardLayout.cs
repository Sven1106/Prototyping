using System;

namespace Trekteg
{
    public class KeyboardLayout
    {
        public UInt32 Id { get; }

        public UInt16 LanguageId { get; }
        public UInt16 KeyboardId { get; }

        public String LanguageName { get; }
        public String KeyboardName { get; }

        internal KeyboardLayout(UInt32 id, UInt16 languageId, UInt16 keyboardId, String languageName, String keyboardName)
        {
            this.Id = id;
            this.LanguageId = languageId;
            this.KeyboardId = keyboardId;
            this.LanguageName = languageName;
            this.KeyboardName = keyboardName;
        }
    }
}
