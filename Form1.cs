using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace TesteChart1
{
    public partial class Form1 : Form
    {
        GraphPane graphPane;


        private void DrawSineCurve()
        {

            PointPairList _pointPairList = new PointPairList();
            //Gera o looping infinito da função seno, limitando ela dentro de um intervalo entre 0 n*2*PI
            //Sendo n= (1, 2, 3, 4, ...), adicionando os pontos a um vetor imutável
            for (int _angle = 0; _angle <= 360; _angle = _angle + 10)
            {
                double _x = _angle;
                double _y = Math.Sin(Math.PI * _x / 100.0);
                PointPair pointPair = new PointPair(_x, _y);

                _pointPairList.Add(pointPair);
            }
            //Adiciona o pointPair ao gráfico, linha muito importante
            LineItem _lineItem = graphPane.AddCurve("Sine Curve", _pointPairList, Color.Red, SymbolType.None);
            
            //Ajusta o gráfico para aparecer na escala correta para visualização rápida
            zedGraphControl1.AxisChange();
        }

        public Form1()
        {
            InitializeComponent();
            //Se comunica com o elemento gráfico.
            graphPane = zedGraphControl1.GraphPane;

            //Chama o Void Criado anteriormente para exutar
            //o comando apenas no objeto quando adicionado o gráfico...
            DrawSineCurve();
        }



        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
