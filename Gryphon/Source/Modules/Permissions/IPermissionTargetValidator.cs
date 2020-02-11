namespace Gryphon.Modules.Permissions
{
    internal interface IPermissionTargetValidator
    {
        Tools.ValidationResult IsValid(PermissionTargetDetails details);
    }
}
