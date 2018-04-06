﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RuslanKudaybergenovTask6
{
    class NumberGenerator
    {
        bool IsUseFilter(int x,IEnumerable<Func<int, bool>> useFilter)
        {
            foreach (var filter in useFilter)
            {
                    if (!filter(x))
                        return false;
            }
            return true;
        }

        public void Subscribe(Action<int> onNumberReceived, IEnumerable<Func<int, bool>> useFilter)
        {

            //if (IsUseFilter(onNumberReceived, useFilter))

            //Console.WriteLine(filter.Method.Name);
            for (int i = 0; i < 101; i++)
            {
                //Console.WriteLine(filter.Method.Name);
                if (IsUseFilter(i,useFilter))
                {
                    onNumberReceived(i);
                }
            }
        }

        public bool Filter1(int x)
        {
            return x % 10 == 0;
        }
        public bool Fileter2(int x)
        {
            return x % 3 == 0;
        }
        public bool Filter3(int x)
        {
            return x % 2 != 0 && x % 3 != 0 && x % 5 != 0;
        }
        public bool Filter4(int x)
        {
            return x % 1 == 0;
        }
        public void GetNumber( int i)
        {
            Console.WriteLine("Filtered number: "+i);
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            NumberGenerator ng = new NumberGenerator();
            
            List<Func<int, bool>> client1FuncList = new List<Func<int, bool>>()
            {
                ng.Filter1,
                ng.Fileter2,
                //ng.Filter3
            };
            ng.Subscribe(ng.GetNumber, client1FuncList);
            Console.ReadKey();
        }
    }
}
