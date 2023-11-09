using Npgsql;
using System.Data;

namespace cosmic_management_api.Models {
    public class Database {
        public Response<User> loginUser(NpgsqlConnection con, User user) {
            con.Open();
            Response<User> response = new Response<User>();
            string Query = string.Format("SELECT * FROM festival.user WHERE username='{0}' AND password='{1}'", user.username, user.password);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0) {
                User newUser = new User();
                newUser.name = (string)dt.Rows[0]["name"];
                newUser.username = (string)dt.Rows[0]["username"];
                newUser.admin = (bool)dt.Rows[0]["is_admin"];

                response.status = 200;
                response.message = "Logged in successfully";
                response.body = newUser;
                response.data = null;
            }
            else {
                response.status = 500;
                response.message = "Failed to login";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }

        public Response<User> createUser(NpgsqlConnection con, User user) {
            con.Open();
            Response<User> response = new Response<User>();
            string Query = string.Format("INSERT INTO festival.user(name,username,password,is_admin) VALUES ('{0}','{1}','{2}',{3})",user.name, user.username, user.password, user.admin);

            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();

            if (i > 0) {
                response.status = 200;
                response.message = "User created successfully";
                response.body = user;
                response.data = null;
            }
            else {
                response.status = 500;
                response.message = "Failed to create user";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }

        
        public Response<Production> getProduction(NpgsqlConnection con) {
            con.Open();
            Response<Production> response = new Response<Production>();
            string Query = "SELECT * FROM festival.production";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Production> list = new List<Production>();

            if (dt.Rows.Count > 0) {
                for (int i = 0; i < dt.Rows.Count; i++) {
                    Production prod = new Production();
                    prod.id = (int)dt.Rows[i]["prod_id"];
                    prod.type = (string)dt.Rows[i]["type"];
                    prod.description = (string)dt.Rows[i]["description"];
                    list.Add(prod);
                }
                response.status = 200;
                response.message = "Successfully queried production";
                response.body = null;
                response.data = list;
            }
            else {
                response.status = 500;
                response.message = "Failed to query production";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }

        public Response<Production> updateProduction(NpgsqlConnection con, Production prod) { 
            con.Open();
            Response<Production> response = new Response<Production>();
            string Query = string.Format("UPDATE festival.production SET type = '{0}', description = '{1}' WHERE prod_id = {2}", prod.type, prod.description, prod.id) ;
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            int i = cmd.ExecuteNonQuery();
            if (i > 0) {
                response.status = 200;
                response.message = "Successfully updated production";
                response.body = prod;
                response.data = null;
            }
            else {
                response.status = 100;
                response.message = "Failed to update production";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }

        public Response<Production> insertProduction(NpgsqlConnection con, Production prod) {
            con.Open();
            Response<Production> response = new Response<Production>();
            string Query = string.Format("INSERT INTO festival.production(type,description) VALUES ('{0}','{1}')", prod.type, prod.description);

            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();

            if (i > 0) {
                response.status = 200;
                response.message = "Production created successfully";
                response.body = prod;
                response.data = null;
            }
            else {
                response.status = 500;
                response.message = "Failed to create production";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }

        public Response<Production> deleteProduction(NpgsqlConnection con, Production prod) {
            con.Open();
            Response<Production> response = new Response<Production>();
            string Query = string.Format("DELETE FROM festival.production WHERE type = '{0}' AND description = '{1}')", prod.type, prod.description);

            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();

            if (i > 0) {
                response.status = 200;
                response.message = "Production created successfully";
                response.body = prod;
                response.data = null;
            }
            else {
                response.status = 500;
                response.message = "Failed to create production";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;

        }

        public Response<Vendor> getVendor(NpgsqlConnection con) {
            con.Open();
            Response<Vendor> response = new Response<Vendor>();
            string Query = "SELECT * FROM festival.vendor";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Vendor> list = new List<Vendor>();

            if (dt.Rows.Count > 0) {
                for (int i = 0; i < dt.Rows.Count; i++) {
                    Vendor vendor = new Vendor();
                    vendor.id = (int)dt.Rows[i]["vendor_id"];
                    vendor.name = (string)dt.Rows[i]["name"];
                    vendor.type = (string)dt.Rows[i]["type"];
                    list.Add(vendor);
                }
                response.status = 200;
                response.message = "Successfully queried vendors";
                response.body = null;
                response.data = list;
            }
            else {
                response.status = 500;
                response.message = "Failed to query vendors";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }

        public Response<Vendor> updateVendor(NpgsqlConnection con, Vendor vendor) {
            Response<Vendor> response = new Response<Vendor>();
            string Query = string.Format("UPDATE festival.vendor SET name = '{0}', type = '{1}' WHERE prod_id = {2}", vendor.name, vendor.type, vendor.id);
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            int i = cmd.ExecuteNonQuery();
            if (i > 0) {
                response.status = 200;
                response.message = "Successfully updated vendor";
                response.body = vendor;
                response.data = null;
            }
            else {
                response.status = 100;
                response.message = "Failed to update vendor";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }

        public Response<Vendor> insertVendor(NpgsqlConnection con, Vendor vendor) {
            con.Open();
            Response<Vendor> response = new Response<Vendor>();
            string Query = string.Format("INSERT INTO festival.vendor(name,type) VALUES ('{0}','{1}')", vendor.name, vendor.type);

            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();

            if (i > 0) {
                response.status = 200;
                response.message = "Production created successfully";
                response.body = vendor;
                response.data = null;
            }
            else {
                response.status = 500;
                response.message = "Failed to create production";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }

        public Response<Vendor> deleteVendor(NpgsqlConnection con, Vendor vendor) {
            con.Open();
            Response<Vendor> response = new Response<Vendor>();
            string Query = string.Format("DELETE FROM festival.vendor WHERE vendor_id = {0})", vendor.id);

            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();

            if (i > 0) {
                response.status = 200;
                response.message = "Production created successfully";
                response.body = null;
                response.data = null;
            }
            else {
                response.status = 500;
                response.message = "Failed to create production";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;
        }
    }
}

