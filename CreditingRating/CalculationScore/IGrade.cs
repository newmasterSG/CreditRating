using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating.CalculationScore
{
    public interface IGrade : ICalculatorGrade
    {
        public static readonly Dictionary<string, double> _factorWeights = new Dictionary<string, double>()
        {
            { "paymentHistory", 0.35 },
            { "creditUtilization", 0.30 },
            { "creditHistoryLength", 0.15 },
            { "recentInquiries", 0.10 },
            { "creditMix", 0.10 }
        };
    }
}
