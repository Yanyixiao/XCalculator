using System;
using Xunit;
using System.Collections.Generic;
using Yanyixiao;

namespace XUnitTestCalculator
{
    public class UnitTest1
    {
        [Fact]
        public void testSolve()
        {

            Program.Formula testForm = new Program.Formula();
            Queue<string> testQueue = new Queue<string>();
            testQueue.Enqueue("1");
            testQueue.Enqueue("+");
            testQueue.Enqueue("18");
            testQueue.Enqueue("*");
            testQueue.Enqueue("25");
            testQueue.Enqueue("/");
            testQueue.Enqueue("9");//    1+18*25/9  =  51
            testForm.FormQueue = testQueue;
            double result = 51;
            
            Assert.Equal(Program.Solve(testForm),result);
        }
    }
}
