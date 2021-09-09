using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1st_part
{
    public partial class Form1 : Form
    {
        Graphics g;

        Point[] lEar1 =
            {
                new Point(35, 114),
                new Point(16, 49),
                new Point(52, 44),
                new Point(56, 56),
                new Point(41, 85)
            };
        Point[] lEar2 =
            {
                new Point(16, 49),
                new Point(46, 38),
                new Point(66, 41),
                new Point(56, 56),
                 new Point(52, 44)
            };

        Point[] rEar1 =
            {
                new Point(146, 53),
                new Point(119, 43),
                new Point(95, 44),
                new Point(81, 49),
                new Point(74, 36),
                new Point(69, 15),
                new Point(74, 4),
                new Point(119, 19),
                new Point(135, 37),
            };

        Point[] rEar2 =
            {
                new Point(146, 52),
                new Point(136, 36),
                new Point(119, 19),
                new Point(75, 4),
                new Point(108, 5),
                new Point(136, 19),
                new Point(167, 48)
            };

        Point[] head =
            {
                new Point(35, 114),
                new Point(41, 84),
                new Point(56, 56),
                new Point(66, 41),
                new Point(91, 30),
                new Point(113, 23),
                new Point(136, 19),
                new Point(167, 48),
                new Point(177, 84),
                new Point(168, 118),
                new Point(139, 145),
                new Point(98, 159),
                new Point(60, 153),
                new Point(44, 137)
            };

        Point[] face =
            {
                new Point(112, 138),
                new Point(118, 129),
                new Point(138, 118),
                new Point(149, 90),
                new Point(109, 59),
                new Point(58, 74),
                new Point(43, 108),
                new Point(50, 137),
                new Point(69, 149),
                new Point(82, 146),
                new Point(92, 148),
                new Point(100, 141),
            };

        

        Point[] nose =
            {
                new Point(94, 134),
                new Point(97, 126),
                new Point(85, 131)
            };

        Point[] lEye1 =
           {
                new Point(64, 136),
                new Point(55, 121),
                new Point(59, 113),
                new Point(69, 113),
                new Point(82, 129)
            };

        Point[] rEye1 =
            {
                new Point(104, 116),
                new Point(100, 100),
                new Point(106, 86),
                new Point(115, 83),
                new Point(124, 92),
                new Point(124, 103),
                new Point(114, 108)

            };

        Point[] body =
            {
                new Point(137, 149),
                new Point(136, 172),
                new Point(126, 192),
                new Point(119, 206),
                new Point(120, 240),
                new Point(126, 249),
                new Point(124, 253),
                new Point(117, 255),
                new Point(110, 254),
                new Point(100, 257),
                new Point(91, 257),
                new Point(86, 254),
                new Point(78, 255),
                new Point(71, 252),
                new Point(70, 194),
                new Point(76, 179),
                new Point(100,164),
                new Point(98, 159),

            };

        Point[] lLeg =
            {
                new Point(100, 258),
                new Point(91, 257),
                new Point(88, 240),
                new Point(90, 222),
                new Point(98, 210),
                new Point(103, 224),
                new Point(106, 245),
                new Point(109, 254)
            };

        Point[] rLeg =
            {
                new Point(120, 240),
                new Point(127, 249),
                new Point(124, 253),
                new Point(117, 255),
                new Point(109, 254),
                new Point(110, 249),
                new Point(106, 245),
                new Point(102, 224),
                new Point(111, 210),
                new Point(118, 217),
            };

        Point[] tail =
            {
                new Point(71, 236),
                new Point(62, 240),
                new Point(49, 242),
                new Point(36, 243),
                new Point(15, 254),
                new Point(34, 253),
                new Point(56, 255),
                new Point(71, 252),
            };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
            g.Clear(Color.White);

            g.DrawClosedCurve(Pens.Black, body);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(233, 111, 33)), body);

            g.DrawClosedCurve(Pens.Black, tail);
            g.FillClosedCurve(new SolidBrush(Color.Brown), tail);

            g.DrawClosedCurve(Pens.Black, lLeg);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(128, 21, 23)), lLeg);

            g.DrawClosedCurve(Pens.Black, rLeg);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(128, 21, 23)), rLeg);

            g.DrawClosedCurve(Pens.Black, head);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(233, 111, 33)), head);

            g.DrawClosedCurve(Pens.Black, face);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(128, 21, 23)), face);

            g.DrawClosedCurve(Pens.Black, nose);
            g.FillClosedCurve(new SolidBrush(Color.Red), nose);

            //mustache
            g.DrawLine(Pens.Black, new Point(104, 127), new Point(135, 106));
            g.DrawLine(Pens.Black, new Point(106, 129), new Point(139, 114));
            g.DrawLine(Pens.Black, new Point(108, 132), new Point(138, 123));
            g.DrawLine(Pens.Black, new Point(56, 144), new Point(86, 136));
            g.DrawLine(Pens.Black, new Point(56, 152), new Point(88, 138));
            g.DrawLine(Pens.Black, new Point(62, 157), new Point(89, 140));

            g.DrawLine(Pens.Black, new Point(100, 140), new Point(94, 134));

            g.DrawClosedCurve(Pens.Black, lEye1);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(0, 167, 215)), lEye1);

            Rectangle el = new Rectangle(60, 123, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Black), el);

            g.DrawClosedCurve(Pens.Black, rEye1);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(0, 167, 215)), rEye1);

            el = new Rectangle(105, 98, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Black), el);

            g.DrawClosedCurve(Pens.Black, lEar2);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(128, 21, 23)), lEar2);
            g.DrawClosedCurve(Pens.Black, lEar1);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(244, 197, 130)), lEar1);

            g.DrawClosedCurve(Pens.Black, rEar2);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(128, 21, 23)), rEar2);
            g.DrawClosedCurve(Pens.Black, rEar1);
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(244, 197, 130)), rEar1);

        }
    }
}
