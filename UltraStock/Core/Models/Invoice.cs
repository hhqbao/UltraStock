using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UltraStock.Controllers.Api;
using UltraStock.ViewModels;
using UltraStock.ViewModels.Invoice;

namespace UltraStock.Core.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public float SubTotal { get; set; }
        public int? DiscountRate { get; set; }
        public float Total { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public Invoice()
        {
            InvoiceDetails = new Collection<InvoiceDetail>();
        }

        public Invoice(InvoiceFormViewModel viewModel) : this()
        {
            Update(viewModel);
        }

        public void Update(InvoiceFormViewModel viewModel)
        {
            Number = viewModel.Number;
            Date = viewModel.Date;
            SupplierId = viewModel.SupplierId;
            DiscountRate = viewModel.DiscountRate;
            SubTotal = viewModel.SubTotal;
            Total = viewModel.Total;

            foreach (var detail in viewModel.InvoiceDetails)
            {
                if (detail.Action.HasValue)
                {
                    switch (detail.Action)
                    {
                        case Actions.Insert:
                            InsertNewInvoiceDetail(detail);
                            break;
                        case Actions.Update:
                            UpdateInvoiceDetail(detail);
                            break;
                        case Actions.Remove:
                            RemoveInvoiceDetail(detail);
                            break;
                    }
                }
            }
        }

        private void InsertNewInvoiceDetail(InvoiceDetailViewModel detail)
        {
            var newDetail = new InvoiceDetail(detail);

            InvoiceDetails.Add(newDetail);
        }

        private void UpdateInvoiceDetail(InvoiceDetailViewModel detail)
        {
            var detailInDb = InvoiceDetails.SingleOrDefault(d => d.ProductId == detail.ProductId);

            if (detailInDb != null)
            {
                detailInDb.Update(detail);
            }
        }

        private void RemoveInvoiceDetail(InvoiceDetailViewModel detail)
        {
            var detailInDb = InvoiceDetails.SingleOrDefault(d => d.ProductId == detail.ProductId);

            if (detailInDb != null)
            {
                InvoiceDetails.Remove(detailInDb);
            }
        }
    }
}