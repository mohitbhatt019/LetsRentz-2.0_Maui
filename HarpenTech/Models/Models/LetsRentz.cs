using System;
using System.Collections.Generic;

namespace HarpenTech.Models.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parent_id { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Data
    {
        public List<PropertyListing> propertyListing { get; set; }
    }

    public class FurnishTypes
    {
        public int id { get; set; }
        public string name { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class PropertyExtrainfo
    {
        public int id { get; set; }
        public int property_id { get; set; }
        public string livin_couple_allowed { get; set; }
        public string fully_independent { get; set; }
        public string student_allowed { get; set; }
        public string super_luxury { get; set; }
        public string owner_free { get; set; }
        public string rent_negotiable { get; set; }
        public string pet_friendly { get; set; }
        public string gated_society { get; set; }
        public object video_link { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class PropertyImage
    {
        public int id { get; set; }
        public int property_id { get; set; }
        public string image_url { get; set; }
        public string type { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class PropertyListing
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int added_by { get; set; }
        public string description { get; set; }
        public int bedroom { get; set; }
        public int washroom { get; set; }
        public int squarefeet { get; set; }
        public int property_type_id { get; set; }
        public int category_id { get; set; }
        public int tenant_id { get; set; }
        public int furnished_id { get; set; }
        public int car_parking { get; set; }
        public string floor { get; set; }
        public int brokerage { get; set; }
        public string brokerage_fees_type { get; set; }
        public string food_availability { get; set; }
        public string next_availability { get; set; }
        public int rent { get; set; }
        public string address { get; set; }
        public string full_address { get; set; }
        public double lati { get; set; }
        public double longi { get; set; }
        public int admin_approval { get; set; }
        public int availability { get; set; }
        public int is_verified { get; set; }
        public int is_featured { get; set; }
        public int is_prime { get; set; }
        public int is_expired { get; set; }
        public int is_freezed { get; set; }
        public int extra_option { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int review_count { get; set; }
        public int review_avg { get; set; }
        public int is_fav { get; set; }
        public List<PropertyImage> property_images { get; set; }
        public UserDetail user_detail { get; set; }
        public PropertyType property_type { get; set; }
        public Category category { get; set; }
        public Tenant tenant { get; set; }
        public FurnishTypes furnish_types { get; set; }
        public PropertyExtrainfo property_extrainfo { get; set; }
    }

    public class PropertyType
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parent_id { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Root
    {
        public bool status { get; set; }
        public string message { get; set; }
        public int user_access { get; set; }
        public Data data { get; set; }
    }

    public class Tenant
    {
        public int id { get; set; }
        public string name { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class UserDetail
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public object email { get; set; }
        public string user_image { get; set; }
        public string phone_number { get; set; }
        public object social_id { get; set; }
        public string social_type { get; set; }
        public object device_type { get; set; }
        public string user_type { get; set; }
        public string gender { get; set; }
        public string country_code { get; set; }
        public string address { get; set; }
        public object gstin { get; set; }
        public double lati { get; set; }
        public double longi { get; set; }
        public int verification { get; set; }
        public int user_access { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int is_confirmed { get; set; }
        public object bio { get; set; }
        public int is_paid { get; set; }
        public int is_frezzed { get; set; }
    }


}
