using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class WeddingGuest : BaseEntity
    {
        [Key]
        public int wedding_guest_id {get;set;}
        public int wedding_id {get;set;}
        public int user_id {get;set;}
        public User Guest {get;set;}
        public Wedding Wedding {get;set;}
        public bool pending {get;set;}

        public WeddingGuest()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}