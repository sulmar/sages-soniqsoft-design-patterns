﻿using System;

namespace NullObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Null Object Pattern!");

            IProductRepository productRepository = new FakeProductRepository();

            ProductBase product = productRepository.Get(1);

            product.RateId(3);
            
        }
    }

    public interface IProductRepository
    {
        ProductBase Get(int id);
    }

    public class FakeProductRepository : IProductRepository
    {
        public ProductBase Get(int id)
        {
            return null;
        }
    }

    // Abstract Object
    public abstract class ProductBase
    {
        protected int rate;

        public abstract void RateId(int rate);

        public static readonly ProductBase Null = new NullProduct();

        // Null Object
        private class NullProduct : ProductBase
        {
            public override void RateId(int rate)
            {
                // nic nie rób
            }
        }
    }

    // Real Object
    public class Product : ProductBase
    {
        private int rate;

        public override void RateId(int rate)
        {
            this.rate = rate;
        }

    }
}
