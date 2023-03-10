using CreditingRating.Context;
using CreditingRating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating.CalculationScore
{
        public class FicoGrade : IGrade
        {
            static double CreditUtilization(List<Credit> credits)
            {
                const double score = 255;
                double perc = score * (credits.Sum(c => c.MoneySpent) / credits.Sum(c => c.AvailableCredit));
                return score - perc;
            }

            static double calculateScoreWithPaymentLate(int paymentlate)
            {
                const double score = 297.5;
                double sum = 0;
                double temp = score * 0.01;
                for (int i = 1; i <= paymentlate; i++)
                {
                    sum += temp;
                }
                return score - sum;
            }

            static double LengthCredit(List<Credit> credits)
            {
                const double score = 127.5;
                double t = (int)(credits.Select(c => (DateTime.Now - c.OpenedDate).TotalDays).Average() / 365 * 15);

                if (t > score)
                {
                  t = score;
                }

                return t;
            }

            static double CalculationCreditMix(List<Credit> credits)
            {
                const double score = 85;
                int creditMix = (int)(credits.GroupBy(c => c.GetType().Name).Count() / (decimal)credits.Count() * 10);
                if (creditMix > score)
                    return 0;
                return score - creditMix;
            }

            static double CalculationWithNewCredit(List<Credit> credits)
            {
                const double score = 85;
                int newCredit = (int)(credits.Where(c => c.OpenedDate.Year >= DateTime.Now.Year).Count() / (decimal)credits.Count() * 10);
                if (newCredit > score)
                    return 0;

                return score - newCredit;
            }
            public double CalculateFicoScore(List<Credit> credits)
            {
                double score = CreditUtilization(credits) + calculateScoreWithPaymentLate(credits.Sum(c => c.LatePayment)) + LengthCredit(credits) + CalculationCreditMix(credits) + CalculationWithNewCredit(credits);

                return score;
            }

        }
   }
