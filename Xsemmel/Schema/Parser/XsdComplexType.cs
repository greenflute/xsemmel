using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace XSemmel.Schema.Parser {

    public class XsdComplexType : XsdNode, IXsdHasName, IXsdHasAttribute, IXsdIsType
    {

        public XsdComplexType(XmlNode node) : base(node)
        {
            {
                string attr = VisualizerHelper.GetAttr(node, "name");
                if (attr != null)
                {
                    Name = attr;
                }
            }
            {
                string attr = VisualizerHelper.GetAttr(node, "abstract");
                if (attr != null)
                {
                    Abstract = attr;
                }
            }
            {
                string attr = VisualizerHelper.GetAttr(node, "block");
                if (attr != null)
                {
                    Block = attr;
                }
            }
            {
                string attr = VisualizerHelper.GetAttr(node, "final");
                if (attr != null)
                {
                    Final = attr;
                }
            }
            {
                string attr = VisualizerHelper.GetAttr(node, "mixed");
                if (attr != null)
                {
                    Mixed = attr;
                }
            }
            {
                string attr = VisualizerHelper.GetAttr(node, "id");
                if (attr != null)
                {
                    Id = attr;
                }
            }
        }

        public string Abstract { get; set; }
        public string Block { get; set; }
        public string Final { get; set; }
        public string Id { get; set; }
        public string Mixed { get; set; }

        private readonly HashSet<XsdAttribute> _attrs = new HashSet<XsdAttribute>();


        public void AddAtts(XsdAttribute attr)
        {
            _attrs.Add(attr);
        }

        public ICollection<XsdAttribute> GetAttributes()
        {
            return _attrs;
        }

        public override string ToString()
        {
            return Name;
        }

        public override UIElement GetPaintComponent(XsdVisualizer.PaintOptions po, int fontSize)
        {
            if (fontSize <= 0) return null;

            StackPanel pnl = new StackPanel();

            pnl.Children.Add(GetPaintTitle(po, fontSize));

            if (_attrs.Count == 0)
            {
                pnl.Children.Add(new TextBlock
                {
                    Text = "(no attributes)",
                    Foreground = Brushes.Gray,
                    FontSize = fontSize
                });
            }
            else
            {
                foreach (XsdAttribute attr in _attrs)
                {
                    pnl.Children.Add(attr.GetPaintComponent(po, fontSize));
                }
            }


            pnl.Children.Add(GetPaintChildren(po, fontSize - 1));

            addMouseEvents(po, pnl, this);

            return new Border { BorderBrush = Brushes.Black, BorderThickness = new Thickness(1), Child = pnl, Margin = new Thickness(5) };
        }

        protected override UIElement GetPaintTitle(XsdVisualizer.PaintOptions po, int fontSize)
        {
            return new TextBlock
            {
                Text = ToString(),
                Background = new LinearGradientBrush(Colors.MistyRose, Colors.Transparent, 90),
                FontSize = fontSize,
                FontWeight = FontWeights.DemiBold
            };
        }

    }
}