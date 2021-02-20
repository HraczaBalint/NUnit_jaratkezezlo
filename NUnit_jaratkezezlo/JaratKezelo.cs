using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_jaratkezezlo
{
    class JaratKezelo
    {
        List<Jarat> jaratok;
        Jarat jarat;

        public class Jarat
        {
            private string jaratSzam;
            private string honnanRepter;
            private string hovaRepter;
            private DateTime indulas;
            private int keses;

            public string JaratSzam { get => jaratSzam; set => jaratSzam = value; }
            public string HonnanRepter { get => honnanRepter; set => honnanRepter = value; }
            public string HovaRepter { get => hovaRepter; set => hovaRepter = value; }
            public DateTime Indulas { get => indulas; set => indulas = value; }
            public int Keses { get => keses; set => keses = value; }

            public Jarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas)
            {
                JaratSzam = jaratSzam;
                HonnanRepter = honnanRepter;
                HovaRepter = hovaRepter;
                Indulas = indulas;
                Keses = 0;
            }


        }

        public JaratKezelo()
        {
            jaratok = new List<Jarat>();
        }

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            jarat = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);

            for (int i = 0; i < jaratok.Count; i++)
            {
                if (jarat.JaratSzam != jaratok[i].JaratSzam)
                {
                    jaratok.Add(jarat);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void Keses(string jaratSzam, int keses)
        {
            for (int i = 0; i < jaratok.Count; i++)
            {
                if (jaratok[i].JaratSzam == jaratSzam)
                {
                    jaratok[i].Keses += keses;

                    if (jaratok[i].Keses < 0)
                    {
                        throw new NegativKesesException(keses);
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

            }
        }

        int index = 0;

        public DateTime MikorIndul(string jaratSzam)
        {
            for (int i = 0; i < jaratok.Count; i++)
            {
                if (jaratok[i].JaratSzam == jaratSzam)
                {
                    jaratok[i].Indulas.Date.AddMinutes(jaratok[i].Keses);
                    index = i;
                }
                else
                {
                    throw new ArgumentException();
                }
            }


            return jaratok[index].Indulas;
        }

        public List<Jarat> JaratokRepuloterrol(string repter)
        {
            List<Jarat> jaratokAdottRepterrol = new List<Jarat>();

            for (int i = 0; i < jaratok.Count; i++)
            {
                if (jaratok[i].HonnanRepter == repter)
                {
                    jaratokAdottRepterrol.Add(jaratok[i]);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return jaratokAdottRepterrol;
        }

    }
}
