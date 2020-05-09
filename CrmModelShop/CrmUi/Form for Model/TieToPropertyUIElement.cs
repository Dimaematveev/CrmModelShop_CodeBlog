using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUi.Form_for_Model
{
    public class TieToPropertyUIElement
    {
        public TieToPropertyUIElement(object property, string nameProperty, object uIElement, string nameUIElement)
        {
            Property = property;
            NameProperty = nameProperty;
            UIElement = uIElement;
            NameUIElement = nameUIElement;
        }

        object Property { get; set; }
        string NameProperty { get; set; }
        object UIElement { get; set; }
        string NameUIElement { get; set; }


        public void SetProp()
        {
            Property.GetType().GetProperty(NameProperty).SetValue(Property, UIElement.GetType().GetProperty(NameUIElement).GetValue(UIElement));
        }
        public object GetProp()
        {
            return Property.GetType().GetProperty(NameProperty).GetValue(Property);
        }
    }
}
