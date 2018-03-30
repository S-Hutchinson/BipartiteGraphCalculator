using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BipartiteGraphCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BipartiteGraph _graph = new BipartiteGraph();
        List<Point> _leftPoints = new List<Point>();
        List<Point> _rightPoints = new List<Point>();
        List<Ellipse> _leftDots = new List<Ellipse>();
        List<Ellipse> _rightDots = new List<Ellipse>();
        List<Line> _lines = new List<Line>();
        // IF I DECIDE TO enable removal of lines, then _lines should
        // probably be a 2 dim array indexed by the end points.

        public MainWindow()
        {
            InitializeComponent();
        }


        // GRAPH CONSTRUCTION EVENTS

        private void AddLeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (_leftPoints.Count >= 8)
            {
                MessageBox.Show("Left vertex limit reached");
            }
            else
            {
                _graph.AddLeftVertex();
                Point point = new Point(50, (_leftPoints.Count + 1) * 20);
                _leftPoints.Add(point);
                Ellipse ellipse = new Ellipse();
                ellipse.Height = 5;
                ellipse.Width = 5;
                ellipse.Fill = Brushes.Black;
                ellipse.StrokeThickness = 2;
                ellipse.Stroke = Brushes.Black;
                GraphDrawing.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, point.X - 3);
                Canvas.SetTop(ellipse, point.Y - 3);
            }
        }

        private void AddRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (_rightPoints.Count >= 8)
            {
                MessageBox.Show("Right vertex limit reached");
            }
            else
            {
                _graph.AddRightVertex();
                Point point = new Point(300, (_rightPoints.Count + 1) * 20);
                _rightPoints.Add(point);
                Ellipse ellipse = new Ellipse();
                ellipse.Height = 5;
                ellipse.Width = 5;
                ellipse.Fill = Brushes.Black;
                ellipse.StrokeThickness = 2;
                ellipse.Stroke = Brushes.Black;
                GraphDrawing.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, point.X - 3);
                Canvas.SetTop(ellipse, point.Y - 3);
            }
        }

        private void AddEdgeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(Int32.TryParse(LeftEndText.Text, out int i)) ||
            !(Int32.TryParse(RightEndText.Text, out int j)))
            {
                MessageBox.Show("The edge's ends must be integers");
            }
            else if ((i > _leftPoints.Count) || (j > _rightPoints.Count)
                || (i < 1) || (j < 1))
            {
                MessageBox.Show("One or more invalid vertex numbers");
            }
            else if (_graph.HasEdge(i, j))
            {
                MessageBox.Show("Edge already exists");
            }

            else
            {
                _graph.AddEdge(i, j);
                Line line = new Line();
                line.X1 = _leftPoints[i - 1].X;
                line.Y1 = _leftPoints[i - 1].Y;
                line.X2 = _rightPoints[j - 1].X;
                line.Y2 = _rightPoints[j - 1].Y;
                line.HorizontalAlignment = HorizontalAlignment.Center;
                line.VerticalAlignment = VerticalAlignment.Center;
                line.Stroke = System.Windows.Media.Brushes.Black;
                line.StrokeThickness = 1;
                _lines.Add(line);
                GraphDrawing.Children.Add(line);
                LeftEndText.Text = String.Empty;
                RightEndText.Text = String.Empty;
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _graph = null;
            _leftPoints = null;
            _rightPoints = null;
            _leftDots = null;
            _rightDots = null;
            _lines = null;
            _graph = new BipartiteGraph();
            _leftPoints = new List<Point>();
            _rightPoints = new List<Point>();
            _leftDots = new List<Ellipse>();
            _rightDots = new List<Ellipse>();
            _lines = new List<Line>();
            OutputLabel.Content = String.Empty;
            GraphDrawing.Children.Clear();
        }


        // CALCULATION EVENTS

        private void TotalVerticesButton_Click(object sender, RoutedEventArgs e)
        {
            OutputLabel.Content = _graph.CountVertices;
        }

        private void LeftVerticesButton_Click(object sender, RoutedEventArgs e)
        {
            OutputLabel.Content = _graph.CountLeftVertices;
        }

        private void RightVerticesButton_Click(object sender, RoutedEventArgs e)
        {
            OutputLabel.Content = _graph.CountRightVertices;
        }

        private void TotalEdgesButton_Click(object sender, RoutedEventArgs e)
        {
            OutputLabel.Content = _graph.CountEdges;
        }

        private void ComponentsButton_Click(object sender, RoutedEventArgs e)
        {
            OutputLabel.Content = _graph.CountComponents();
        }
    }
}
