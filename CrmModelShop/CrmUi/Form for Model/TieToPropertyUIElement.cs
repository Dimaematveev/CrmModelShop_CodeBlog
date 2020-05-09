using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUi.Form_for_Model
{
    public class TieToPropertyUIElement
    {
        public TieToPropertyUIElement(object property, string nameProperty, object UIElement, string nameUIElement)
        {
            Property = property;
            NameProperty = nameProperty;
            this.UIElement = UIElement;
            NameUIElement = nameUIElement;
        }

        public TieToPropertyUIElement(object property, string nameProperty)
        {
            Property = property;
            NameProperty = nameProperty;
        }

        public void AddUi(object UIElement, string nameUIElement)
        {
            this.UIElement = UIElement;
            NameUIElement = nameUIElement;
        }
        object Property { get; set; }
        string NameProperty { get; set; }
        public object UIElement { get; private set; }
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
