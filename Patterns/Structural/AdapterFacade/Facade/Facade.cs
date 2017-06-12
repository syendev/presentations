﻿#region copyright
// Copyright Information
// ==============================
// PatternsExamples - Facade.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace Structural.AdapterFacade.Facade
{
    public interface IBetterAPI
    {
        int AddThreeNumbers(int firstParam, int secondParam, int thirdParam);

        int AddThenMultiply(int addend1, int factor);

        int AddThenMultiply(int addend1, int addend2, int factor);

        int AddThenMultiply(int addend1, int addend2, int addend3, int factor);
    }

    public class BetterAPI : IBetterAPI
    {
        private readonly IConfusing _confusing;
        private readonly IOverdone _overdone;

        public BetterAPI()
        {
            //Demo Code
            _confusing = new Confusing();
            _overdone = new Overdone("foo");
        }

        public BetterAPI(IConfusing confusing, IOverdone overdone)
        {
            _confusing = confusing;
            _overdone = overdone;
        }

        public int AddThreeNumbers(int firstParam, int secondParam, int thirdParam) => 
            _confusing.Execute(firstParam, secondParam, thirdParam);

        public int AddThenMultiply(int addend1, int factor) => 
            _overdone.DoSomething(addend1, factor);

        public int AddThenMultiply(int addend1, int addend2, int factor) => 
            _overdone.DoSomethingElse(addend1, addend2, factor);

        public int AddThenMultiply(int addend1, int addend2, int addend3, int factor) => _overdone.DoSomethingAgain(addend1, addend2, addend3, factor);
    }
}
