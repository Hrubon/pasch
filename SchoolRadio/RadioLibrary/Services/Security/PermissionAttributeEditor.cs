using System;
using System.Linq;


public static class PermissionAttributeEditor
{
    const string DIRECTIVE_SPLITTER = "=>";



    public static void AddAttribute<A>(string permissionName, string attrName, A attrib)
    {
        var t = typeof(Permission);
        var permission = t.GetFields().Where(
            (field) => field.IsPublic && field.IsStatic && field.IsInitOnly && field.FieldType == t && field.Name == permissionName).First();

        var obj = (Permission)permission.GetValue(null);
        if (!obj.Attributes.ContainsKey(attrName))
            obj.Attributes.Add(attrName, attrib);
    }


    public static void AddAttribFromConfig<A>(string[] configContents, string attrName, Func<string, A> parser)
    {
        foreach (var line in configContents)
        {
            var directive = line.Split(new[] { DIRECTIVE_SPLITTER }, StringSplitOptions.RemoveEmptyEntries);
            if (directive.Length != 2)
                continue;

            string permissionName = directive[0].Trim();
            string attrContent = directive[1].Trim();
            A attr = parser(attrContent);

            AddAttribute(permissionName, attrName, attr);
        }
    }
}