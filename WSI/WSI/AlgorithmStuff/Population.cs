using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSI.AlgorithmStuff
{
    class Population
    {
        readonly Random random = new();
        public List<Chromosome> Parents { get; set; }
        public List<Chromosome> Children { get; set; }

        public delegate double Del(Chromosome chromosome);
        public Del FitnessFunction { get; set; }

        public void SelectByRoulette(bool bothPopulations)
        {
            List<Chromosome> pom = new List<Chromosome>(Parents.Concat(Children));
            if (!bothPopulations)
                pom = (List<Chromosome>)Children;

            double FitenssSum = 0;
            double[] roulettePercents = new double[pom.Count];
            
            for (int i = 0; i < pom.Count; i++)
            {
                FitenssSum += FitnessFunction(pom[i]);
            }
            
            roulettePercents[0] = (FitnessFunction(pom[0]) / FitenssSum) * 100;
            for (int i = 1; i < pom.Count; i++)
            {
                roulettePercents[i] = (FitnessFunction(pom[i]) / FitenssSum) * 100 + roulettePercents[i - 1];
            }

            List<Chromosome> newPopulation = new List<Chromosome>();

            for (int i = 0; i < Parents.Count; i++)
            {
                int makeDraw = random.Next(100);
                for (int j = 0; j < pom.Count; j++)
                {
                    if (roulettePercents[j] > makeDraw)
                    {
                        newPopulation.Add(pom[j]);
                        break;
                    }
                }
            }
            Parents = newPopulation;
        }

        public void SelectBests(int count) //wybieramy z największą wartością funkcji przyswtosowania
        {
            List<Chromosome> p = (List<Chromosome>)Parents;
            p.AddRange(Children);
            p.Sort(CompareByFitnessFunction);
            Parents = p.GetRange(0, count);
        }

        public void SelectChildren()
        {
            Parents = Children;
        }

        private int CompareByFitnessFunction(Chromosome chr1, Chromosome chr2)
        {
            if (FitnessFunction(chr1) > FitnessFunction(chr2))
                return -1;
            else if (FitnessFunction(chr1) < FitnessFunction(chr2))
                return 1;
            else
                return 0;
        }

        public (Chromosome a, Chromosome b) SinglePointCrossOver(Chromosome parentA, Chromosome parentB)
        {
            Chromosome a = new Chromosome();
            Chromosome b = new Chromosome();

            int crossPoint = random.Next(1, Math.Min(parentA.Length, parentB.Length));
            a.sequence.Append(parentA.sequence, 0, crossPoint);
            b.sequence.Append(parentB.sequence, 0, crossPoint);
            a.sequence.Append(parentB.sequence, crossPoint, parentB.Length - crossPoint);
            b.sequence.Append(parentA.sequence, crossPoint, parentA.Length - crossPoint);

            return (a, b);
        }

        public (Chromosome a, Chromosome b) NPointCrossOver(Chromosome parentA, Chromosome parentB, int n)
        {
            if (n > parentA.Length - 1 || n > parentB.Length - 1)
                throw new ArgumentException();

            Chromosome a = new Chromosome();
            Chromosome b = new Chromosome();
            List<int> availablePoints = new List<int>();
            List<int> points = new List<int> ();
            bool cross = false;

            for(int i = 1;i< Math.Min(parentA.Length, parentB.Length) - 1;i++)
            {
                availablePoints.Add(i);
            }
            for(int i = 0;i<n;i++)
            {
                int p = random.Next(availablePoints.Count);
                points.Add(availablePoints[p]);
                availablePoints.RemoveAt(p);
            }
            points.Add(0);
            points.Sort();
            for(int i = 0;i<points.Count - 1;i++)
            {
                if(cross)
                {
                    a.sequence.Append(parentB.sequence, points[i], points[i + 1] - points[i]);
                    b.sequence.Append(parentA.sequence, points[i], points[i + 1] - points[i]);
                    cross = false;
                }
                else
                {
                    a.sequence.Append(parentA.sequence, points[i], points[i + 1] - points[i]);
                    b.sequence.Append(parentB.sequence, points[i], points[i + 1] - points[i]);
                    cross = true;
                }
            }
            if(cross)
            {
                a.sequence.Append(parentB.sequence, points.Last(), parentB.Length - points.Last());
                b.sequence.Append(parentA.sequence, points.Last(), parentB.Length - points.Last());
            }
            else
            {
                a.sequence.Append(parentA.sequence, points.Last(), parentB.Length - points.Last());
                b.sequence.Append(parentB.sequence, points.Last(), parentB.Length - points.Last());
            }

            return (a, b);
        }

        public (Chromosome a, Chromosome b) DecideEveryAllelCrossOver(Chromosome parentA, Chromosome parentB)
        {
            Chromosome a = new Chromosome();
            Chromosome b = new Chromosome();

            for(int i = 0;i< Math.Min(parentA.Length, parentB.Length);i++)
            {
                if(random.Next(2) == 0)
                {
                    a.sequence.Append(parentA.sequence[i]);
                    b.sequence.Append(parentB.sequence[i]);
                }
                else
                {
                    a.sequence.Append(parentB.sequence[i]);
                    b.sequence.Append(parentA.sequence[i]);
                }
            }
            if(random.Next(2) == 0)
            {
                if(parentA.sequence.Length >= parentB.Length)
                {
                    a.sequence.Append(parentA.sequence, parentB.Length, parentA.Length - parentB.Length);
                }
                else
                {
                    a.sequence.Append(parentB.sequence, parentA.Length, parentB.Length - parentA.Length);
                }
            }
            else
            {
                if (parentA.sequence.Length >= parentB.Length)
                {
                    b.sequence.Append(parentA.sequence, parentB.Length, parentA.Length - parentB.Length);
                }
                else
                {
                    b.sequence.Append(parentB.sequence, parentA.Length, parentB.Length - parentA.Length);
                }
            }
            return (a, b);
        }

    }
}
