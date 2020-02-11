namespace Gryphon.Modules.Permissions
{
    public class PermissionDetails
    {
        private readonly string m_sName;
        private readonly string m_sDescription;

        public PermissionDetails(string sName, string sDescription)
        {
            m_sName = sName;
            m_sDescription = sDescription;
        }

        public string GetName()
        {
            return m_sName;
        }

        public string GetDescription()
        {
            return m_sDescription;
        }
    }
}
