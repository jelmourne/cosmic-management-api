using Npgsql;
using System.Data;

namespace cosmic_management_api.Models {
    public class Database {
        public Response loginUser(NpgsqlConnection con, User user) {
            con.Open();
            Response response = new Response();
            string Query = string.Format("SELECT * FROM festival.user WHERE username='{0}' AND password='{1}'", user.Username, user.Password);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0) {
                response.status = 200;
                response.message = "Logged in successfully";
                response.body = user;
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

        public Response createUser(NpgsqlConnection con, User user) {
            con.Open();
            Response response = new Response();
            string Query = string.Format("INSERT INTO festival.user(name,username,password,is_admin) VALUES ('{0}','{1}','{2}',{3})",user.Name, user.Username, user.Password, user.Admin);

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

        
        public Response getProduction(NpgsqlConnection con) {
            con.Open();
            Response response = new Response();
            string Query = "SELECT * FROM festival.production";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<object> list = new List<object>();

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

        public Response updateProduction(NpgsqlConnection con, Production prod) { 
            con.Open();
            Response response = new Response();
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

        public Response insertProduction(NpgsqlConnection con, Production prod) {
            con.Open();
            Response response = new Response();
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

        public Response deleteProduction(NpgsqlConnection con, Production prod) {
            con.Open();
            Response response = new Response();
            string Query = string.Format("DELETE FROM festival.production WHERE type = '{0}' AND description = '{1}'", prod.type, prod.description);

            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();

            if (i > 0) {
                response.status = 200;
                response.message = "Production deleted successfully";
                response.body = prod;
                response.data = null;
            }
            else {
                response.status = 500;
                response.message = "Failed to delete production";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;

        }

        public Response AddStage(NpgsqlConnection con, Stage stage)
        {
            con.Open();
            Response response = new Response();

            string Query = "INSERT INTO festival.stage VALUES(default, @name, @genre, @size)";

            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@name", stage.name);
            cmd.Parameters.AddWithValue("@genre", stage.genre);
            cmd.Parameters.AddWithValue("@size", stage.size);

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.status = 200;
                response.message = "Stage added successfully";
                response.body = stage;
                response.data = null;
            } else
            {
                response.status = 500;
                response.message = "Failed to add stage";
                response.body = null;
                response.data = null;
            }
            con.Close();
            return response;

        }
    }
}

