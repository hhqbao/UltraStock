using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UltraStock.ViewModels.BarCode;
using UltraStock.ViewModels.Product;

namespace UltraStock.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<BarCode> BarCodes { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public Product()
        {
            BarCodes = new Collection<BarCode>();
            InvoiceDetails = new Collection<InvoiceDetail>();
        }

        public void Update(ProductFormViewModel viewModel)
        {
            Reference = viewModel.Reference;
            Description = viewModel.Description;
            CategoryId = viewModel.CategoryId;

            foreach (var barCode in viewModel.BarCodes)
            {
                switch (barCode.Id)
                {
                    case 0:
                        BarCodes.Add(new BarCode { Value = barCode.Value });
                        break;

                    case -1:
                        RemoveBarCode(barCode.Temp.Value);
                        break;

                    default:
                        UpdateBarCode(barCode);
                        break;
                }
            }
        }

        private void UpdateBarCode(BarCodeViewModel barCode)
        {
            var barCodeInDb = BarCodes.SingleOrDefault(b => b.Id == barCode.Id);

            if (barCodeInDb != null)
                barCodeInDb.UpdateValue(barCode.Value);
        }

        private void RemoveBarCode(int tempValue)
        {
            var barCode = BarCodes.SingleOrDefault(b => b.Id == tempValue);

            if (barCode != null)
                BarCodes.Remove(barCode);
        }
    }
}