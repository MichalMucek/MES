using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;
using org.mariuszgromada.math.mxparser;

namespace MES
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject dataSetJObject = JObject.Parse(File.ReadAllText(@"..\..\dataSet.json"));
            DataSet dataSet = dataSetJObject.ToObject<DataSet>();

            JObject ksiEtaJObject = JObject.Parse(File.ReadAllText(@"..\..\ksi_eta.json"));
            string[] ksiStrings = ((JArray)ksiEtaJObject["ksi"]).Select(jv => (string)jv).ToArray();
            string[] etaStrings = ((JArray)ksiEtaJObject["eta"]).Select(jv => (string)jv).ToArray();

            double[] ksi = new double[4];
            double[] eta = new double[4];

            Expression ksiExpression = new Expression();
            Expression etaExpression = new Expression();

            for (int i = 0; i < 4; i++)
            {
                ksiExpression.setExpressionString(ksiStrings[i]);
                etaExpression.setExpressionString(etaStrings[i]);

                ksi[i] = ksiExpression.calculate();
                eta[i] = etaExpression.calculate();
            }

            Grid grid = new Grid();
            grid.Generate(dataSet);

            Console.WriteLine(grid);
            Console.ReadKey();
        }
    }
}
