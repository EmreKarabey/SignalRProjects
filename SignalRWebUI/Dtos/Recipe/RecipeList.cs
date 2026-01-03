namespace SignalRWebUI.Dtos.Recipe
{
    public class RecipeList
    {

    
            public int count { get; set; }
            public Result[] results { get; set; }
   

        public class Result
        {
            public int approved_at { get; set; }
            public string aspect_ratio { get; set; }
            public object beauty_url { get; set; }
            public object brand { get; set; }
            public object brand_id { get; set; }
            public int? buzz_id { get; set; }
            public string canonical_id { get; set; }
            public Compilation[] compilations { get; set; }
            public int cook_time_minutes { get; set; }
            public string country { get; set; }
            public int created_at { get; set; }
            public Credit[] credits { get; set; }
            public string description { get; set; }
            public string draft_status { get; set; }
            public object[] facebook_posts { get; set; }
            public int id { get; set; }
            public string inspired_by_url { get; set; }
            public Instruction[] instructions { get; set; }
            public bool is_app_only { get; set; }
            public bool is_one_top { get; set; }
            public bool is_shoppable { get; set; }
            public bool is_subscriber_content { get; set; }
            public string keywords { get; set; }
            public string language { get; set; }
            public string name { get; set; }
            public int num_servings { get; set; }
            public Nutrition nutrition { get; set; }
            public string nutrition_visibility { get; set; }
            public string original_video_url { get; set; }
            public int prep_time_minutes { get; set; }
            public Price price { get; set; }
            public string promotion { get; set; }
            public Rendition[] renditions { get; set; }
            public Section[] sections { get; set; }
            public string seo_path { get; set; }
            public string seo_title { get; set; }
            public string servings_noun_plural { get; set; }
            public string servings_noun_singular { get; set; }
            public Show show { get; set; }
            public int show_id { get; set; }
            public string slug { get; set; }
            public Tag[] tags { get; set; }
            public string thumbnail_alt_text { get; set; }
            public string thumbnail_url { get; set; }
            public bool tips_and_ratings_enabled { get; set; }
            public Topic[] topics { get; set; }
            public int total_time_minutes { get; set; }
            public Total_Time_Tier total_time_tier { get; set; }
            public int updated_at { get; set; }
            public User_Ratings user_ratings { get; set; }
            public string video_ad_content { get; set; }
            public int? video_id { get; set; }
            public string video_url { get; set; }
            public string yields { get; set; }
            public Tips_Summary tips_summary { get; set; }
        }

        public class Nutrition
        {
            public int calories { get; set; }
            public int carbohydrates { get; set; }
            public int fat { get; set; }
            public int fiber { get; set; }
            public int protein { get; set; }
            public int sugar { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class Price
        {
            public int consumption_portion { get; set; }
            public int consumption_total { get; set; }
            public int portion { get; set; }
            public int total { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class Show
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Total_Time_Tier
        {
            public string display_tier { get; set; }
            public string tier { get; set; }
        }

        public class User_Ratings
        {
            public int count_negative { get; set; }
            public int count_positive { get; set; }
            public float score { get; set; }
        }

        public class Tips_Summary
        {
            public string by_line { get; set; }
            public string content { get; set; }
            public string header { get; set; }
        }

        public class Compilation
        {
            public int approved_at { get; set; }
            public string aspect_ratio { get; set; }
            public string beauty_url { get; set; }
            public int? buzz_id { get; set; }
            public string canonical_id { get; set; }
            public string country { get; set; }
            public int created_at { get; set; }
            public string description { get; set; }
            public string draft_status { get; set; }
            public object[] facebook_posts { get; set; }
            public int id { get; set; }
            public bool is_shoppable { get; set; }
            public string keywords { get; set; }
            public string language { get; set; }
            public string name { get; set; }
            public string promotion { get; set; }
            public Show1[] show { get; set; }
            public string slug { get; set; }
            public string thumbnail_alt_text { get; set; }
            public string thumbnail_url { get; set; }
            public int video_id { get; set; }
            public string video_url { get; set; }
        }

        public class Show1
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Credit
        {
            public bool is_verified { get; set; }
            public string name { get; set; }
            public string picture_url { get; set; }
            public string type { get; set; }
            public object user_id { get; set; }
        }

        public class Instruction
        {
            public string appliance { get; set; }
            public string display_text { get; set; }
            public int end_time { get; set; }
            public int id { get; set; }
            public int position { get; set; }
            public int start_time { get; set; }
            public int? temperature { get; set; }
            public Hack[] hacks { get; set; }
        }

        public class Hack
        {
            public int end_index { get; set; }
            public int id { get; set; }
            public string match { get; set; }
            public int start_index { get; set; }
        }

        public class Rendition
        {
            public string aspect { get; set; }
            public int? bit_rate { get; set; }
            public string container { get; set; }
            public string content_type { get; set; }
            public int duration { get; set; }
            public int? file_size { get; set; }
            public int height { get; set; }
            public int? maximum_bit_rate { get; set; }
            public int? maximum_total_size_estimate { get; set; }
            public int? minimum_bit_rate { get; set; }
            public int? minimum_total_size_estimate { get; set; }
            public string name { get; set; }
            public string poster_url { get; set; }
            public string url { get; set; }
            public int width { get; set; }
        }

        public class Section
        {
            public Component[] components { get; set; }
            public string name { get; set; }
            public int position { get; set; }
        }

        public class Component
        {
            public string extra_comment { get; set; }
            public int id { get; set; }
            public Ingredient ingredient { get; set; }
            public Measurement[] measurements { get; set; }
            public int position { get; set; }
            public string raw_text { get; set; }
            public Hack1[] hacks { get; set; }
        }

        public class Ingredient
        {
            public int created_at { get; set; }
            public string display_plural { get; set; }
            public string display_singular { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int updated_at { get; set; }
        }

        public class Measurement
        {
            public int id { get; set; }
            public string quantity { get; set; }
            public Unit unit { get; set; }
        }

        public class Unit
        {
            public string abbreviation { get; set; }
            public string display_plural { get; set; }
            public string display_singular { get; set; }
            public string name { get; set; }
            public string system { get; set; }
        }

        public class Hack1
        {
            public int end_index { get; set; }
            public int id { get; set; }
            public string match { get; set; }
            public int start_index { get; set; }
        }

        public class Tag
        {
            public string display_name { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string parent_tag_name { get; set; }
            public string root_tag_type { get; set; }
            public string type { get; set; }
        }

        public class Topic
        {
            public string name { get; set; }
            public string slug { get; set; }
        }

    }
}
