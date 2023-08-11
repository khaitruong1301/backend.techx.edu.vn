//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinimaServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CinimaBooking
    {
        public int CinimaBookingID { get; set; }
        public string SeatID { get; set; }
        public Nullable<System.DateTime> DateView { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> UserID { get; set; }
        public string GroupID { get; set; }
        public Nullable<int> ShowTimeID { get; set; }
    
        public virtual CinimaRoom_Movie CinimaRoom_Movie { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Seat Seat { get; set; }
    }
}