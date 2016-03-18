using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using ShapeInterfaces;

namespace graphic_editor
{
    public partial class MainForm : Form
    {
        Graphics g;
        List<UserRect> _shapes = new List<UserRect>();
        Type[] recTypes = { typeof(Rect), typeof(Circle) };
        private UserRect sr;
        private int oldX, oldY;
        private PosSizableRect _nodeSelected;
        private bool _move = true;
        private string pathToXML = Environment.CurrentDirectory + "workspace_state.xml";

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            workspace.MouseDown += workspace_MouseDown;
            workspace.MouseMove += workspace_MouseMove;
            workspace.MouseUp += workspace_MouseUp;
            workspace.Paint += workspace_Paint;
            g = workspace.CreateGraphics();
        }

        private void btnDrawRect_Click(object sender, EventArgs e)
        {
            var rect = new Rect();
            _shapes.Add(rect);
            rect.Draw(g);
        }

        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            var circle = new Circle();
            _shapes.Add(circle);
            circle.Draw(g);
        }

        private void workspace_MouseMove(object sender, MouseEventArgs e)
        {

            if (sr == null)
                return;
            ChangeCursor(e.Location);
            if (sr.IsSelected)
            {
                switch (_nodeSelected)
                {
                    case PosSizableRect.Up:
                        sr.Y += e.Y - oldY;
                        sr.Height -= e.Y - oldY;
                        break;

                    case PosSizableRect.Left:
                        sr.X += e.X - oldX;
                        sr.Width -= e.X - oldX;
                        break;

                    case PosSizableRect.Bottom:
                        sr.Height += e.Y - oldY;
                        break;

                    case PosSizableRect.Right:
                        sr.Width += e.X - oldX;
                        break;

                    case PosSizableRect.None:
                        if (_move)
                        {
                            sr.X = sr.X + e.X - oldX;
                            sr.Y = sr.Y + e.Y - oldY;
                        }
                        break;
                }
                workspace.Invalidate();
            }
            if (sr.Height <= 0)
                sr.Height = 1;
            if (sr.Width <= 0)
                sr.Width = 1;
            oldX = e.X;
            oldY = e.Y;

        }

        private void workspace_MouseUp(object sender, MouseEventArgs e)
        {
            if (sr != null)
                sr.IsSelected = false;
        }

        private void workspace_Paint(object sender, PaintEventArgs e)
        {
            foreach (var rect in _shapes)
            {
                rect.Draw(e.Graphics);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<UserRect>), recTypes);
            using (FileStream fs = new FileStream(pathToXML, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, _shapes);
            }
            tslabel.Text = "workspace saved to local storage";

            ChannelFactory<IService> cf = new ChannelFactory<IService>("ServiceEndpoint");
            IService proxy = cf.CreateChannel();
            try
            {
                using (FileStream fs = new FileStream(proxy.GetPathToXml(), FileMode.OpenOrCreate))
                {
                   serializer.Serialize(fs, _shapes);
                }
                tslabel.Text = "workspace saved to server";
            }
            catch (Exception ex)
            {
                //ignored
            }

            Close();
        }

        private void workspace_MouseDown(object sender, MouseEventArgs e)
        {
            _nodeSelected = PosSizableRect.None;
            sr = _shapes.FirstOrDefault(s => s.Contains(new Point(e.X, e.Y)));

            if (sr != null)
            {
                sr.IsSelected = true;
                _nodeSelected = sr.GetNodeSelectable(e.Location);
                if (_nodeSelected != PosSizableRect.None)
                    _move = false;
                else
                    _move = true;
            }
            else
            {
                _shapes.ForEach(s => s.IsSelected = false);
            }
            oldX = e.X;
            oldY = e.Y;
        }

        private void ChangeCursor(Point p)
        {
            workspace.Cursor = GetCursor(sr.GetNodeSelectable(p));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChannelFactory<IService> cf = new ChannelFactory<IService>("ServiceEndpoint");
            IService proxy = cf.CreateChannel();
            XmlSerializer serializer = new XmlSerializer(typeof(List<UserRect>), recTypes);
            try
            {
                using (FileStream fs = new FileStream(proxy.GetPathToXml(), FileMode.OpenOrCreate))
                {
                    _shapes = (List<UserRect>)serializer.Deserialize(fs);
                }
                _shapes.ForEach(s=>s.Draw(g));
                tslabel.Text = "workspace loaded from server";
            }
            catch (Exception ex)
            {
                //ignored
            }
            
            if (File.Exists(pathToXML))
            {
                
                using (FileStream fs = new FileStream(pathToXML, FileMode.OpenOrCreate))
                {
                    _shapes = (List<UserRect>)serializer.Deserialize(fs);
                }
                _shapes.ForEach(s => s.Draw(g));
                tslabel.Text = "workspace loaded from local storage";
            }
        }

        private Cursor GetCursor(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.Up:
                case PosSizableRect.Bottom:
                    return Cursors.SizeNS;
                case PosSizableRect.Left:
                case PosSizableRect.Right:
                    return Cursors.SizeWE;
                default:
                    return Cursors.Default;
            }
        }
    }
}
