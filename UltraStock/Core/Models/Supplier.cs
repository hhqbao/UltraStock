using System.Collections.Generic;
using System.Collections.ObjectModel;
using UltraStock.ViewModels.Supplier;

namespace UltraStock.Core.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ABN { get; set; }
        public string ACN { get; set; }
        public string Phone { get; set; }
        public string Fax { set; get; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string PostAddress { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        public Supplier()
        {
            Invoices = new Collection<Invoice>();
        }

        public void Update(SupplierFormViewModel viewModel)
        {
            Name = viewModel.Name;
            ABN = viewModel.ABN;
            ACN = viewModel.ACN;
            Phone = viewModel.Phone;
            Fax = viewModel.Fax;
            Mobile = viewModel.Mobile;
            Address = viewModel.Address;
            PostAddress = viewModel.PostAddress;
        }
    }
}