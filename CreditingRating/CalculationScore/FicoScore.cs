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
        //public double CalculateCreditHistoryLengthScore(int creditHistoryLength)
        //{
        //    if (creditHistoryLength < 2)
        //    {
        //        return 0;
        //    }
        //    else if (creditHistoryLength >= 2 && creditHistoryLength < 5)
        //    {
        //        return 20;
        //    }
        //    else if (creditHistoryLength >= 5 && creditHistoryLength < 7)
        //    {
        //        return 30;
        //    }
        //    else if (creditHistoryLength >= 7 && creditHistoryLength < 10)
        //    {
        //        return 40;
        //    }
        //    else
        //    {
        //        return 50;
        //    }
        //}

        ////public double CalculateCreditMixScore(string creditMix)
        ////{
        ////    using (var context = new BankingContext())
        ////    {
        ////        var creditCards = context.CreditCards.Where(c => c.PersonId == personId).ToList();
        ////        var creditLimitSum = creditCards.Sum(c => c.CreditLimit);
        ////        var balanceSum = creditCards.Sum(c => c.Balance);
        ////        var utilization = balanceSum / creditLimitSum;

        ////        if (utilization < 0.1)
        ////        {
        ////            return 10;
        ////        }
        ////        else if (utilization < 0.3)
        ////        {
        ////            return 20;
        ////        }
        ////        else if (utilization < 0.5)
        ////        {
        ////            return 15;
        ////        }
        ////        else
        ////        {
        ////            return 10;
        ////        }
        ////    }
        ////}

        //public double CalculateCreditUtilizationScore(double creditUtilization)
        //{
        //    if (creditUtilization >= 0 && creditUtilization <= 0.3)
        //    {
        //        return 100;
        //    }
        //    else if (creditUtilization > 0.3 && creditUtilization <= 0.5)
        //    {
        //        return 80;
        //    }
        //    else if (creditUtilization > 0.5 && creditUtilization <= 0.7)
        //    {
        //        return 60;
        //    }
        //    else if (creditUtilization > 0.7 && creditUtilization <= 0.9)
        //    {
        //        return 40;
        //    }
        //    else
        //    {
        //        return 20;
        //    }
        //}

        //public double CalculatePaymentHistoryScore(List<double> paymentHistory)
        //{
        //    double onTimePayments = paymentHistory.Count(x => x == 1);
        //    return onTimePayments / paymentHistory.Count * 100;
        //}

        //public double CalculateRecentInquiriesScore(int recentInquiries)
        //{
        //    if (recentInquiries == 0)
        //    {
        //        return 100;
        //    }
        //    else if (recentInquiries == 1)
        //    {
        //        return 80;
        //    }
        //    else if (recentInquiries == 2)
        //    {
        //        return 60;
        //    }
        //    else if (recentInquiries == 3)
        //    {
        //        return 40;
        //    }
        //    else
        //    {
        //        return 20;
        //    }
        //}

        //static int CalculatePaymentHistoryScore(int latePayments)
        //{
        //    if (latePayments > 2)
        //    {
        //        return 300;
        //    }
        //    else if (latePayments == 2)
        //    {
        //        return 450;
        //    }
        //    else if (latePayments == 1)
        //    {
        //        return 500;
        //    }
        //    else
        //    {
        //        return 550;
        //    }
        //}

        //static int CalculateCreditUtilizationScore(int creditUtilization)
        //{
        //    if (creditUtilization > 70)
        //    {
        //        return 250;
        //    }
        //    else if (creditUtilization > 50)
        //    {
        //        return 450;
        //    }
        //    else if (creditUtilization > 30)
        //    {
        //        return 650;
        //    }
        //    else if (creditUtilization > 10)
        //    {
        //        return 750;
        //    }
        //    else
        //    {
        //        return 850;
        //    }
        //}

        //static int CalculateLengthOfCreditScore(int creditAccounts)
        //{
        //    if (creditAccounts < 3)
        //    {
        //        return 200;
        //    }
        //    else if (creditAccounts < 5)
        //    {
        //        return 400;
        //    }
        //    else if (creditAccounts < 7)
        //    {
        //        return 600;
        //    }
        //    else if (creditAccounts < 10)
        //    {
        //        return 700;
        //    }
        //    else
        //    {
        //        return 800;
        //    }
        //}

        //public double CalculateScore(Client person)
        //    {
        //        //double creditUtilizationScore = CalculateCreditUtilizationScore(person.CreditHistory.CreditUtilization);
        //        //double paymentHistoryScore = CalculatePaymentHistoryScore(person.CreditHistory.PaymentHistory);
        //        //double lengthOfCreditHistoryScore = CalculateCreditHistoryLengthScore(person.CreditHistory.CreditHistoryLength);
        //        //double recentInquiriesScore = CalculateRecentInquiriesScore(person.CreditHistory.recentInquiries);

        //        //double ficoScore =
        //        //    IGrade._factorWeights["creditUtilization"] * creditUtilizationScore +
        //        //     IGrade._factorWeights["paymentHistory"] * paymentHistoryScore +
        //        //     IGrade._factorWeights["creditHistoryLength"] * lengthOfCreditHistoryScore +
        //        //     IGrade._factorWeights["recentInquiries"] * recentInquiriesScore;

        //        //return ficoScore;

        //    double ficoScore = CalculatePaymentHistoryScore(person.CreditHistory.)
        //    }

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
