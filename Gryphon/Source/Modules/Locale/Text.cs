using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Modules.Locale
{
    public class Text
    {
        private readonly int m_iTextId;
        private readonly int m_iLocaleId;
        private readonly string m_sValue;

        public Text(int iTextId, int iLocaleId, string sValue)
        {
            m_iTextId = iTextId;
            m_iLocaleId = iLocaleId;
            m_sValue = sValue;
        }

        public int GetTextId()
        {
            return m_iTextId;
        }

        public int GetLocaleId()
        {
            return m_iLocaleId;
        }

        public string GetValue()
        {
            return m_sValue;
        }
    }
}
