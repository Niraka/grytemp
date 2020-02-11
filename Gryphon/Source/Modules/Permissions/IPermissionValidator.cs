namespace Gryphon.Modules.Permissions
{
    internal interface IPermissionValidator
    {
        Tools.ValidationResult IsValid(PermissionDetails details);
    }
}
