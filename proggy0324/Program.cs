using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace proggy0324
{
    class Beolvas
    {
        public int ev;
        public int het;
        public int fordulo;
        public int ttsz;
        public int ttf;
        public string eredmeny;
        
        public Beolvas(string sor)
        {
            string[] szetbont = sor.Split(";");
            ev = Convert.ToInt32(szetbont[0]);
            het = Convert.ToInt32(szetbont[1]);
            fordulo = Convert.ToInt32(szetbont[2]);
            ttsz = Convert.ToInt32(szetbont[3]);
            ttf = Convert.ToInt32(szetbont[4]);
            eredmeny = szetbont[5];
        }
    }
    class EredmenyElemzo
    {
        private string Eredmenyek;
        private int DontetlenekSzama
        {
            get
            {
                return Megszamol('X');
            }
        }

        private int Megszamol(char kimenet)
        {
            int darab = 0;
            foreach (var i in Eredmenyek)
            {
                if (i == kimenet) darab++;
            }
            return darab;
        }

        public bool NemvoltDontetlenMerkozes
        {
            get
            {
                return DontetlenekSzama == 0;
            }
        }

        public EredmenyElemzo(string eredmenyek) // konstruktor
        {
            Eredmenyek = eredmenyek;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //2. feladat
            List<Beolvas> lista = new List<Beolvas>();
            foreach(var i in File.ReadLines("toto.txt").Skip(1))
            {
                lista.Add(new Beolvas(i));
            }
            //3. feladat
            Console.WriteLine($"3. feladat: Fordulók száma: {lista.Count}");
            //4. feladat
            int thelper = 0;
            foreach (var i in lista)
            {
                thelper += i.ttsz;
            }
            Console.WriteLine($"4. feladat: Telitalálatos szelvények száma: {thelper} db");
            //5.feladat
            thelper = 0;
            long osszeg = 0;
            foreach (var i in lista)
            {
                if (i.ttf > 0)
                {
                    thelper++;
                    osszeg += i.ttsz * i.ttf;
                }
            }
            long atlag = osszeg / thelper;
            Console.WriteLine($"5. feladat: Átlag: {atlag} Ft");
            // 6. feladat
            int minttf = lista.ElementAt(9).ttf;
            int maxttf = lista.ElementAt(0).ttf;
            int max = 0;
            int min = 0;
            int j = 0;
            foreach (var i in lista)
            {
                
                if(i.ttf > maxttf)
                {
                    maxttf = i.ttf;
                    max = j;
                }
                if(i.ttf < minttf && i.ttf != 0)
                {
                    minttf = i.ttf;
                    min = j;
                }
                j++;
            }
            Console.WriteLine($"6. feladat:\n\tLegnagyobb:\n\tÉv: {lista[max].ev}\n\tHét: {lista[max].het}.\n\tForduló: {lista[max].fordulo}.\n\tTelitalálat: {lista[max].ttsz} db\n\tNyeremény: {lista[max].ttf}\n\tEredmények: {lista[max].eredmeny}");
            Console.WriteLine($"\n\tLegkisebb:\n\tÉv: {lista[min].ev}\n\tHét: {lista[min].het}.\n\tForduló: {lista[min].fordulo}.\n\tTelitalálat: {lista[min].ttsz} db\n\tNyeremény: {lista[min].ttf}\n\tEredmények: {lista[min].eredmeny}");
        }
    }
}
