namespace L4;

public static class OpenClosed
{
    public static void Execute()
    {
        Invoice FInvoice = new FinalInvoice();
        Invoice PInvoice = new ProposedInvoice();
        Invoice RInvoice = new RecurringInvoice();

        double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000);
        double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000);
        double RInvoiceAmount = RInvoice.GetInvoiceDiscount(10000);
    }

    public class Invoice1
    {
        public double GetInvoiceDiscount(double amount, InvoiceType invoiceType)
        {
            double finalAmount = 0;
            if (invoiceType == InvoiceType.FinalInvoice)
            {
                finalAmount = amount - 100;
            }
            else if (invoiceType == InvoiceType.ProposedInvoice)
            {
                finalAmount = amount - 50;
            }
            return finalAmount;
        }
    }
    public enum InvoiceType
    {
        FinalInvoice,
        ProposedInvoice
    };



    public class Invoice
    {
        public virtual double GetInvoiceDiscount(double amount)
        {
            return amount - 10;
        }
    }

    public class FinalInvoice : Invoice
    {
        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - 50;
        }
    }
    public class ProposedInvoice : Invoice
    {
        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - 40;
        }
    }
    public class RecurringInvoice : Invoice
    {
        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - 30;
        }
    }
}
