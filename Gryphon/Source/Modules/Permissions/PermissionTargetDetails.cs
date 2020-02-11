namespace Gryphon.Modules.Permissions
{
    public class PermissionTargetDetails
    {
        private readonly string m_sName;

        public PermissionTargetDetails(string sName)
        {
            m_sName = sName;
        }

        public string GetName()
        {
            return m_sName;
        }
    }
}
