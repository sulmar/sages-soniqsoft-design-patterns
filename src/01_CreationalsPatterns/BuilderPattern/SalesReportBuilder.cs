using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class SalesReportBuilder
    {

        // Product
        private SalesReport salesReport;

        private IEnumerable<Order> orders;

        public SalesReportBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;

            this.salesReport = new SalesReport();
        }

        public void AddHeader()
        {
            salesReport.Title = "Raport sprzedaży";
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);
        }

        public void AddContent()
        {
            salesReport.ProductDetails = orders
                .SelectMany(o => o.Details)
                .GroupBy(o => o.Product)
                .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));
        }

        public void AddFooter()
        {

        }


        public SalesReport Build()
        {
            return salesReport;
        }


    }

    public interface ISalesReportBuilder
    {
        IHeaderOrContent Instance { get;  }

        SalesReport Build();
    }


    public interface IHeaderOrContent : IHeader, IContent
    {

    }

    public interface IHeader
    {
        IContent AddHeader();
    }

    public interface IContent
    {
        IFooter AddContent();
    }

    public interface IFooter
    {
        void AddFooter();
    }

    public class SmartFluentSalesReportBuilder : ISalesReportBuilder, IHeader, IContent, IFooter
    {

        // Product
        private SalesReport salesReport;

        private IEnumerable<Order> orders;

        public IHeaderOrContent Instance => throw new NotImplementedException();

        public SmartFluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;

            this.salesReport = new SalesReport();
        }

        public IContent AddHeader()
        {
            salesReport.Title = "Raport sprzedaży";
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }

        public IFooter AddContent()
        {
            salesReport.ProductDetails = orders
                .SelectMany(o => o.Details)
                .GroupBy(o => o.Product)
                .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));

            return this;
        }

        public void AddFooter()
        {
            
        }


        public SalesReport Build()
        {
            return salesReport;
        }


    }
    public class FluentSalesReportBuilder
    {

        // Product
        private SalesReport salesReport;

        private IEnumerable<Order> orders;

        public FluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;

            this.salesReport  = new SalesReport();
        }

        public FluentSalesReportBuilder AddHeader()
        {
            salesReport.Title = "Raport sprzedaży";
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }

        public FluentSalesReportBuilder AddContent()
        {
            salesReport.ProductDetails = orders
                .SelectMany(o => o.Details)
                .GroupBy(o => o.Product)
                .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));

            return this;
        }

        public FluentSalesReportBuilder AddFooter()
        {
            return this;
        }


        public SalesReport Build()
        {
            return salesReport;
        }


    }
}
