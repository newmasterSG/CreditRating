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
            public double CalculateCreditHistoryLengthScore(int creditHistoryLength)
            {
                if (creditHistoryLength < 2)
                {
                    return 0;
                }
                else if (creditHistoryLength >= 2 && creditHistoryLength < 5)
                {
                    return 20;
                }
                else if (creditHistoryLength >= 5 && creditHistoryLength < 7)
                {
                    return 30;
                }
                else if (creditHistoryLength >= 7 && creditHistoryLength < 10)
                {
                    return 40;
                }
                else
                {
                    return 50;
                }
            }

            //public double CalculateCreditMixScore(string creditMix)
            //{
            //    using (var context = new BankingContext())
            //    {
            //        var creditCards = context.CreditCards.Where(c => c.PersonId == personId).ToList();
            //        var creditLimitSum = creditCards.Sum(c => c.CreditLimit);
            //        var balanceSum = creditCards.Sum(c => c.Balance);
            //        var utilization = balanceSum / creditLimitSum;

            //        if (utilization < 0.1)
            //        {
            //            return 10;
            //        }
            //        else if (utilization < 0.3)
            //        {
            //            return 20;
            //        }
            //        else if (utilization < 0.5)
            //        {
            //            return 15;
            //        }
            //        else
            //        {
            //            return 10;
            //        }
            //    }
            //}

            public double CalculateCreditUtilizationScore(double creditUtilization)
            {
                if (creditUtilization >= 0 && creditUtilization <= 0.3)
                {
                    return 100;
                }
                else if (creditUtilization > 0.3 && creditUtilization <= 0.5)
                {
                    return 80;
                }
                else if (creditUtilization > 0.5 && creditUtilization <= 0.7)
                {
                    return 60;
                }
                else if (creditUtilization > 0.7 && creditUtilization <= 0.9)
                {
                    return 40;
                }
                else
                {
                    return 20;
                }
            }

            public double CalculatePaymentHistoryScore(List<double> paymentHistory)
            {
                double onTimePayments = paymentHistory.Count(x => x == 1);
                return onTimePayments / paymentHistory.Count * 100;
            }

            public double CalculateRecentInquiriesScore(int recentInquiries)
            {
                if (recentInquiries == 0)
                {
                    return 100;
                }
                else if (recentInquiries == 1)
                {
                    return 80;
                }
                else if (recentInquiries == 2)
                {
                    return 60;
                }
                else if (recentInquiries == 3)
                {
                    return 40;
                }
                else
                {
                    return 20;
                }
            }

            public double CalculateScore(Client person)
            {
                double creditUtilizationScore = CalculateCreditUtilizationScore(person.CreditHistory.CreditUtilization);
                double paymentHistoryScore = CalculatePaymentHistoryScore(person.CreditHistory.PaymentHistory);
                double lengthOfCreditHistoryScore = CalculateCreditHistoryLengthScore(person.CreditHistory.CreditHistoryLength);
                double recentInquiriesScore = CalculateRecentInquiriesScore(person.CreditHistory.recentInquiries);

                double ficoScore =
                    IGrade._factorWeights["creditUtilization"] * creditUtilizationScore +
                     IGrade._factorWeights["paymentHistory"] * paymentHistoryScore +
                     IGrade._factorWeights["creditHistoryLength"] * lengthOfCreditHistoryScore +
                     IGrade._factorWeights["recentInquiries"] * recentInquiriesScore;

                return ficoScore;
            }
        }
    }
