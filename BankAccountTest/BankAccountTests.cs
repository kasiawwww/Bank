﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountMS;

namespace BankAccountTest
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr X Y", beginningBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero()
        {
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr X Y", beginningBalance);

            account.Debit(debitAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("Mr X Y", beginningBalance);

            //try
            //{
                account.Debit(debitAmount);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            //    return;
            //}
            //Assert.Fail("The expected exception was not thrown");

        }
    }
}
