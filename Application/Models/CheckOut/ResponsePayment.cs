namespace Application.Models.CheckOut
{
    public class ResponsePayment
    {
        public int id { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_approved { get; set; }
        public DateTime date_last_updated { get; set; }
        public DateTime money_release_date { get; set; }
        public int issuer_id { get; set; }
        public string? payment_method_id { get; set; }
        public string? payment_type_id { get; set; }
        public string? status { get; set; }
        public string? status_detail { get; set; }
        public string? currency_id { get; set; }
        public string? description { get; set; }
        public int taxes_amount { get; set; }
        public int shipping_amount { get; set; }
        public int collector_id { get; set; }
        public Payer? payer { get; set; }
        public Metadata? metadata { get; set; }
        public Additional_Info? additional_info { get; set; }
        public string? external_reference { get; set; }
        public int transaction_amount { get; set; }
        public int transaction_amount_refunded { get; set; }
        public int coupon_amount { get; set; }
        public Transaction_Details? transaction_details { get; set; }
        public Fee_Details[] fee_details { get; set; }
        public string? statement_descriptor { get; set; }
        public int installments { get; set; }
        public Card? card { get; set; }
        public string? notification_url { get; set; }
        public string? processing_mode { get; set; }
        public Point_Of_Interaction? point_of_interaction { get; set; }
    }

    public class Payer
    {
        public int? id { get; set; }
        public string? email { get; set; }
        public Identification? identification { get; set; }
        public string? type { get; set; }
    }

    public class Identification
    {
        public long number { get; set; }
        public string? type { get; set; }
    }

    public class Metadata
    {
    }

    public class Additional_Info
    {
        public Item[]? items { get; set; }
        public Payer1? payer { get; set; }
        public Shipments? shipments { get; set; }
    }

    public class Payer1
    {
        public DateTime registration_date { get; set; }
    }

    public class Shipments
    {
        public Receiver_Address? receiver_address { get; set; }
    }

    public class Receiver_Address
    {
        public string? street_name { get; set; }
        public int street_number { get; set; }
        public int zip_code { get; set; }
        public string? city_name { get; set; }
        public string? state_name { get; set; }
    }

    public class Item
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? picture_url { get; set; }
        public string? category_id { get; set; }
        public int quantity { get; set; }
        public int unit_price { get; set; }
    }

    public class Transaction_Details
    {
        public int net_received_amount { get; set; }
        public int total_paid_amount { get; set; }
        public int overpaid_amount { get; set; }
        public int installment_amount { get; set; }
    }

    public class Card
    {
        public int first_six_digits { get; set; }
        public int last_four_digits { get; set; }
        public int expiration_month { get; set; }
        public int expiration_year { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_last_updated { get; set; }
        public Cardholder cardholder { get; set; }
    }

    public class Cardholder
    {
        public string? name { get; set; }
        public Identification1? identification { get; set; }
    }

    public class Identification1
    {
        public long number { get; set; }
        public string? type { get; set; }
    }

    public class Point_Of_Interaction
    {
        public string? type { get; set; }
        public Application_Data? application_data { get; set; }
        public Transaction_Data? transaction_data { get; set; }
    }

    public class Application_Data
    {
        public string? name { get; set; }
        public string? version { get; set; }
    }

    public class Transaction_Data
    {
        public string? qr_code_base64 { get; set; }
        public string? qr_code { get; set; }
        public string? ticket_url { get; set; }
    }

    public class Fee_Details
    {
        public string? type { get; set; }
        public int amount { get; set; }
        public string? fee_payer { get; set; }
    }

}
