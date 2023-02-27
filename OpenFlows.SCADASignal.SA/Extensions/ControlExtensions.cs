using Haestad.Support.Units;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Extensions;

public static class ControlExtensions
{
    public static void BindToEnum<TEnum>(this ComboBox comboBox)
    {
        var enumType = typeof(TEnum);

        var fields = enumType.GetMembers()
                              .OfType<FieldInfo>()
                              .Where(p => p.MemberType == MemberTypes.Field)
                              .Where(p => p.IsLiteral)
                              .ToList();

        var valuesByName = new Dictionary<string, object>();

        for (int i = 0; i < fields.Count; i++)
        {
            var field = fields[i];
            var value = field.GetValue(enumType);

            var descriptionAttribute = field.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;

            var description = string.IsNullOrEmpty(descriptionAttribute?.Description)
                     ? field.Name
                     : descriptionAttribute.Description;

            valuesByName[description] = value;
        }

        comboBox.DataSource = valuesByName.ToList();
        comboBox.DisplayMember = "Key";
        comboBox.ValueMember = "Value";
    }

    public static void BindToDimension(this ComboBox comboBox, Dimension dimension)
    {
        comboBox.DataSource = dimension.AvailableUnitsSorted;
        comboBox.DisplayMember = "ShortLabel";
        comboBox.ValueMember = "ShortLabel";
    }
}
