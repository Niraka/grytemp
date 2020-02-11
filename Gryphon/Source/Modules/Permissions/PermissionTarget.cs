namespace Gryphon.Modules.Permissions
{
    public class PermissionTarget
    {
        private readonly int m_iId;
        private readonly string m_sName;

        public PermissionTarget(int iId, string sName)
        {
            m_iId = iId;
            m_sName = sName;
        }

        public int GetId()
        {
            return m_iId;
        }

        public string GetName()
        {
            return m_sName;
        }
    }
}
